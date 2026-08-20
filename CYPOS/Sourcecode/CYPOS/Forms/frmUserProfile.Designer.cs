namespace cypos
{
    partial class frmUserProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserProfile));
            this.btnChangePic = new System.Windows.Forms.Button();
            this.rdbUserRole = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserFullName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtuid = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblFileExtension = new System.Windows.Forms.Label();
            this.dtDob = new System.Windows.Forms.DateTimePicker();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnKbContact = new System.Windows.Forms.Button();
            this.btnKbEmail = new System.Windows.Forms.Button();
            this.btnKbAddress = new System.Windows.Forms.Button();
            this.btnKbName = new System.Windows.Forms.Button();
            this.pnlItemImage = new System.Windows.Forms.Panel();
            this.PicUserPhoto = new System.Windows.Forms.PictureBox();
            this.lblImageName = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlItemImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicUserPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChangePic
            // 
            this.btnChangePic.FlatAppearance.BorderSize = 0;
            this.btnChangePic.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnChangePic.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePic.Location = new System.Drawing.Point(20, 236);
            this.btnChangePic.Name = "btnChangePic";
            this.btnChangePic.Size = new System.Drawing.Size(233, 40);
            this.btnChangePic.TabIndex = 43;
            this.btnChangePic.Text = "Change Picture";
            this.btnChangePic.UseVisualStyleBackColor = false;
            this.btnChangePic.Click += new System.EventHandler(this.btnChangePic_Click);
            // 
            // rdbUserRole
            // 
            this.rdbUserRole.AutoSize = true;
            this.rdbUserRole.Checked = true;
            this.rdbUserRole.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbUserRole.Location = new System.Drawing.Point(22, 396);
            this.rdbUserRole.Name = "rdbUserRole";
            this.rdbUserRole.Size = new System.Drawing.Size(62, 20);
            this.rdbUserRole.TabIndex = 40;
            this.rdbUserRole.TabStop = true;
            this.rdbUserRole.Text = "Admin";
            this.rdbUserRole.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(19, 377);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 16);
            this.label11.TabIndex = 41;
            this.label11.Text = "Position (User Role)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 327);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 16);
            this.label9.TabIndex = 39;
            this.label9.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(18, 348);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(229, 23);
            this.txtPassword.TabIndex = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(18, 300);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(229, 23);
            this.txtUserName.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 16);
            this.label8.TabIndex = 36;
            this.label8.Text = "User Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label10.Location = new System.Drawing.Point(269, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 18);
            this.label10.TabIndex = 54;
            this.label10.Text = "Date Of Birth";
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.Location = new System.Drawing.Point(270, 238);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(282, 23);
            this.txtContact.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(269, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 16);
            this.label7.TabIndex = 52;
            this.label7.Text = "Contact";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(270, 178);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(282, 23);
            this.txtEmail.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(270, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 50;
            this.label6.Text = "Email:";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(271, 78);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(281, 76);
            this.txtAddress.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(268, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 48;
            this.label5.Text = "Address";
            // 
            // txtUserFullName
            // 
            this.txtUserFullName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserFullName.Location = new System.Drawing.Point(273, 29);
            this.txtUserFullName.Name = "txtUserFullName";
            this.txtUserFullName.Size = new System.Drawing.Size(279, 23);
            this.txtUserFullName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 44;
            this.label2.Text = "Full Name:";
            // 
            // txtuid
            // 
            this.txtuid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtuid.Location = new System.Drawing.Point(472, 288);
            this.txtuid.Name = "txtuid";
            this.txtuid.ReadOnly = true;
            this.txtuid.Size = new System.Drawing.Size(80, 24);
            this.txtuid.TabIndex = 57;
            this.txtuid.Text = "0";
            this.txtuid.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(125, 448);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(12, 16);
            this.lblUserName.TabIndex = 58;
            this.lblUserName.Text = ".";
            // 
            // lblFileExtension
            // 
            this.lblFileExtension.AutoSize = true;
            this.lblFileExtension.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileExtension.Location = new System.Drawing.Point(408, 288);
            this.lblFileExtension.Name = "lblFileExtension";
            this.lblFileExtension.Size = new System.Drawing.Size(58, 16);
            this.lblFileExtension.TabIndex = 59;
            this.lblFileExtension.Text = "user.png";
            // 
            // dtDob
            // 
            this.dtDob.CustomFormat = "dd/MM/yyyy";
            this.dtDob.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDob.Location = new System.Drawing.Point(270, 298);
            this.dtDob.Name = "dtDob";
            this.dtDob.Size = new System.Drawing.Size(125, 22);
            this.dtDob.TabIndex = 6;
            this.dtDob.Value = new System.DateTime(1992, 1, 16, 0, 0, 0, 0);
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
            this.pnlTitle.Size = new System.Drawing.Size(616, 38);
            this.pnlTitle.TabIndex = 161;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(581, 3);
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
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(98, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "User Profile";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnKbContact);
            this.panel1.Controls.Add(this.btnKbEmail);
            this.panel1.Controls.Add(this.btnKbAddress);
            this.panel1.Controls.Add(this.btnKbName);
            this.panel1.Controls.Add(this.pnlItemImage);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtuid);
            this.panel1.Controls.Add(this.txtUserName);
            this.panel1.Controls.Add(this.dtDob);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblFileExtension);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.rdbUserRole);
            this.panel1.Controls.Add(this.btnChangePic);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtUserFullName);
            this.panel1.Controls.Add(this.txtContact);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 423);
            this.panel1.TabIndex = 162;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = global::cypos.Properties.Resources.update100x45;
            this.btnUpdate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(397, 363);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 45);
            this.btnUpdate.TabIndex = 183;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::cypos.Properties.Resources.exit100x45;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(503, 363);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 45);
            this.btnExit.TabIndex = 182;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnKbContact
            // 
            this.btnKbContact.FlatAppearance.BorderSize = 0;
            this.btnKbContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbContact.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbContact.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbContact.Location = new System.Drawing.Point(558, 233);
            this.btnKbContact.Name = "btnKbContact";
            this.btnKbContact.Size = new System.Drawing.Size(50, 33);
            this.btnKbContact.TabIndex = 176;
            this.btnKbContact.UseVisualStyleBackColor = true;
            this.btnKbContact.Click += new System.EventHandler(this.btnKbContact_Click);
            // 
            // btnKbEmail
            // 
            this.btnKbEmail.FlatAppearance.BorderSize = 0;
            this.btnKbEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbEmail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbEmail.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbEmail.Location = new System.Drawing.Point(558, 173);
            this.btnKbEmail.Name = "btnKbEmail";
            this.btnKbEmail.Size = new System.Drawing.Size(50, 33);
            this.btnKbEmail.TabIndex = 175;
            this.btnKbEmail.UseVisualStyleBackColor = true;
            this.btnKbEmail.Click += new System.EventHandler(this.btnKbEmail_Click);
            // 
            // btnKbAddress
            // 
            this.btnKbAddress.FlatAppearance.BorderSize = 0;
            this.btnKbAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbAddress.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbAddress.Location = new System.Drawing.Point(558, 73);
            this.btnKbAddress.Name = "btnKbAddress";
            this.btnKbAddress.Size = new System.Drawing.Size(50, 33);
            this.btnKbAddress.TabIndex = 174;
            this.btnKbAddress.UseVisualStyleBackColor = true;
            this.btnKbAddress.Click += new System.EventHandler(this.btnKbAddress_Click);
            // 
            // btnKbName
            // 
            this.btnKbName.FlatAppearance.BorderSize = 0;
            this.btnKbName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbName.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbName.Location = new System.Drawing.Point(558, 24);
            this.btnKbName.Name = "btnKbName";
            this.btnKbName.Size = new System.Drawing.Size(50, 33);
            this.btnKbName.TabIndex = 173;
            this.btnKbName.UseVisualStyleBackColor = true;
            this.btnKbName.Click += new System.EventHandler(this.btnKbName_Click);
            // 
            // pnlItemImage
            // 
            this.pnlItemImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlItemImage.Controls.Add(this.PicUserPhoto);
            this.pnlItemImage.Controls.Add(this.lblImageName);
            this.pnlItemImage.Location = new System.Drawing.Point(22, 8);
            this.pnlItemImage.Name = "pnlItemImage";
            this.pnlItemImage.Padding = new System.Windows.Forms.Padding(5);
            this.pnlItemImage.Size = new System.Drawing.Size(231, 225);
            this.pnlItemImage.TabIndex = 170;
            // 
            // PicUserPhoto
            // 
            this.PicUserPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicUserPhoto.Image = global::cypos.Properties.Resources.no_image;
            this.PicUserPhoto.InitialImage = ((System.Drawing.Image)(resources.GetObject("PicUserPhoto.InitialImage")));
            this.PicUserPhoto.Location = new System.Drawing.Point(5, 5);
            this.PicUserPhoto.Name = "PicUserPhoto";
            this.PicUserPhoto.Size = new System.Drawing.Size(219, 200);
            this.PicUserPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicUserPhoto.TabIndex = 37;
            this.PicUserPhoto.TabStop = false;
            // 
            // lblImageName
            // 
            this.lblImageName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblImageName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageName.ForeColor = System.Drawing.Color.Silver;
            this.lblImageName.Location = new System.Drawing.Point(5, 205);
            this.lblImageName.Name = "lblImageName";
            this.lblImageName.Size = new System.Drawing.Size(219, 13);
            this.lblImageName.TabIndex = 63;
            this.lblImageName.Text = "-";
            this.lblImageName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmUserProfile
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(616, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUserProfile";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Profile";
            this.Load += new System.EventHandler(this.UserProfile_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlItemImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicUserPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChangePic;
        private System.Windows.Forms.RadioButton rdbUserRole;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserFullName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtuid;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblFileExtension;
        private System.Windows.Forms.DateTimePicker dtDob;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlItemImage;
        private System.Windows.Forms.PictureBox PicUserPhoto;
        private System.Windows.Forms.Label lblImageName;
        private System.Windows.Forms.Button btnKbContact;
        private System.Windows.Forms.Button btnKbEmail;
        private System.Windows.Forms.Button btnKbAddress;
        private System.Windows.Forms.Button btnKbName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnExit;

    }
}