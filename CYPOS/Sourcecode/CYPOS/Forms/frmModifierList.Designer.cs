namespace cypos
{
    partial class frmModifierList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifierList));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.tbModifier = new System.Windows.Forms.TabControl();
            this.tpItemModifier = new System.Windows.Forms.TabPage();
            this.floItemModifier = new System.Windows.Forms.FlowLayoutPanel();
            this.tpAllModifier = new System.Windows.Forms.TabPage();
            this.floAllModifier = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.tbModifier.SuspendLayout();
            this.tpItemModifier.SuspendLayout();
            this.tpAllModifier.SuspendLayout();
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
            this.pnlTitle.Size = new System.Drawing.Size(734, 38);
            this.pnlTitle.TabIndex = 163;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(699, 3);
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
            this.lblTitle.Size = new System.Drawing.Size(103, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Modifier List";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlInner);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 38);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlMain.Size = new System.Drawing.Size(734, 424);
            this.pnlMain.TabIndex = 164;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.tbModifier);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(5, 0);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Padding = new System.Windows.Forms.Padding(5);
            this.pnlInner.Size = new System.Drawing.Size(724, 419);
            this.pnlInner.TabIndex = 0;
            // 
            // tbModifier
            // 
            this.tbModifier.Controls.Add(this.tpItemModifier);
            this.tbModifier.Controls.Add(this.tpAllModifier);
            this.tbModifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbModifier.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbModifier.ItemSize = new System.Drawing.Size(150, 45);
            this.tbModifier.Location = new System.Drawing.Point(5, 5);
            this.tbModifier.Name = "tbModifier";
            this.tbModifier.SelectedIndex = 0;
            this.tbModifier.Size = new System.Drawing.Size(714, 409);
            this.tbModifier.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbModifier.TabIndex = 2;
            // 
            // tpItemModifier
            // 
            this.tpItemModifier.Controls.Add(this.floItemModifier);
            this.tpItemModifier.Location = new System.Drawing.Point(4, 49);
            this.tpItemModifier.Name = "tpItemModifier";
            this.tpItemModifier.Size = new System.Drawing.Size(706, 356);
            this.tpItemModifier.TabIndex = 0;
            this.tpItemModifier.Text = "Item Modifier";
            this.tpItemModifier.UseVisualStyleBackColor = true;
            // 
            // floItemModifier
            // 
            this.floItemModifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floItemModifier.Location = new System.Drawing.Point(0, 0);
            this.floItemModifier.Name = "floItemModifier";
            this.floItemModifier.Padding = new System.Windows.Forms.Padding(5);
            this.floItemModifier.Size = new System.Drawing.Size(706, 356);
            this.floItemModifier.TabIndex = 0;
            // 
            // tpAllModifier
            // 
            this.tpAllModifier.Controls.Add(this.floAllModifier);
            this.tpAllModifier.Location = new System.Drawing.Point(4, 49);
            this.tpAllModifier.Name = "tpAllModifier";
            this.tpAllModifier.Size = new System.Drawing.Size(706, 356);
            this.tpAllModifier.TabIndex = 1;
            this.tpAllModifier.Text = "All Modifiers";
            this.tpAllModifier.UseVisualStyleBackColor = true;
            // 
            // floAllModifier
            // 
            this.floAllModifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floAllModifier.Location = new System.Drawing.Point(0, 0);
            this.floAllModifier.Name = "floAllModifier";
            this.floAllModifier.Padding = new System.Windows.Forms.Padding(5);
            this.floAllModifier.Size = new System.Drawing.Size(706, 356);
            this.floAllModifier.TabIndex = 0;
            // 
            // frmModifierList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(734, 462);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmModifierList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifier List";
            this.Load += new System.EventHandler(this.frmModifierList_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.tbModifier.ResumeLayout(false);
            this.tpItemModifier.ResumeLayout(false);
            this.tpAllModifier.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.TabControl tbModifier;
        private System.Windows.Forms.TabPage tpItemModifier;
        private System.Windows.Forms.FlowLayoutPanel floItemModifier;
        private System.Windows.Forms.TabPage tpAllModifier;
        private System.Windows.Forms.FlowLayoutPanel floAllModifier;
    }
}