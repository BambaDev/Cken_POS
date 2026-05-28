namespace cypos
{
    partial class frmDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatabase));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpTransaction = new System.Windows.Forms.GroupBox();
            this.cbxExpenses = new System.Windows.Forms.CheckBox();
            this.cbxPurchases = new System.Windows.Forms.CheckBox();
            this.cbxInvoices = new System.Windows.Forms.CheckBox();
            this.btnTruncate = new System.Windows.Forms.Button();
            this.grpMasters = new System.Windows.Forms.GroupBox();
            this.cbxCustomers = new System.Windows.Forms.CheckBox();
            this.cbxSuppliers = new System.Windows.Forms.CheckBox();
            this.cbxTableLocation = new System.Windows.Forms.CheckBox();
            this.cbxTables = new System.Windows.Forms.CheckBox();
            this.cbxItem = new System.Windows.Forms.CheckBox();
            this.cbxCategory = new System.Windows.Forms.CheckBox();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpTransaction.SuspendLayout();
            this.grpMasters.SuspendLayout();
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
            this.pnlTitle.Size = new System.Drawing.Size(541, 38);
            this.pnlTitle.TabIndex = 161;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(506, 3);
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
            this.lblTitle.Location = new System.Drawing.Point(14, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(177, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Database Management";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6, 0, 6, 5);
            this.panel1.Size = new System.Drawing.Size(541, 320);
            this.panel1.TabIndex = 162;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(529, 315);
            this.panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpTransaction);
            this.groupBox1.Controls.Add(this.btnTruncate);
            this.groupBox1.Controls.Add(this.grpMasters);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 294);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reset Database";
            // 
            // grpTransaction
            // 
            this.grpTransaction.Controls.Add(this.cbxExpenses);
            this.grpTransaction.Controls.Add(this.cbxPurchases);
            this.grpTransaction.Controls.Add(this.cbxInvoices);
            this.grpTransaction.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTransaction.Location = new System.Drawing.Point(261, 25);
            this.grpTransaction.Name = "grpTransaction";
            this.grpTransaction.Size = new System.Drawing.Size(219, 192);
            this.grpTransaction.TabIndex = 1;
            this.grpTransaction.TabStop = false;
            this.grpTransaction.Text = "Transaction";
            // 
            // cbxExpenses
            // 
            this.cbxExpenses.AutoSize = true;
            this.cbxExpenses.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxExpenses.Location = new System.Drawing.Point(19, 76);
            this.cbxExpenses.Name = "cbxExpenses";
            this.cbxExpenses.Size = new System.Drawing.Size(77, 18);
            this.cbxExpenses.TabIndex = 14;
            this.cbxExpenses.Text = "Expenses";
            this.cbxExpenses.UseVisualStyleBackColor = true;
            // 
            // cbxPurchases
            // 
            this.cbxPurchases.AutoSize = true;
            this.cbxPurchases.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPurchases.Location = new System.Drawing.Point(19, 48);
            this.cbxPurchases.Name = "cbxPurchases";
            this.cbxPurchases.Size = new System.Drawing.Size(80, 18);
            this.cbxPurchases.TabIndex = 13;
            this.cbxPurchases.Text = "Purchases";
            this.cbxPurchases.UseVisualStyleBackColor = true;
            // 
            // cbxInvoices
            // 
            this.cbxInvoices.AutoSize = true;
            this.cbxInvoices.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxInvoices.Location = new System.Drawing.Point(19, 23);
            this.cbxInvoices.Name = "cbxInvoices";
            this.cbxInvoices.Size = new System.Drawing.Size(70, 18);
            this.cbxInvoices.TabIndex = 12;
            this.cbxInvoices.Text = "Invoices";
            this.cbxInvoices.UseVisualStyleBackColor = true;
            // 
            // btnTruncate
            // 
            this.btnTruncate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTruncate.Location = new System.Drawing.Point(344, 231);
            this.btnTruncate.Name = "btnTruncate";
            this.btnTruncate.Size = new System.Drawing.Size(136, 52);
            this.btnTruncate.TabIndex = 10;
            this.btnTruncate.Text = "Truncate selected\r\nTable";
            this.btnTruncate.UseVisualStyleBackColor = true;
            this.btnTruncate.Click += new System.EventHandler(this.btnTruncate_Click);
            // 
            // grpMasters
            // 
            this.grpMasters.Controls.Add(this.cbxCustomers);
            this.grpMasters.Controls.Add(this.cbxSuppliers);
            this.grpMasters.Controls.Add(this.cbxTableLocation);
            this.grpMasters.Controls.Add(this.cbxTables);
            this.grpMasters.Controls.Add(this.cbxItem);
            this.grpMasters.Controls.Add(this.cbxCategory);
            this.grpMasters.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMasters.Location = new System.Drawing.Point(24, 25);
            this.grpMasters.Name = "grpMasters";
            this.grpMasters.Size = new System.Drawing.Size(219, 192);
            this.grpMasters.TabIndex = 0;
            this.grpMasters.TabStop = false;
            this.grpMasters.Text = "Master Files";
            // 
            // cbxCustomers
            // 
            this.cbxCustomers.AutoSize = true;
            this.cbxCustomers.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCustomers.Location = new System.Drawing.Point(19, 163);
            this.cbxCustomers.Name = "cbxCustomers";
            this.cbxCustomers.Size = new System.Drawing.Size(83, 18);
            this.cbxCustomers.TabIndex = 16;
            this.cbxCustomers.Text = "Customers";
            this.cbxCustomers.UseVisualStyleBackColor = true;
            // 
            // cbxSuppliers
            // 
            this.cbxSuppliers.AutoSize = true;
            this.cbxSuppliers.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSuppliers.Location = new System.Drawing.Point(19, 135);
            this.cbxSuppliers.Name = "cbxSuppliers";
            this.cbxSuppliers.Size = new System.Drawing.Size(74, 18);
            this.cbxSuppliers.TabIndex = 15;
            this.cbxSuppliers.Text = "Suppliers";
            this.cbxSuppliers.UseVisualStyleBackColor = true;
            // 
            // cbxTableLocation
            // 
            this.cbxTableLocation.AutoSize = true;
            this.cbxTableLocation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTableLocation.Location = new System.Drawing.Point(19, 107);
            this.cbxTableLocation.Name = "cbxTableLocation";
            this.cbxTableLocation.Size = new System.Drawing.Size(111, 18);
            this.cbxTableLocation.TabIndex = 14;
            this.cbxTableLocation.Text = "Table Locations";
            this.cbxTableLocation.UseVisualStyleBackColor = true;
            // 
            // cbxTables
            // 
            this.cbxTables.AutoSize = true;
            this.cbxTables.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTables.Location = new System.Drawing.Point(19, 79);
            this.cbxTables.Name = "cbxTables";
            this.cbxTables.Size = new System.Drawing.Size(61, 18);
            this.cbxTables.TabIndex = 13;
            this.cbxTables.Text = "Tables";
            this.cbxTables.UseVisualStyleBackColor = true;
            // 
            // cbxItem
            // 
            this.cbxItem.AutoSize = true;
            this.cbxItem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxItem.Location = new System.Drawing.Point(19, 23);
            this.cbxItem.Name = "cbxItem";
            this.cbxItem.Size = new System.Drawing.Size(128, 18);
            this.cbxItem.TabIndex = 12;
            this.cbxItem.Text = "Item and modifiers";
            this.cbxItem.UseVisualStyleBackColor = true;
            // 
            // cbxCategory
            // 
            this.cbxCategory.AutoSize = true;
            this.cbxCategory.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCategory.Location = new System.Drawing.Point(19, 51);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(75, 18);
            this.cbxCategory.TabIndex = 11;
            this.cbxCategory.Text = "Category";
            this.cbxCategory.UseVisualStyleBackColor = true;
            // 
            // frmDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 358);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Management";
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpTransaction.ResumeLayout(false);
            this.grpTransaction.PerformLayout();
            this.grpMasters.ResumeLayout(false);
            this.grpMasters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTruncate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpMasters;
        private System.Windows.Forms.CheckBox cbxItem;
        private System.Windows.Forms.CheckBox cbxCategory;
        private System.Windows.Forms.CheckBox cbxSuppliers;
        private System.Windows.Forms.CheckBox cbxTableLocation;
        private System.Windows.Forms.CheckBox cbxTables;
        private System.Windows.Forms.CheckBox cbxCustomers;
        private System.Windows.Forms.GroupBox grpTransaction;
        private System.Windows.Forms.CheckBox cbxExpenses;
        private System.Windows.Forms.CheckBox cbxPurchases;
        private System.Windows.Forms.CheckBox cbxInvoices;
    }
}