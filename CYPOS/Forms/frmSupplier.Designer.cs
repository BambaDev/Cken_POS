namespace cypos
{
    partial class frmSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplier));
            this.lblSupplierId = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.tbSupplier = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnKbEmail = new System.Windows.Forms.Button();
            this.btnKbPhone = new System.Windows.Forms.Button();
            this.btnKbAddress = new System.Windows.Forms.Button();
            this.btnKbName = new System.Windows.Forms.Button();
            this.pnlMail = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.dgvSuppliers = new System.Windows.Forms.DataGridView();
            this.clmSupplierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSupplierDown = new System.Windows.Forms.Button();
            this.btnSupplierUp = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnKbSearch = new System.Windows.Forms.Button();
            this.txtSearchSupplier = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.pnlEntry = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbSupplier.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlMail.SuspendLayout();
            this.pnlInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlEntry.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSupplierId
            // 
            this.lblSupplierId.AutoSize = true;
            this.lblSupplierId.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierId.Location = new System.Drawing.Point(129, 13);
            this.lblSupplierId.Name = "lblSupplierId";
            this.lblSupplierId.Size = new System.Drawing.Size(13, 16);
            this.lblSupplierId.TabIndex = 1;
            this.lblSupplierId.Text = "-";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(329, 32);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 23);
            this.txtEmail.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(325, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Supplier Name:";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierName.Location = new System.Drawing.Point(18, 32);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(250, 23);
            this.txtSupplierName.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(18, 84);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(250, 71);
            this.txtAddress.TabIndex = 6;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(18, 181);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 23);
            this.txtPhone.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 164);
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
            // tbSupplier
            // 
            this.tbSupplier.Controls.Add(this.tabPage1);
            this.tbSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSupplier.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSupplier.ItemSize = new System.Drawing.Size(150, 45);
            this.tbSupplier.Location = new System.Drawing.Point(5, 5);
            this.tbSupplier.Name = "tbSupplier";
            this.tbSupplier.SelectedIndex = 0;
            this.tbSupplier.Size = new System.Drawing.Size(780, 290);
            this.tbSupplier.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbSupplier.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.btnClear);
            this.tabPage1.Controls.Add(this.btnExit);
            this.tabPage1.Controls.Add(this.btnKbEmail);
            this.tabPage1.Controls.Add(this.btnKbPhone);
            this.tabPage1.Controls.Add(this.btnKbAddress);
            this.tabPage1.Controls.Add(this.btnKbName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtPhone);
            this.tabPage1.Controls.Add(this.lblSupplierId);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtSupplierName);
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.txtAddress);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 49);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(772, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Supplier Details";
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
            this.btnKbEmail.Location = new System.Drawing.Point(586, 20);
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
            this.btnKbPhone.Location = new System.Drawing.Point(274, 172);
            this.btnKbPhone.Name = "btnKbPhone";
            this.btnKbPhone.Size = new System.Drawing.Size(50, 35);
            this.btnKbPhone.TabIndex = 190;
            this.btnKbPhone.UseVisualStyleBackColor = true;
            this.btnKbPhone.Click += new System.EventHandler(this.btnKbPhone_Click);
            // 
            // btnKbAddress
            // 
            this.btnKbAddress.FlatAppearance.BorderSize = 0;
            this.btnKbAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbAddress.Image = ((System.Drawing.Image)(resources.GetObject("btnKbAddress.Image")));
            this.btnKbAddress.Location = new System.Drawing.Point(273, 87);
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
            this.btnKbName.Location = new System.Drawing.Point(273, 28);
            this.btnKbName.Name = "btnKbName";
            this.btnKbName.Size = new System.Drawing.Size(50, 35);
            this.btnKbName.TabIndex = 187;
            this.btnKbName.UseVisualStyleBackColor = true;
            this.btnKbName.Click += new System.EventHandler(this.btnKbName_Click);
            // 
            // pnlMail
            // 
            this.pnlMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMail.Controls.Add(this.pnlInner);
            this.pnlMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMail.Location = new System.Drawing.Point(0, 38);
            this.pnlMail.Name = "pnlMail";
            this.pnlMail.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlMail.Size = new System.Drawing.Size(800, 512);
            this.pnlMail.TabIndex = 165;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.SystemColors.Control;
            this.pnlInner.Controls.Add(this.dgvSuppliers);
            this.pnlInner.Controls.Add(this.panel2);
            this.pnlInner.Controls.Add(this.pnlSearch);
            this.pnlInner.Controls.Add(this.pnlEntry);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(5, 0);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Size = new System.Drawing.Size(790, 507);
            this.pnlInner.TabIndex = 18;
            // 
            // dgvSuppliers
            // 
            this.dgvSuppliers.AllowUserToAddRows = false;
            this.dgvSuppliers.AllowUserToDeleteRows = false;
            this.dgvSuppliers.AllowUserToResizeColumns = false;
            this.dgvSuppliers.AllowUserToResizeRows = false;
            this.dgvSuppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuppliers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSuppliers.ColumnHeadersHeight = 32;
            this.dgvSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSuppliers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSupplierId,
            this.clmSupplier,
            this.clmAddress,
            this.clmPhone,
            this.clmEmail});
            this.dgvSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSuppliers.Location = new System.Drawing.Point(0, 47);
            this.dgvSuppliers.MultiSelect = false;
            this.dgvSuppliers.Name = "dgvSuppliers";
            this.dgvSuppliers.ReadOnly = true;
            this.dgvSuppliers.RowHeadersVisible = false;
            this.dgvSuppliers.RowTemplate.Height = 32;
            this.dgvSuppliers.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliers.Size = new System.Drawing.Size(702, 160);
            this.dgvSuppliers.TabIndex = 18;
            this.dgvSuppliers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuppliers_CellClick);
            // 
            // clmSupplierId
            // 
            this.clmSupplierId.DataPropertyName = "id";
            this.clmSupplierId.HeaderText = "Id";
            this.clmSupplierId.Name = "clmSupplierId";
            this.clmSupplierId.ReadOnly = true;
            this.clmSupplierId.Visible = false;
            // 
            // clmSupplier
            // 
            this.clmSupplier.DataPropertyName = "name";
            this.clmSupplier.HeaderText = "Supplier";
            this.clmSupplier.Name = "clmSupplier";
            this.clmSupplier.ReadOnly = true;
            // 
            // clmAddress
            // 
            this.clmAddress.DataPropertyName = "address";
            this.clmAddress.HeaderText = "Address";
            this.clmAddress.Name = "clmAddress";
            this.clmAddress.ReadOnly = true;
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
            this.panel2.Controls.Add(this.btnSupplierDown);
            this.panel2.Controls.Add(this.btnSupplierUp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(702, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(88, 160);
            this.panel2.TabIndex = 21;
            // 
            // btnSupplierDown
            // 
            this.btnSupplierDown.Image = global::cypos.Properties.Resources.row_down;
            this.btnSupplierDown.Location = new System.Drawing.Point(6, 59);
            this.btnSupplierDown.Name = "btnSupplierDown";
            this.btnSupplierDown.Size = new System.Drawing.Size(75, 55);
            this.btnSupplierDown.TabIndex = 3;
            this.btnSupplierDown.UseVisualStyleBackColor = true;
            // 
            // btnSupplierUp
            // 
            this.btnSupplierUp.Image = global::cypos.Properties.Resources.row_up;
            this.btnSupplierUp.Location = new System.Drawing.Point(6, 0);
            this.btnSupplierUp.Name = "btnSupplierUp";
            this.btnSupplierUp.Size = new System.Drawing.Size(75, 55);
            this.btnSupplierUp.TabIndex = 2;
            this.btnSupplierUp.UseVisualStyleBackColor = true;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlSearch.Controls.Add(this.btnKbSearch);
            this.pnlSearch.Controls.Add(this.txtSearchSupplier);
            this.pnlSearch.Controls.Add(this.label17);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(10, 1, 1, 1);
            this.pnlSearch.Size = new System.Drawing.Size(790, 47);
            this.pnlSearch.TabIndex = 20;
            // 
            // btnKbSearch
            // 
            this.btnKbSearch.FlatAppearance.BorderSize = 0;
            this.btnKbSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbSearch.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbSearch.Location = new System.Drawing.Point(342, 4);
            this.btnKbSearch.Name = "btnKbSearch";
            this.btnKbSearch.Size = new System.Drawing.Size(58, 38);
            this.btnKbSearch.TabIndex = 176;
            this.btnKbSearch.UseVisualStyleBackColor = true;
            this.btnKbSearch.Click += new System.EventHandler(this.btnKbSearch_Click);
            // 
            // txtSearchSupplier
            // 
            this.txtSearchSupplier.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchSupplier.Location = new System.Drawing.Point(91, 10);
            this.txtSearchSupplier.Name = "txtSearchSupplier";
            this.txtSearchSupplier.Size = new System.Drawing.Size(247, 26);
            this.txtSearchSupplier.TabIndex = 2;
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
            this.pnlEntry.Controls.Add(this.tbSupplier);
            this.pnlEntry.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEntry.Location = new System.Drawing.Point(0, 207);
            this.pnlEntry.Name = "pnlEntry";
            this.pnlEntry.Padding = new System.Windows.Forms.Padding(5);
            this.pnlEntry.Size = new System.Drawing.Size(790, 300);
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
            this.pnlTitle.Size = new System.Drawing.Size(800, 38);
            this.pnlTitle.TabIndex = 164;
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
            this.lblTitle.Location = new System.Drawing.Point(14, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(71, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Supplier";
            // 
            // frmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.pnlMail);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSupplier";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier";
            this.tbSupplier.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.pnlMail.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblSupplierId;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TabControl tbSupplier;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMail;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Button btnKbEmail;
        private System.Windows.Forms.Button btnKbPhone;
        private System.Windows.Forms.Button btnKbAddress;
        private System.Windows.Forms.Button btnKbName;
        private System.Windows.Forms.DataGridView dgvSuppliers;
        private System.Windows.Forms.Panel pnlEntry;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnKbSearch;
        private System.Windows.Forms.TextBox txtSearchSupplier;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSupplierDown;
        private System.Windows.Forms.Button btnSupplierUp;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSupplierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmail;
    }
}