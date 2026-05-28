namespace cypos
{
    partial class frmOpenTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpenTable));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.pnlGuest = new System.Windows.Forms.Panel();
            this.numberPad1 = new cypos.NumberPad();
            this.pnlWaiters = new System.Windows.Forms.Panel();
            this.floUserList = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGuestCount = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGuestCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTableNo = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.pnlGuest.SuspendLayout();
            this.pnlWaiters.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlInner);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 38);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlMain.Size = new System.Drawing.Size(600, 362);
            this.pnlMain.TabIndex = 164;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.pnlGuest);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(5, 0);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Padding = new System.Windows.Forms.Padding(10);
            this.pnlInner.Size = new System.Drawing.Size(590, 301);
            this.pnlInner.TabIndex = 12;
            // 
            // pnlGuest
            // 
            this.pnlGuest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGuest.Controls.Add(this.numberPad1);
            this.pnlGuest.Controls.Add(this.pnlWaiters);
            this.pnlGuest.Controls.Add(this.label1);
            this.pnlGuest.Controls.Add(this.txtGuestCount);
            this.pnlGuest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGuest.Location = new System.Drawing.Point(10, 10);
            this.pnlGuest.Name = "pnlGuest";
            this.pnlGuest.Padding = new System.Windows.Forms.Padding(1);
            this.pnlGuest.Size = new System.Drawing.Size(570, 281);
            this.pnlGuest.TabIndex = 165;
            // 
            // numberPad1
            // 
            this.numberPad1.BackColor = System.Drawing.Color.Transparent;
            this.numberPad1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberPad1.Location = new System.Drawing.Point(269, 14);
            this.numberPad1.Margin = new System.Windows.Forms.Padding(4);
            this.numberPad1.Name = "numberPad1";
            this.numberPad1.Size = new System.Drawing.Size(294, 260);
            this.numberPad1.TabIndex = 0;
            // 
            // pnlWaiters
            // 
            this.pnlWaiters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWaiters.Controls.Add(this.floUserList);
            this.pnlWaiters.Location = new System.Drawing.Point(5, 168);
            this.pnlWaiters.Name = "pnlWaiters";
            this.pnlWaiters.Padding = new System.Windows.Forms.Padding(5);
            this.pnlWaiters.Size = new System.Drawing.Size(243, 92);
            this.pnlWaiters.TabIndex = 7;
            // 
            // floUserList
            // 
            this.floUserList.AutoScroll = true;
            this.floUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floUserList.Location = new System.Drawing.Point(5, 5);
            this.floUserList.Name = "floUserList";
            this.floUserList.Size = new System.Drawing.Size(231, 80);
            this.floUserList.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of Guest(s):";
            // 
            // txtGuestCount
            // 
            this.txtGuestCount.Location = new System.Drawing.Point(34, 129);
            this.txtGuestCount.Name = "txtGuestCount";
            this.txtGuestCount.Size = new System.Drawing.Size(125, 23);
            this.txtGuestCount.TabIndex = 1;
            this.txtGuestCount.TextChanged += new System.EventHandler(this.txtGuestCount_TextChanged);
            this.txtGuestCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGuest_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblGuestCount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblTableNo);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 301);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 56);
            this.panel1.TabIndex = 13;
            // 
            // btnBack
            // 
            this.btnBack.BackgroundImage = global::cypos.Properties.Resources.back_bg;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBack.Location = new System.Drawing.Point(481, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 50);
            this.btnBack.TabIndex = 13;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(7, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Number of Guest (s):";
            // 
            // lblGuestCount
            // 
            this.lblGuestCount.AutoSize = true;
            this.lblGuestCount.BackColor = System.Drawing.Color.Transparent;
            this.lblGuestCount.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestCount.ForeColor = System.Drawing.Color.Green;
            this.lblGuestCount.Location = new System.Drawing.Point(142, 28);
            this.lblGuestCount.Name = "lblGuestCount";
            this.lblGuestCount.Size = new System.Drawing.Size(18, 18);
            this.lblGuestCount.TabIndex = 11;
            this.lblGuestCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Table#:";
            // 
            // lblTableNo
            // 
            this.lblTableNo.AutoSize = true;
            this.lblTableNo.BackColor = System.Drawing.Color.Transparent;
            this.lblTableNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableNo.ForeColor = System.Drawing.Color.Green;
            this.lblTableNo.Location = new System.Drawing.Point(67, 6);
            this.lblTableNo.Name = "lblTableNo";
            this.lblTableNo.Size = new System.Drawing.Size(61, 18);
            this.lblTableNo.TabIndex = 9;
            this.lblTableNo.Text = "Table#";
            // 
            // btnOk
            // 
            this.btnOk.BackgroundImage = global::cypos.Properties.Resources.ok24x24;
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOk.Location = new System.Drawing.Point(481, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 50);
            this.btnOk.TabIndex = 8;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            this.pnlTitle.Size = new System.Drawing.Size(600, 38);
            this.pnlTitle.TabIndex = 163;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(565, 3);
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
            this.lblTitle.Size = new System.Drawing.Size(203, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Enter Number of Guest (s)";
            // 
            // frmOpenTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmOpenTable";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Waiter";
            this.Load += new System.EventHandler(this.frmOpenTable_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.pnlGuest.ResumeLayout(false);
            this.pnlGuest.PerformLayout();
            this.pnlWaiters.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel floUserList;
        private System.Windows.Forms.Panel pnlWaiters;
        private NumberPad numberPad1;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGuestCount;
        private System.Windows.Forms.Panel pnlGuest;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTableNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblGuestCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBack;
    }
}