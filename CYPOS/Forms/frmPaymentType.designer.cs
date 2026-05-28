namespace cypos
{
    partial class frmPaymentType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaymentType));
            this.lblPayTypeId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPayType = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlPayTypeList = new System.Windows.Forms.Panel();
            this.pnlFloPanel = new System.Windows.Forms.Panel();
            this.floPayTypeList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlLeftInner = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnKbPayType = new System.Windows.Forms.Button();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlPayTypeList.SuspendLayout();
            this.pnlFloPanel.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlLeftInner.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPayTypeId
            // 
            this.lblPayTypeId.AutoSize = true;
            this.lblPayTypeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.lblPayTypeId.Location = new System.Drawing.Point(119, 65);
            this.lblPayTypeId.Name = "lblPayTypeId";
            this.lblPayTypeId.Size = new System.Drawing.Size(8, 12);
            this.lblPayTypeId.TabIndex = 1;
            this.lblPayTypeId.Text = "-";
            this.lblPayTypeId.Visible = false;
            this.lblPayTypeId.TextChanged += new System.EventHandler(this.lblTableId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Payment Type:";
            // 
            // txtPayType
            // 
            this.txtPayType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayType.Location = new System.Drawing.Point(15, 86);
            this.txtPayType.Name = "txtPayType";
            this.txtPayType.Size = new System.Drawing.Size(250, 23);
            this.txtPayType.TabIndex = 1;
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
            this.pnlMain.Size = new System.Drawing.Size(725, 362);
            this.pnlMain.TabIndex = 163;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlRight.Controls.Add(this.pnlPayTypeList);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(356, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlRight.Size = new System.Drawing.Size(364, 357);
            this.pnlRight.TabIndex = 155;
            // 
            // pnlPayTypeList
            // 
            this.pnlPayTypeList.Controls.Add(this.pnlFloPanel);
            this.pnlPayTypeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPayTypeList.Location = new System.Drawing.Point(6, 5);
            this.pnlPayTypeList.Name = "pnlPayTypeList";
            this.pnlPayTypeList.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlPayTypeList.Size = new System.Drawing.Size(352, 347);
            this.pnlPayTypeList.TabIndex = 146;
            // 
            // pnlFloPanel
            // 
            this.pnlFloPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFloPanel.Controls.Add(this.floPayTypeList);
            this.pnlFloPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFloPanel.Location = new System.Drawing.Point(0, 5);
            this.pnlFloPanel.Name = "pnlFloPanel";
            this.pnlFloPanel.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFloPanel.Size = new System.Drawing.Size(352, 342);
            this.pnlFloPanel.TabIndex = 7;
            // 
            // floPayTypeList
            // 
            this.floPayTypeList.AutoScroll = true;
            this.floPayTypeList.BackColor = System.Drawing.Color.Transparent;
            this.floPayTypeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floPayTypeList.Location = new System.Drawing.Point(6, 5);
            this.floPayTypeList.Name = "floPayTypeList";
            this.floPayTypeList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.floPayTypeList.Size = new System.Drawing.Size(338, 330);
            this.floPayTypeList.TabIndex = 5;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlLeft.Controls.Add(this.pnlLeftInner);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(5, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlLeft.Size = new System.Drawing.Size(351, 357);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlLeftInner
            // 
            this.pnlLeftInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeftInner.Controls.Add(this.btnSave);
            this.pnlLeftInner.Controls.Add(this.btnClear);
            this.pnlLeftInner.Controls.Add(this.btnExit);
            this.pnlLeftInner.Controls.Add(this.label1);
            this.pnlLeftInner.Controls.Add(this.btnDelete);
            this.pnlLeftInner.Controls.Add(this.lblPayTypeId);
            this.pnlLeftInner.Controls.Add(this.btnKbPayType);
            this.pnlLeftInner.Controls.Add(this.txtPayType);
            this.pnlLeftInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftInner.Location = new System.Drawing.Point(6, 5);
            this.pnlLeftInner.Name = "pnlLeftInner";
            this.pnlLeftInner.Size = new System.Drawing.Size(339, 347);
            this.pnlLeftInner.TabIndex = 172;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::cypos.Properties.Resources.save100x45;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(77, 225);
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
            this.btnClear.Location = new System.Drawing.Point(77, 277);
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
            this.btnExit.Location = new System.Drawing.Point(200, 277);
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
            this.btnDelete.Location = new System.Drawing.Point(200, 225);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 45);
            this.btnDelete.TabIndex = 182;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnKbPayType
            // 
            this.btnKbPayType.FlatAppearance.BorderSize = 0;
            this.btnKbPayType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbPayType.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbPayType.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbPayType.Location = new System.Drawing.Point(271, 78);
            this.btnKbPayType.Name = "btnKbPayType";
            this.btnKbPayType.Size = new System.Drawing.Size(58, 38);
            this.btnKbPayType.TabIndex = 159;
            this.btnKbPayType.UseVisualStyleBackColor = true;
            this.btnKbPayType.Click += new System.EventHandler(this.btnKbPayType_Click);
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
            this.pnlTitle.Size = new System.Drawing.Size(725, 38);
            this.pnlTitle.TabIndex = 162;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(690, 3);
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
            this.lblTitle.Size = new System.Drawing.Size(121, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Payment Types";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // frmPaymentType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 400);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPaymentType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Table";
            this.Load += new System.EventHandler(this.frmTableLocation_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlPayTypeList.ResumeLayout(false);
            this.pnlFloPanel.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeftInner.ResumeLayout(false);
            this.pnlLeftInner.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPayTypeId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPayType;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlPayTypeList;
        private System.Windows.Forms.Panel pnlFloPanel;
        private System.Windows.Forms.FlowLayoutPanel floPayTypeList;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlLeftInner;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnKbPayType;
    }
}