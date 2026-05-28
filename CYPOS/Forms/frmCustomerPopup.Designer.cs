namespace cypos
{
    partial class frmCustomerPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerPopup));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelectAndClose = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.clmId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCustomerUp = new System.Windows.Forms.Button();
            this.btnCustomerDown = new System.Windows.Forms.Button();
            this.btnKbCusEmail = new System.Windows.Forms.Button();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.btnKbCusPhone = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.btnKbCusCity = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.btnKbCusAddress = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnKbCusName = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.pnlButtons.SuspendLayout();
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
            this.pnlMain.Padding = new System.Windows.Forms.Padding(6, 0, 6, 5);
            this.pnlMain.Size = new System.Drawing.Size(800, 462);
            this.pnlMain.TabIndex = 164;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.lblCustomerId);
            this.pnlInner.Controls.Add(this.btnClose);
            this.pnlInner.Controls.Add(this.btnSelectAndClose);
            this.pnlInner.Controls.Add(this.pnlGrid);
            this.pnlInner.Controls.Add(this.btnKbCusEmail);
            this.pnlInner.Controls.Add(this.btnSaveAndClose);
            this.pnlInner.Controls.Add(this.label24);
            this.pnlInner.Controls.Add(this.btnKbCusPhone);
            this.pnlInner.Controls.Add(this.label32);
            this.pnlInner.Controls.Add(this.btnKbCusCity);
            this.pnlInner.Controls.Add(this.label31);
            this.pnlInner.Controls.Add(this.btnKbCusAddress);
            this.pnlInner.Controls.Add(this.txtAddress);
            this.pnlInner.Controls.Add(this.btnKbCusName);
            this.pnlInner.Controls.Add(this.txtEmail);
            this.pnlInner.Controls.Add(this.txtCity);
            this.pnlInner.Controls.Add(this.label25);
            this.pnlInner.Controls.Add(this.txtName);
            this.pnlInner.Controls.Add(this.txtPhone);
            this.pnlInner.Controls.Add(this.label27);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(6, 0);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Padding = new System.Windows.Forms.Padding(5);
            this.pnlInner.Size = new System.Drawing.Size(788, 457);
            this.pnlInner.TabIndex = 0;
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerId.Location = new System.Drawing.Point(62, 6);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(10, 13);
            this.lblCustomerId.TabIndex = 191;
            this.lblCustomerId.Text = "-";
            this.lblCustomerId.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::cypos.Properties.Resources.exit100x45;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(662, 128);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 45);
            this.btnClose.TabIndex = 190;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelectAndClose
            // 
            this.btnSelectAndClose.BackgroundImage = global::cypos.Properties.Resources.ok100x45;
            this.btnSelectAndClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAndClose.Location = new System.Drawing.Point(662, 80);
            this.btnSelectAndClose.Name = "btnSelectAndClose";
            this.btnSelectAndClose.Size = new System.Drawing.Size(117, 45);
            this.btnSelectAndClose.TabIndex = 189;
            this.btnSelectAndClose.UseVisualStyleBackColor = true;
            this.btnSelectAndClose.Click += new System.EventHandler(this.btnSelectAndClose_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvCustomers);
            this.pnlGrid.Controls.Add(this.pnlButtons);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlGrid.Location = new System.Drawing.Point(5, 180);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(778, 272);
            this.pnlGrid.TabIndex = 188;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AllowUserToResizeRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomers.ColumnHeadersHeight = 32;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmId,
            this.clmName,
            this.clmAddress,
            this.clmCity,
            this.clmPhone,
            this.clmEmail});
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(0, 0);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.RowTemplate.Height = 32;
            this.dgvCustomers.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(696, 272);
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            // 
            // clmId
            // 
            this.clmId.DataPropertyName = "id";
            this.clmId.HeaderText = "Id";
            this.clmId.Name = "clmId";
            this.clmId.ReadOnly = true;
            this.clmId.Visible = false;
            // 
            // clmName
            // 
            this.clmName.DataPropertyName = "name";
            this.clmName.HeaderText = "Customer";
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
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
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnRefresh);
            this.pnlButtons.Controls.Add(this.btnCustomerUp);
            this.pnlButtons.Controls.Add(this.btnCustomerDown);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtons.Location = new System.Drawing.Point(696, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(82, 272);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::cypos.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(3, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 55);
            this.btnRefresh.TabIndex = 104;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCustomerUp
            // 
            this.btnCustomerUp.Image = global::cypos.Properties.Resources.row_up;
            this.btnCustomerUp.Location = new System.Drawing.Point(3, 57);
            this.btnCustomerUp.Name = "btnCustomerUp";
            this.btnCustomerUp.Size = new System.Drawing.Size(75, 55);
            this.btnCustomerUp.TabIndex = 2;
            this.btnCustomerUp.UseVisualStyleBackColor = true;
            this.btnCustomerUp.Click += new System.EventHandler(this.btnCustomerUp_Click);
            // 
            // btnCustomerDown
            // 
            this.btnCustomerDown.Image = global::cypos.Properties.Resources.row_down;
            this.btnCustomerDown.Location = new System.Drawing.Point(3, 114);
            this.btnCustomerDown.Name = "btnCustomerDown";
            this.btnCustomerDown.Size = new System.Drawing.Size(75, 55);
            this.btnCustomerDown.TabIndex = 3;
            this.btnCustomerDown.UseVisualStyleBackColor = true;
            this.btnCustomerDown.Click += new System.EventHandler(this.btnCustomerDown_Click);
            // 
            // btnKbCusEmail
            // 
            this.btnKbCusEmail.FlatAppearance.BorderSize = 0;
            this.btnKbCusEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbCusEmail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbCusEmail.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbCusEmail.Location = new System.Drawing.Point(591, 132);
            this.btnKbCusEmail.Name = "btnKbCusEmail";
            this.btnKbCusEmail.Size = new System.Drawing.Size(58, 38);
            this.btnKbCusEmail.TabIndex = 187;
            this.btnKbCusEmail.UseVisualStyleBackColor = true;
            this.btnKbCusEmail.Click += new System.EventHandler(this.btnKbCusEmail_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.BackgroundImage = global::cypos.Properties.Resources.saveandclose;
            this.btnSaveAndClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.Location = new System.Drawing.Point(662, 21);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(117, 56);
            this.btnSaveAndClose.TabIndex = 186;
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(18, 6);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(42, 14);
            this.label24.TabIndex = 16;
            this.label24.Text = "Name:";
            // 
            // btnKbCusPhone
            // 
            this.btnKbCusPhone.FlatAppearance.BorderSize = 0;
            this.btnKbCusPhone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbCusPhone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbCusPhone.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbCusPhone.Location = new System.Drawing.Point(591, 24);
            this.btnKbCusPhone.Name = "btnKbCusPhone";
            this.btnKbCusPhone.Size = new System.Drawing.Size(58, 38);
            this.btnKbCusPhone.TabIndex = 175;
            this.btnKbCusPhone.UseVisualStyleBackColor = true;
            this.btnKbCusPhone.Click += new System.EventHandler(this.btnKbCusPhone_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(18, 117);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(31, 14);
            this.label32.TabIndex = 22;
            this.label32.Text = "City:";
            // 
            // btnKbCusCity
            // 
            this.btnKbCusCity.FlatAppearance.BorderSize = 0;
            this.btnKbCusCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbCusCity.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbCusCity.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbCusCity.Location = new System.Drawing.Point(272, 132);
            this.btnKbCusCity.Name = "btnKbCusCity";
            this.btnKbCusCity.Size = new System.Drawing.Size(58, 38);
            this.btnKbCusCity.TabIndex = 174;
            this.btnKbCusCity.UseVisualStyleBackColor = true;
            this.btnKbCusCity.Click += new System.EventHandler(this.btnKbCusCity_Click);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(18, 59);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(102, 14);
            this.label31.TabIndex = 17;
            this.label31.Text = "Address / Street:";
            // 
            // btnKbCusAddress
            // 
            this.btnKbCusAddress.FlatAppearance.BorderSize = 0;
            this.btnKbCusAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbCusAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbCusAddress.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbCusAddress.Location = new System.Drawing.Point(591, 77);
            this.btnKbCusAddress.Name = "btnKbCusAddress";
            this.btnKbCusAddress.Size = new System.Drawing.Size(58, 38);
            this.btnKbCusAddress.TabIndex = 173;
            this.btnKbCusAddress.UseVisualStyleBackColor = true;
            this.btnKbCusAddress.Click += new System.EventHandler(this.btnKbCusAddress_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(18, 80);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(568, 30);
            this.txtAddress.TabIndex = 21;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtCustomerAddress_TextChanged);
            // 
            // btnKbCusName
            // 
            this.btnKbCusName.FlatAppearance.BorderSize = 0;
            this.btnKbCusName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbCusName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbCusName.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbCusName.Location = new System.Drawing.Point(272, 21);
            this.btnKbCusName.Name = "btnKbCusName";
            this.btnKbCusName.Size = new System.Drawing.Size(58, 38);
            this.btnKbCusName.TabIndex = 172;
            this.btnKbCusName.UseVisualStyleBackColor = true;
            this.btnKbCusName.Click += new System.EventHandler(this.btnKbCusName_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(336, 136);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 30);
            this.txtEmail.TabIndex = 18;
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(18, 136);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(250, 30);
            this.txtCity.TabIndex = 20;
            this.txtCity.TextChanged += new System.EventHandler(this.txtCity_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(336, 116);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 14);
            this.label25.TabIndex = 23;
            this.label25.Text = "Email:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(18, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 30);
            this.txtName.TabIndex = 14;
            this.txtName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(336, 26);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 30);
            this.txtPhone.TabIndex = 15;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(336, 6);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(46, 14);
            this.label27.TabIndex = 19;
            this.label27.Text = "Phone:";
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
            this.pnlTitle.TabIndex = 165;
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
            this.lblTitle.Text = "Customer";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // frmCustomerPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomerPopup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.frmCustomerPopup_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.pnlInner.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.pnlButtons.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Button btnCustomerDown;
        private System.Windows.Forms.Button btnCustomerUp;
        private System.Windows.Forms.Button btnKbCusEmail;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Button btnKbCusPhone;
        private System.Windows.Forms.Button btnKbCusCity;
        private System.Windows.Forms.Button btnKbCusAddress;
        private System.Windows.Forms.Button btnKbCusName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSelectAndClose;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmail;
    }
}