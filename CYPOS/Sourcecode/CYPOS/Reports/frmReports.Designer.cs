namespace cypos
{
    partial class frmReports
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReports));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlCombo = new System.Windows.Forms.Panel();
            this.lblSearchField = new System.Windows.Forms.Label();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.clmReportId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmReports = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlCombo.SuspendLayout();
            this.pnlDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
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
            this.lblTitle.Location = new System.Drawing.Point(12, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(67, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Reports";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlInner);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 38);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlMain.Size = new System.Drawing.Size(800, 562);
            this.pnlMain.TabIndex = 165;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.panel2);
            this.pnlInner.Controls.Add(this.dgvReports);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(5, 0);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Padding = new System.Windows.Forms.Padding(5);
            this.pnlInner.Size = new System.Drawing.Size(790, 557);
            this.pnlInner.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pnlHeader);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(285, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panel2.Size = new System.Drawing.Size(500, 547);
            this.panel2.TabIndex = 233;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rptViewer);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 55);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel3.Size = new System.Drawing.Size(490, 492);
            this.panel3.TabIndex = 233;
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "POSPRINTDataSet";
            reportDataSource1.Value = null;
            this.rptViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.rptViewer.LocalReport.ReportEmbeddedResource = "";
            this.rptViewer.Location = new System.Drawing.Point(0, 5);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ShowBackButton = false;
            this.rptViewer.ShowContextMenu = false;
            this.rptViewer.ShowCredentialPrompts = false;
            this.rptViewer.ShowDocumentMapButton = false;
            this.rptViewer.ShowExportButton = false;
            this.rptViewer.ShowFindControls = false;
            this.rptViewer.ShowPageNavigationControls = false;
            this.rptViewer.ShowParameterPrompts = false;
            this.rptViewer.ShowPrintButton = false;
            this.rptViewer.ShowProgress = false;
            this.rptViewer.ShowPromptAreaButton = false;
            this.rptViewer.ShowRefreshButton = false;
            this.rptViewer.ShowStopButton = false;
            this.rptViewer.ShowToolBar = false;
            this.rptViewer.ShowZoomControl = false;
            this.rptViewer.Size = new System.Drawing.Size(490, 434);
            this.rptViewer.TabIndex = 232;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.btnPdf);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 439);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 53);
            this.panel1.TabIndex = 231;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::cypos.Properties.Resources.exit100x45;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(370, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 45);
            this.btnExit.TabIndex = 200;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = global::cypos.Properties.Resources.print100x40;
            this.btnPrint.Location = new System.Drawing.Point(265, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 45);
            this.btnPrint.TabIndex = 229;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackgroundImage = global::cypos.Properties.Resources.export_excel;
            this.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExcel.Location = new System.Drawing.Point(61, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(45, 45);
            this.btnExcel.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnExcel, "Export to Microsoft Excel");
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPdf
            // 
            this.btnPdf.BackgroundImage = global::cypos.Properties.Resources.pdf32x32;
            this.btnPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPdf.Location = new System.Drawing.Point(6, 4);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(45, 45);
            this.btnPdf.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnPdf, "Export to Adobe Acrobat Reader (PDF)");
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.pnlCombo);
            this.pnlHeader.Controls.Add(this.pnlDate);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(5, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(1);
            this.pnlHeader.Size = new System.Drawing.Size(490, 55);
            this.pnlHeader.TabIndex = 230;
            // 
            // pnlCombo
            // 
            this.pnlCombo.Controls.Add(this.lblSearchField);
            this.pnlCombo.Controls.Add(this.cmbSearch);
            this.pnlCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCombo.Location = new System.Drawing.Point(266, 1);
            this.pnlCombo.Name = "pnlCombo";
            this.pnlCombo.Size = new System.Drawing.Size(221, 51);
            this.pnlCombo.TabIndex = 1;
            // 
            // lblSearchField
            // 
            this.lblSearchField.AutoSize = true;
            this.lblSearchField.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchField.Location = new System.Drawing.Point(3, 4);
            this.lblSearchField.Name = "lblSearchField";
            this.lblSearchField.Size = new System.Drawing.Size(72, 14);
            this.lblSearchField.TabIndex = 226;
            this.lblSearchField.Text = "Search Field";
            // 
            // cmbSearch
            // 
            this.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Location = new System.Drawing.Point(3, 21);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(209, 24);
            this.cmbSearch.TabIndex = 224;
            this.cmbSearch.SelectedIndexChanged += new System.EventHandler(this.cmbSearch_SelectedIndexChanged);
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.dtpDateFrom);
            this.pnlDate.Controls.Add(this.dtpDateTo);
            this.pnlDate.Controls.Add(this.lblDateFrom);
            this.pnlDate.Controls.Add(this.lblDateTo);
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDate.Location = new System.Drawing.Point(1, 1);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(265, 51);
            this.pnlDate.TabIndex = 0;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpDateFrom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(3, 21);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(125, 23);
            this.dtpDateFrom.TabIndex = 223;
            this.dtpDateFrom.ValueChanged += new System.EventHandler(this.dtpDateFrom_ValueChanged);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpDateTo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(135, 21);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(125, 23);
            this.dtpDateTo.TabIndex = 227;
            this.dtpDateTo.ValueChanged += new System.EventHandler(this.dtpDateTo_ValueChanged);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.Location = new System.Drawing.Point(3, 4);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(68, 14);
            this.lblDateFrom.TabIndex = 225;
            this.lblDateFrom.Text = "Date From:";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.Location = new System.Drawing.Point(135, 4);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(56, 14);
            this.lblDateTo.TabIndex = 228;
            this.lblDateTo.Text = "Date To:";
            // 
            // dgvReports
            // 
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.AllowUserToResizeColumns = false;
            this.dgvReports.AllowUserToResizeRows = false;
            this.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReports.BackgroundColor = System.Drawing.Color.White;
            this.dgvReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReports.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvReports.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReports.ColumnHeadersHeight = 35;
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmReportId,
            this.clmReports});
            this.dgvReports.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvReports.EnableHeadersVisualStyles = false;
            this.dgvReports.Location = new System.Drawing.Point(5, 5);
            this.dgvReports.Margin = new System.Windows.Forms.Padding(3, 10, 3, 12);
            this.dgvReports.MultiSelect = false;
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.RowHeadersVisible = false;
            this.dgvReports.RowTemplate.Height = 32;
            this.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReports.Size = new System.Drawing.Size(280, 547);
            this.dgvReports.TabIndex = 234;
            this.dgvReports.TabStop = false;
            this.dgvReports.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReports_CellClick);
            // 
            // clmReportId
            // 
            this.clmReportId.HeaderText = "ReportId";
            this.clmReportId.Name = "clmReportId";
            this.clmReportId.ReadOnly = true;
            this.clmReportId.Visible = false;
            // 
            // clmReports
            // 
            this.clmReports.HeaderText = "Reports";
            this.clmReports.Name = "clmReports";
            this.clmReports.ReadOnly = true;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlCombo.ResumeLayout(false);
            this.pnlCombo.PerformLayout();
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.Label lblSearchField;
        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmReportId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmReports;
        private System.Windows.Forms.Panel pnlDate;
        private System.Windows.Forms.Panel pnlCombo;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}