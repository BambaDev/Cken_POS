namespace cypos
{
    partial class frmDueInvoices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDueInvoices));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.pnlGridInner = new System.Windows.Forms.Panel();
            this.dgvDueInvoices = new System.Windows.Forms.DataGridView();
            this.clmInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDueAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnRowDown = new System.Windows.Forms.Button();
            this.btnRowUp = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pnlInnerSearch = new System.Windows.Forms.Panel();
            this.btnKeyBoard = new System.Windows.Forms.Button();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.pnlGridInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDueInvoices)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlInnerSearch.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.AutoCompleteCustomSource.AddRange(new string[] {
            "df",
            "dfdfdf",
            "wewe",
            "wewed",
            "yrt"});
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(100, 9);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(175, 24);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy";
            this.dtpInvoiceDate.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(337, 9);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(151, 26);
            this.dtpInvoiceDate.TabIndex = 1;
            this.dtpInvoiceDate.ValueChanged += new System.EventHandler(this.dtpInvoiceDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Invoice No.#:";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 38);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlMain.Size = new System.Drawing.Size(900, 462);
            this.pnlMain.TabIndex = 165;
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlGrid.Controls.Add(this.pnlGridInner);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(5, 57);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlGrid.Size = new System.Drawing.Size(890, 400);
            this.pnlGrid.TabIndex = 0;
            // 
            // pnlGridInner
            // 
            this.pnlGridInner.Controls.Add(this.dgvDueInvoices);
            this.pnlGridInner.Controls.Add(this.pnlButtons);
            this.pnlGridInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridInner.Location = new System.Drawing.Point(5, 0);
            this.pnlGridInner.Name = "pnlGridInner";
            this.pnlGridInner.Size = new System.Drawing.Size(880, 395);
            this.pnlGridInner.TabIndex = 0;
            // 
            // dgvDueInvoices
            // 
            this.dgvDueInvoices.AllowUserToAddRows = false;
            this.dgvDueInvoices.AllowUserToDeleteRows = false;
            this.dgvDueInvoices.AllowUserToResizeRows = false;
            this.dgvDueInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDueInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDueInvoices.ColumnHeadersHeight = 32;
            this.dgvDueInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDueInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmInvoiceNo,
            this.clmDate,
            this.clmCustomer,
            this.clmTotalAmount,
            this.clmPaidAmount,
            this.clmDueAmount});
            this.dgvDueInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDueInvoices.Location = new System.Drawing.Point(0, 0);
            this.dgvDueInvoices.MultiSelect = false;
            this.dgvDueInvoices.Name = "dgvDueInvoices";
            this.dgvDueInvoices.ReadOnly = true;
            this.dgvDueInvoices.RowHeadersVisible = false;
            this.dgvDueInvoices.RowTemplate.Height = 32;
            this.dgvDueInvoices.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDueInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDueInvoices.Size = new System.Drawing.Size(792, 395);
            this.dgvDueInvoices.TabIndex = 2;
            this.dgvDueInvoices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDueInvoices_CellClick);
            // 
            // clmInvoiceNo
            // 
            this.clmInvoiceNo.DataPropertyName = "invoice_id";
            this.clmInvoiceNo.HeaderText = "Invoice #";
            this.clmInvoiceNo.Name = "clmInvoiceNo";
            this.clmInvoiceNo.ReadOnly = true;
            // 
            // clmDate
            // 
            this.clmDate.DataPropertyName = "invoice_date";
            this.clmDate.HeaderText = "Date";
            this.clmDate.Name = "clmDate";
            this.clmDate.ReadOnly = true;
            // 
            // clmCustomer
            // 
            this.clmCustomer.DataPropertyName = "customer";
            this.clmCustomer.HeaderText = "Customer";
            this.clmCustomer.Name = "clmCustomer";
            this.clmCustomer.ReadOnly = true;
            // 
            // clmTotalAmount
            // 
            this.clmTotalAmount.DataPropertyName = "payment_amount";
            this.clmTotalAmount.HeaderText = "Total Amount";
            this.clmTotalAmount.Name = "clmTotalAmount";
            this.clmTotalAmount.ReadOnly = true;
            // 
            // clmPaidAmount
            // 
            this.clmPaidAmount.DataPropertyName = "paid_amount";
            this.clmPaidAmount.HeaderText = "Paid Amount";
            this.clmPaidAmount.Name = "clmPaidAmount";
            this.clmPaidAmount.ReadOnly = true;
            // 
            // clmDueAmount
            // 
            this.clmDueAmount.DataPropertyName = "due_amount";
            this.clmDueAmount.HeaderText = "Due Amount";
            this.clmDueAmount.Name = "clmDueAmount";
            this.clmDueAmount.ReadOnly = true;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnPay);
            this.pnlButtons.Controls.Add(this.btnRowDown);
            this.pnlButtons.Controls.Add(this.btnRowUp);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtons.Location = new System.Drawing.Point(792, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(88, 395);
            this.pnlButtons.TabIndex = 22;
            // 
            // btnPay
            // 
            this.btnPay.Image = global::cypos.Properties.Resources.money_dollar;
            this.btnPay.Location = new System.Drawing.Point(6, 120);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 55);
            this.btnPay.TabIndex = 4;
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnRowDown
            // 
            this.btnRowDown.Image = global::cypos.Properties.Resources.row_down;
            this.btnRowDown.Location = new System.Drawing.Point(6, 59);
            this.btnRowDown.Name = "btnRowDown";
            this.btnRowDown.Size = new System.Drawing.Size(75, 55);
            this.btnRowDown.TabIndex = 3;
            this.btnRowDown.UseVisualStyleBackColor = true;
            this.btnRowDown.Click += new System.EventHandler(this.btnRowDown_Click);
            // 
            // btnRowUp
            // 
            this.btnRowUp.Image = global::cypos.Properties.Resources.row_up;
            this.btnRowUp.Location = new System.Drawing.Point(6, 0);
            this.btnRowUp.Name = "btnRowUp";
            this.btnRowUp.Size = new System.Drawing.Size(75, 55);
            this.btnRowUp.TabIndex = 2;
            this.btnRowUp.UseVisualStyleBackColor = true;
            this.btnRowUp.Click += new System.EventHandler(this.btnRowUp_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlSearch.Controls.Add(this.pnlInnerSearch);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(5, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(5);
            this.pnlSearch.Size = new System.Drawing.Size(890, 57);
            this.pnlSearch.TabIndex = 0;
            // 
            // pnlInnerSearch
            // 
            this.pnlInnerSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInnerSearch.Controls.Add(this.btnKeyBoard);
            this.pnlInnerSearch.Controls.Add(this.dtpInvoiceDate);
            this.pnlInnerSearch.Controls.Add(this.txtSearch);
            this.pnlInnerSearch.Controls.Add(this.label1);
            this.pnlInnerSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInnerSearch.Location = new System.Drawing.Point(5, 5);
            this.pnlInnerSearch.Name = "pnlInnerSearch";
            this.pnlInnerSearch.Size = new System.Drawing.Size(880, 47);
            this.pnlInnerSearch.TabIndex = 0;
            // 
            // btnKeyBoard
            // 
            this.btnKeyBoard.FlatAppearance.BorderSize = 0;
            this.btnKeyBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyBoard.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKeyBoard.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKeyBoard.Location = new System.Drawing.Point(281, 5);
            this.btnKeyBoard.Name = "btnKeyBoard";
            this.btnKeyBoard.Size = new System.Drawing.Size(50, 35);
            this.btnKeyBoard.TabIndex = 158;
            this.btnKeyBoard.UseVisualStyleBackColor = true;
            this.btnKeyBoard.Click += new System.EventHandler(this.btnKeyBoard_Click);
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
            this.pnlTitle.TabIndex = 164;
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
            this.lblTitle.Location = new System.Drawing.Point(12, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(105, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Due Invoices";
            // 
            // frmDueInvoices
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDueInvoices";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Due Invoices";
            this.Load += new System.EventHandler(this.frmDueInvoices_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGridInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDueInvoices)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlInnerSearch.ResumeLayout(false);
            this.pnlInnerSearch.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlGridInner;
        private System.Windows.Forms.Panel pnlInnerSearch;
        private System.Windows.Forms.Button btnKeyBoard;
        private System.Windows.Forms.DataGridView dgvDueInvoices;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnRowDown;
        private System.Windows.Forms.Button btnRowUp;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDueAmount;
    }
}