namespace cypos
{
    partial class frmBackOffice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackOffice));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.btnPrinters = new System.Windows.Forms.Button();
            this.btnPaymentTypes = new System.Windows.Forms.Button();
            this.btnLocation = new System.Windows.Forms.Button();
            this.btnTables = new System.Windows.Forms.Button();
            this.btnCompany = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnModifiers = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnItems = new System.Windows.Forms.Button();
            this.btnExpenseGroup = new System.Windows.Forms.Button();
            this.btnDatabase = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnExpenses = new System.Windows.Forms.Button();
            this.btnKitchenDisplay = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
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
            this.pnlMain.Size = new System.Drawing.Size(571, 363);
            this.pnlMain.TabIndex = 164;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.btnPrinters);
            this.pnlInner.Controls.Add(this.btnPaymentTypes);
            this.pnlInner.Controls.Add(this.btnLocation);
            this.pnlInner.Controls.Add(this.btnTables);
            this.pnlInner.Controls.Add(this.btnCompany);
            this.pnlInner.Controls.Add(this.btnCustomer);
            this.pnlInner.Controls.Add(this.btnModifiers);
            this.pnlInner.Controls.Add(this.btnSupplier);
            this.pnlInner.Controls.Add(this.btnClose);
            this.pnlInner.Controls.Add(this.btnSettings);
            this.pnlInner.Controls.Add(this.btnItems);
            this.pnlInner.Controls.Add(this.btnExpenseGroup);
            this.pnlInner.Controls.Add(this.btnDatabase);
            this.pnlInner.Controls.Add(this.btnPurchase);
            this.pnlInner.Controls.Add(this.btnCategory);
            this.pnlInner.Controls.Add(this.btnExpenses);
            this.pnlInner.Controls.Add(this.btnKitchenDisplay);
            this.pnlInner.Controls.Add(this.btnPayments);
            this.pnlInner.Controls.Add(this.btnUsers);
            this.pnlInner.Controls.Add(this.btnReports);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(5, 0);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Size = new System.Drawing.Size(561, 358);
            this.pnlInner.TabIndex = 16;
            // 
            // btnPrinters
            // 
            this.btnPrinters.BackgroundImage = global::cypos.Properties.Resources.printers_bg;
            this.btnPrinters.Location = new System.Drawing.Point(20, 262);
            this.btnPrinters.Name = "btnPrinters";
            this.btnPrinters.Size = new System.Drawing.Size(100, 75);
            this.btnPrinters.TabIndex = 19;
            this.btnPrinters.UseVisualStyleBackColor = true;
            this.btnPrinters.Click += new System.EventHandler(this.btnPrinters_Click);
            // 
            // btnPaymentTypes
            // 
            this.btnPaymentTypes.BackgroundImage = global::cypos.Properties.Resources.paytype_bg;
            this.btnPaymentTypes.Location = new System.Drawing.Point(124, 100);
            this.btnPaymentTypes.Name = "btnPaymentTypes";
            this.btnPaymentTypes.Size = new System.Drawing.Size(100, 75);
            this.btnPaymentTypes.TabIndex = 18;
            this.btnPaymentTypes.UseVisualStyleBackColor = true;
            this.btnPaymentTypes.Click += new System.EventHandler(this.btnPaymentTypes_Click);
            // 
            // btnLocation
            // 
            this.btnLocation.BackgroundImage = global::cypos.Properties.Resources.location_bg;
            this.btnLocation.Location = new System.Drawing.Point(20, 100);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(100, 75);
            this.btnLocation.TabIndex = 17;
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // btnTables
            // 
            this.btnTables.BackgroundImage = global::cypos.Properties.Resources.tables_bg;
            this.btnTables.Location = new System.Drawing.Point(440, 19);
            this.btnTables.Name = "btnTables";
            this.btnTables.Size = new System.Drawing.Size(100, 75);
            this.btnTables.TabIndex = 16;
            this.btnTables.UseVisualStyleBackColor = true;
            this.btnTables.Click += new System.EventHandler(this.btnTables_Click);
            // 
            // btnCompany
            // 
            this.btnCompany.BackgroundImage = global::cypos.Properties.Resources.company;
            this.btnCompany.Location = new System.Drawing.Point(20, 19);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(100, 75);
            this.btnCompany.TabIndex = 0;
            this.btnCompany.UseVisualStyleBackColor = true;
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackgroundImage = global::cypos.Properties.Resources.customer_bg;
            this.btnCustomer.Location = new System.Drawing.Point(19, 181);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(100, 75);
            this.btnCustomer.TabIndex = 8;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnModifiers
            // 
            this.btnModifiers.BackgroundImage = global::cypos.Properties.Resources.modifier_bg;
            this.btnModifiers.Location = new System.Drawing.Point(335, 19);
            this.btnModifiers.Name = "btnModifiers";
            this.btnModifiers.Size = new System.Drawing.Size(100, 75);
            this.btnModifiers.TabIndex = 1;
            this.btnModifiers.UseVisualStyleBackColor = true;
            this.btnModifiers.Click += new System.EventHandler(this.btnModifiers_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackgroundImage = global::cypos.Properties.Resources.supplier_bg;
            this.btnSupplier.Location = new System.Drawing.Point(124, 181);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(100, 75);
            this.btnSupplier.TabIndex = 9;
            this.btnSupplier.UseVisualStyleBackColor = true;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::cypos.Properties.Resources.exit100x75_bg;
            this.btnClose.Location = new System.Drawing.Point(440, 262);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 75);
            this.btnClose.TabIndex = 15;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackgroundImage = global::cypos.Properties.Resources.settings_bg;
            this.btnSettings.Location = new System.Drawing.Point(441, 180);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(100, 75);
            this.btnSettings.TabIndex = 7;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnItems
            // 
            this.btnItems.BackgroundImage = global::cypos.Properties.Resources.items_bg;
            this.btnItems.Location = new System.Drawing.Point(229, 19);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(100, 75);
            this.btnItems.TabIndex = 2;
            this.btnItems.UseVisualStyleBackColor = true;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // btnExpenseGroup
            // 
            this.btnExpenseGroup.BackgroundImage = global::cypos.Properties.Resources.expense_group;
            this.btnExpenseGroup.Location = new System.Drawing.Point(229, 180);
            this.btnExpenseGroup.Name = "btnExpenseGroup";
            this.btnExpenseGroup.Size = new System.Drawing.Size(100, 75);
            this.btnExpenseGroup.TabIndex = 10;
            this.btnExpenseGroup.UseVisualStyleBackColor = true;
            this.btnExpenseGroup.Click += new System.EventHandler(this.btnExpenseGroup_Click);
            // 
            // btnDatabase
            // 
            this.btnDatabase.BackgroundImage = global::cypos.Properties.Resources.databse_bg;
            this.btnDatabase.Location = new System.Drawing.Point(335, 262);
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.Size = new System.Drawing.Size(100, 75);
            this.btnDatabase.TabIndex = 14;
            this.btnDatabase.UseVisualStyleBackColor = true;
            this.btnDatabase.Click += new System.EventHandler(this.btnDatabase_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.BackgroundImage = global::cypos.Properties.Resources.purchase_bg;
            this.btnPurchase.Location = new System.Drawing.Point(440, 100);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(100, 75);
            this.btnPurchase.TabIndex = 6;
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.BackgroundImage = global::cypos.Properties.Resources.category_bg;
            this.btnCategory.Location = new System.Drawing.Point(124, 19);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(100, 75);
            this.btnCategory.TabIndex = 3;
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnExpenses
            // 
            this.btnExpenses.BackgroundImage = global::cypos.Properties.Resources.expenses_bg;
            this.btnExpenses.Location = new System.Drawing.Point(335, 180);
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.Size = new System.Drawing.Size(100, 75);
            this.btnExpenses.TabIndex = 11;
            this.btnExpenses.UseVisualStyleBackColor = true;
            this.btnExpenses.Click += new System.EventHandler(this.btnExpenses_Click);
            // 
            // btnKitchenDisplay
            // 
            this.btnKitchenDisplay.BackgroundImage = global::cypos.Properties.Resources.kitchen_display_bg;
            this.btnKitchenDisplay.Location = new System.Drawing.Point(229, 261);
            this.btnKitchenDisplay.Name = "btnKitchenDisplay";
            this.btnKitchenDisplay.Size = new System.Drawing.Size(100, 75);
            this.btnKitchenDisplay.TabIndex = 13;
            this.btnKitchenDisplay.UseVisualStyleBackColor = true;
            this.btnKitchenDisplay.Click += new System.EventHandler(this.btnKitchenDisplay_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.BackgroundImage = global::cypos.Properties.Resources.payments_bg;
            this.btnPayments.Location = new System.Drawing.Point(335, 100);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(100, 75);
            this.btnPayments.TabIndex = 5;
            this.btnPayments.UseVisualStyleBackColor = true;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackgroundImage = global::cypos.Properties.Resources.users_bg;
            this.btnUsers.Location = new System.Drawing.Point(229, 100);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(100, 75);
            this.btnUsers.TabIndex = 4;
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackgroundImage = global::cypos.Properties.Resources.reports_bg;
            this.btnReports.Location = new System.Drawing.Point(124, 261);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(100, 75);
            this.btnReports.TabIndex = 12;
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackgroundImage = global::cypos.Properties.Resources.title_bg;
            this.pnlTitle.Controls.Add(this.pbxClose);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Padding = new System.Windows.Forms.Padding(3);
            this.pnlTitle.Size = new System.Drawing.Size(571, 38);
            this.pnlTitle.TabIndex = 163;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(536, 3);
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
            this.lblTitle.Size = new System.Drawing.Size(94, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Back Office";
            // 
            // frmBackOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 401);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackOffice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Back Office";
            this.Load += new System.EventHandler(this.frmBackOffice_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCompany;
        private System.Windows.Forms.Button btnModifiers;
        private System.Windows.Forms.Button btnItems;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnExpenses;
        private System.Windows.Forms.Button btnExpenseGroup;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDatabase;
        private System.Windows.Forms.Button btnKitchenDisplay;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Button btnPaymentTypes;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.Button btnTables;
        private System.Windows.Forms.Button btnPrinters;
    }
}