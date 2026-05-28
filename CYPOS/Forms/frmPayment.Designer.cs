namespace cypos
{
    partial class frmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.btnExact = new System.Windows.Forms.Button();
            this.lblPaymentType = new System.Windows.Forms.Label();
            this.btnSaveOnly = new System.Windows.Forms.Button();
            this.btnAvoid = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPayable = new System.Windows.Forms.Label();
            this.btnKbNote = new System.Windows.Forms.Button();
            this.pnlPayType = new System.Windows.Forms.Panel();
            this.floPaymentTypes = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.moneyPad1 = new cypos.MoneyPad();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblChangeAmount = new System.Windows.Forms.Label();
            this.lblDueAmount = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.pnlPayType.SuspendLayout();
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
            this.pnlMain.Padding = new System.Windows.Forms.Padding(4, 0, 4, 5);
            this.pnlMain.Size = new System.Drawing.Size(784, 427);
            this.pnlMain.TabIndex = 166;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.btnExact);
            this.pnlInner.Controls.Add(this.lblPaymentType);
            this.pnlInner.Controls.Add(this.btnSaveOnly);
            this.pnlInner.Controls.Add(this.btnAvoid);
            this.pnlInner.Controls.Add(this.label14);
            this.pnlInner.Controls.Add(this.lblPayable);
            this.pnlInner.Controls.Add(this.btnKbNote);
            this.pnlInner.Controls.Add(this.pnlPayType);
            this.pnlInner.Controls.Add(this.btnPrint);
            this.pnlInner.Controls.Add(this.moneyPad1);
            this.pnlInner.Controls.Add(this.label20);
            this.pnlInner.Controls.Add(this.label19);
            this.pnlInner.Controls.Add(this.label34);
            this.pnlInner.Controls.Add(this.label18);
            this.pnlInner.Controls.Add(this.txtNote);
            this.pnlInner.Controls.Add(this.dtpDate);
            this.pnlInner.Controls.Add(this.txtPaidAmount);
            this.pnlInner.Controls.Add(this.label6);
            this.pnlInner.Controls.Add(this.lblChangeAmount);
            this.pnlInner.Controls.Add(this.lblDueAmount);
            this.pnlInner.Controls.Add(this.label26);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(4, 0);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Size = new System.Drawing.Size(776, 422);
            this.pnlInner.TabIndex = 0;
            // 
            // btnExact
            // 
            this.btnExact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnExact.FlatAppearance.BorderSize = 0;
            this.btnExact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExact.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExact.ForeColor = System.Drawing.Color.Yellow;
            this.btnExact.Location = new System.Drawing.Point(353, 312);
            this.btnExact.Name = "btnExact";
            this.btnExact.Size = new System.Drawing.Size(161, 56);
            this.btnExact.TabIndex = 215;
            this.btnExact.Text = "Exact";
            this.btnExact.UseVisualStyleBackColor = false;
            this.btnExact.Click += new System.EventHandler(this.btnExact_Click);
            // 
            // lblPaymentType
            // 
            this.lblPaymentType.AutoSize = true;
            this.lblPaymentType.BackColor = System.Drawing.Color.Transparent;
            this.lblPaymentType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentType.ForeColor = System.Drawing.Color.Black;
            this.lblPaymentType.Location = new System.Drawing.Point(119, 127);
            this.lblPaymentType.Name = "lblPaymentType";
            this.lblPaymentType.Size = new System.Drawing.Size(15, 19);
            this.lblPaymentType.TabIndex = 214;
            this.lblPaymentType.Text = "-";
            // 
            // btnSaveOnly
            // 
            this.btnSaveOnly.BackgroundImage = global::cypos.Properties.Resources.saveonly_bg;
            this.btnSaveOnly.Location = new System.Drawing.Point(520, 311);
            this.btnSaveOnly.Name = "btnSaveOnly";
            this.btnSaveOnly.Size = new System.Drawing.Size(120, 50);
            this.btnSaveOnly.TabIndex = 205;
            this.btnSaveOnly.UseVisualStyleBackColor = true;
            this.btnSaveOnly.Click += new System.EventHandler(this.btnSaveOnly_Click);
            // 
            // btnAvoid
            // 
            this.btnAvoid.BackgroundImage = global::cypos.Properties.Resources.avoid_bg;
            this.btnAvoid.Location = new System.Drawing.Point(520, 363);
            this.btnAvoid.Name = "btnAvoid";
            this.btnAvoid.Size = new System.Drawing.Size(120, 50);
            this.btnAvoid.TabIndex = 203;
            this.btnAvoid.UseVisualStyleBackColor = true;
            this.btnAvoid.Click += new System.EventHandler(this.btnAvoid_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(10, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 19);
            this.label14.TabIndex = 177;
            this.label14.Text = "Total Payable:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPayable
            // 
            this.lblPayable.BackColor = System.Drawing.Color.Transparent;
            this.lblPayable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPayable.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayable.ForeColor = System.Drawing.Color.Red;
            this.lblPayable.Location = new System.Drawing.Point(126, 12);
            this.lblPayable.Name = "lblPayable";
            this.lblPayable.Size = new System.Drawing.Size(211, 32);
            this.lblPayable.TabIndex = 178;
            this.lblPayable.Text = "00";
            this.lblPayable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnKbNote
            // 
            this.btnKbNote.FlatAppearance.BorderSize = 0;
            this.btnKbNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbNote.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbNote.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbNote.Location = new System.Drawing.Point(287, 375);
            this.btnKbNote.Name = "btnKbNote";
            this.btnKbNote.Size = new System.Drawing.Size(58, 38);
            this.btnKbNote.TabIndex = 213;
            this.btnKbNote.UseVisualStyleBackColor = true;
            this.btnKbNote.Click += new System.EventHandler(this.btnKbNote_Click);
            // 
            // pnlPayType
            // 
            this.pnlPayType.BackColor = System.Drawing.Color.Transparent;
            this.pnlPayType.Controls.Add(this.floPaymentTypes);
            this.pnlPayType.Location = new System.Drawing.Point(3, 151);
            this.pnlPayType.Name = "pnlPayType";
            this.pnlPayType.Padding = new System.Windows.Forms.Padding(5);
            this.pnlPayType.Size = new System.Drawing.Size(347, 124);
            this.pnlPayType.TabIndex = 212;
            // 
            // floPaymentTypes
            // 
            this.floPaymentTypes.AutoScroll = true;
            this.floPaymentTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floPaymentTypes.Location = new System.Drawing.Point(5, 5);
            this.floPaymentTypes.Name = "floPaymentTypes";
            this.floPaymentTypes.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.floPaymentTypes.Size = new System.Drawing.Size(337, 114);
            this.floPaymentTypes.TabIndex = 6;
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = global::cypos.Properties.Resources.print_bg;
            this.btnPrint.Location = new System.Drawing.Point(647, 311);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 102);
            this.btnPrint.TabIndex = 206;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // moneyPad1
            // 
            this.moneyPad1.BackColor = System.Drawing.Color.Transparent;
            this.moneyPad1.Location = new System.Drawing.Point(349, 12);
            this.moneyPad1.Name = "moneyPad1";
            this.moneyPad1.Size = new System.Drawing.Size(424, 304);
            this.moneyPad1.TabIndex = 211;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(187, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(130, 19);
            this.label20.TabIndex = 164;
            this.label20.Text = "Change Amount:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(10, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(107, 19);
            this.label19.TabIndex = 163;
            this.label19.Text = "Paid Amount:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(10, 353);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(48, 19);
            this.label34.TabIndex = 167;
            this.label34.Text = "Note:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(10, 127);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(103, 19);
            this.label18.TabIndex = 162;
            this.label18.Text = "Payment  By:";
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(10, 376);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(272, 33);
            this.txtNote.TabIndex = 6;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(186, 312);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(151, 30);
            this.dtpDate.TabIndex = 3;
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidAmount.Location = new System.Drawing.Point(10, 76);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(151, 33);
            this.txtPaidAmount.TabIndex = 0;
            this.txtPaidAmount.TextChanged += new System.EventHandler(this.txtPaidAmount_TextChanged);
            this.txtPaidAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPaidAmount_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(186, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 19);
            this.label6.TabIndex = 155;
            this.label6.Text = "Date:";
            // 
            // lblChangeAmount
            // 
            this.lblChangeAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblChangeAmount.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeAmount.ForeColor = System.Drawing.Color.Green;
            this.lblChangeAmount.Location = new System.Drawing.Point(187, 76);
            this.lblChangeAmount.Name = "lblChangeAmount";
            this.lblChangeAmount.Size = new System.Drawing.Size(150, 33);
            this.lblChangeAmount.TabIndex = 209;
            this.lblChangeAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDueAmount
            // 
            this.lblDueAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDueAmount.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueAmount.ForeColor = System.Drawing.Color.Red;
            this.lblDueAmount.Location = new System.Drawing.Point(10, 312);
            this.lblDueAmount.Name = "lblDueAmount";
            this.lblDueAmount.Size = new System.Drawing.Size(150, 29);
            this.lblDueAmount.TabIndex = 210;
            this.lblDueAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(10, 288);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(105, 19);
            this.label26.TabIndex = 166;
            this.label26.Text = "Due Amount:";
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
            this.pnlTitle.Size = new System.Drawing.Size(784, 38);
            this.pnlTitle.TabIndex = 167;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(749, 3);
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
            this.lblTitle.Size = new System.Drawing.Size(73, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Payment";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(784, 465);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPayment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.pnlInner.PerformLayout();
            this.pnlPayType.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Label lblPayable;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnSaveOnly;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnAvoid;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private MoneyPad moneyPad1;
        private System.Windows.Forms.Label lblDueAmount;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblChangeAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel pnlPayType;
        private System.Windows.Forms.Button btnKbNote;
        private System.Windows.Forms.FlowLayoutPanel floPaymentTypes;
        private System.Windows.Forms.Label lblPaymentType;
        private System.Windows.Forms.Button btnExact;

    }
}