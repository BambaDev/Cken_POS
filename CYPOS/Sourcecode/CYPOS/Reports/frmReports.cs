using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Runtime.InteropServices;
using System.IO;

namespace cypos
{
    public partial class frmReports : Form
    {
        private frmMain _frmMain;
        string strReport;
        /****** To make the window movable *********/

        public const int WM_NCLBUTTONDOWN = 0xA1;       /*The WM_NCLBUTTONDOWN message is one of those messages. 
                                                         WM = Window Message. NC = Non Client, the part of the 
                                                         * window that's not the client area, the borders and the title bar. 
                                                         L = Left button, you can figure out BUTTONDOWN. */
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        /*********************************************/

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public frmReports(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;
            //Grids Fonts
            dgvReports.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvReports.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvReports.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            pnlHeader.Visible = false;
            pnlCombo.Visible = false;
            dgvReports.Rows.Add("DailyReport", "Daily Reports");
            dgvReports.Rows.Add("SalesByPayType", "Sales by Payment Type");
            dgvReports.Rows.Add("SalesByCategory", "Sales by Category");
            dgvReports.Rows.Add("ZReport", "Z Report");
            dgvReports.Rows.Add("StockReport", "Stock Report");
            dgvReports.Rows.Add("ReOrderReport", "Item Re-Order");
            dgvReports.ClearSelection();
        }

        private void pbxClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                OpenedForms.Close();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void LoadReport(string REPORT)
        {
            strReport = REPORT;
            this.rptViewer.ShowToolBar = false;
            this.rptViewer.HorizontalScroll.Visible = false;
            this.rptViewer.SetDisplayMode(DisplayMode.PrintLayout);
            this.rptViewer.ZoomMode = ZoomMode.PageWidth;
            //this.reportViewer1.ZoomPercent = 80;

            if (REPORT == "ZReport")
            {
                pnlHeader.Visible = true;
                pnlDate.Visible = true;
                pnlCombo.Visible = false;
                LoadZReport();
            }
            else if (REPORT == "DailyReport")
            {
                pnlHeader.Visible = true;
                pnlDate.Visible = true;
                pnlCombo.Visible = false;
                LoadDailyReport();
            }
            else if (REPORT == "SalesByPayType")
            {
                lblSearchField.Text = "Payment Type:";
                pnlHeader.Visible = true;
                pnlDate.Visible = true;
                pnlCombo.Visible = true;
                FillPaymentType();
                LoadPayTypeReport();
            }
            else if (REPORT == "SalesByCategory")
            {
                lblSearchField.Text = "Category:";
                pnlHeader.Visible = true;
                pnlDate.Visible = true;
                pnlCombo.Visible = true;
                FillCategory();
                LoadSalesByCategory();
            }
            else if (REPORT == "StockReport")
            {
                lblSearchField.Text = "Category:";
                pnlHeader.Visible = true;
                pnlDate.Visible = false;
                pnlCombo.Visible = true;
                FillCategory();
                LoadStockReport();
            }
            else if (REPORT == "ReOrderReport")
            {
                lblSearchField.Text = "Category:";
                pnlHeader.Visible = true;
                pnlDate.Visible = false;
                pnlCombo.Visible = true;
                FillCategory();
                LoadReOrderReport();
            }
        }


        public void LoadZReport()
        {
            rptViewer.LocalReport.ReportEmbeddedResource = "cypos.Reports.rptZReport.rdlc";

            ReportParameter prmFromDate = new ReportParameter();
            prmFromDate.Name = "prm_date_from";
            prmFromDate.Values.Add(dtpDateFrom.Text);
            rptViewer.LocalReport.SetParameters(prmFromDate);

            ReportParameter prmDateTo = new ReportParameter();
            prmDateTo.Name = "prm_date_to";
            prmDateTo.Values.Add(dtpDateTo.Text);
            rptViewer.LocalReport.SetParameters(prmDateTo);

            //Invoice Header 
            string strSQLHeader = "SELECT tbl_InvoiceHeader.invoice_id, tbl_InvoiceHeader.order_type, tbl_InvoiceHeader.invoice_no," +
                                  "tbl_InvoiceHeader.invoice_date, tbl_InvoiceHeader.invoice_time,tbl_Tables.table_name, tbl_Tables.no_of_chairs," +
                                  "tbl_TableLocation.location_name, tbl_InvoiceHeader.no_of_guests, tbl_User.name AS waiter_name," +
                                  "ISNULL(tbl_Customer.name, 'Guest') AS customer_name, tbl_Customer.address AS customer_address, " +
                                  "tbl_Customer.city AS customer_city, tbl_Customer.phone AS customer_phone,tbl_Customer.email AS customer_email," +
                                  "tbl_InvoiceHeader.payment_type, tbl_InvoiceHeader.payment_amount, tbl_InvoiceHeader.paid_amount," +
                                  "tbl_InvoiceHeader.change_amount, tbl_InvoiceHeader.due_amount, tbl_InvoiceHeader.discount_rate, " +
                                  "tbl_InvoiceHeader.discount_amount, tbl_InvoiceHeader.tax1_name, tbl_InvoiceHeader.tax1_rate, " +
                                  "tbl_InvoiceHeader.tax1_amount, tbl_InvoiceHeader.tax2_name, tbl_InvoiceHeader.tax2_rate," +
                                  "tbl_InvoiceHeader.tax2_amount, tbl_InvoiceHeader.sc_rate, tbl_InvoiceHeader.sc_charge, tbl_InvoiceHeader.note," +
                                  "tbl_InvoiceHeader.user_name,tbl_InvoiceHeader.log_date, tbl_Company.company_name, tbl_Company.company_address," +
                                  "tbl_Company.company_phone, tbl_Company.email AS company_email, tbl_Company.web AS company_web, tbl_Company.tax_no," +
                                  "tbl_Company.footer_message, tbl_Company.logo FROM tbl_InvoiceHeader " +
                                  "LEFT JOIN tbl_User ON tbl_InvoiceHeader.waiter_id = tbl_User.id " +
                                  "LEFT JOIN tbl_Tables ON tbl_InvoiceHeader.table_id = tbl_Tables.id " +
                                  "LEFT JOIN tbl_TableLocation ON tbl_Tables.location_id = tbl_TableLocation.Id " +
                                  "LEFT JOIN tbl_Customer ON tbl_InvoiceHeader.customer_id = tbl_Customer.id " +
                                  "CROSS JOIN tbl_Company WHERE tbl_InvoiceHeader.invoice_date  >= '" + dtpDateFrom.Text + "' " +
                                  "AND tbl_InvoiceHeader.invoice_date  <= '" + dtpDateTo.Text + "' ";

            
            DataTable dtHeader = SecureDataAccess.GetDataTable(strSQLHeader);
            //Invoice Detail
            string strSQLDetail = "SELECT tbl_InvoiceDetail.detail_id,tbl_InvoiceDetail.header_id,tbl_InvoiceDetail.invoice_date," +
                                  "tbl_InvoiceDetail.invoice_time,tbl_InvoiceDetail.item_code, tbl_InvoiceDetail.item_name," +
                                  "tbl_Item.cost_price, tbl_Item.selling_price, tbl_Item.discount, tbl_Category.category_name," +
                                  "tbl_Item.image_name, tbl_Item.show_kitchen, tbl_Item.print_kot, tbl_Item.show_pos, tbl_Item.stock_item," +
                                  "tbl_Item.reorder_level,tbl_Item.stock_quantity, tbl_Item.active, tbl_InvoiceDetail.qty," +
                                  "tbl_InvoiceDetail.selling_price AS price, tbl_InvoiceDetail.total,tbl_InvoiceDetail.discount AS discount_rate," +
                                  "tbl_InvoiceDetail.discount_amount, tbl_InvoiceDetail.net_amount, tbl_InvoiceDetail.profit," +
                                  "tbl_InvoiceDetail.tax_apply,tbl_InvoiceDetail.log_date FROM tbl_InvoiceDetail " +
                                  "INNER JOIN tbl_Item ON tbl_InvoiceDetail.item_code = tbl_Item.item_code " +
                                  "INNER JOIN tbl_Category ON tbl_Item.category_id = tbl_Category.id " +
                                  "WHERE tbl_InvoiceDetail.invoice_date  >= '" + dtpDateFrom.Text + "' " +
                                  "AND tbl_InvoiceDetail.invoice_date  <= '" + dtpDateTo.Text + "' ";

            
            DataTable dtDetail = SecureDataAccess.GetDataTable(strSQLDetail);

            this.rptViewer.LocalReport.DataSources.Clear();

            ReportDataSource dsHeader = new ReportDataSource("dsHeader", dtHeader);
            this.rptViewer.LocalReport.DataSources.Add(dsHeader);

            ReportDataSource dsDetail = new ReportDataSource("dsDetail", dtDetail);
            this.rptViewer.LocalReport.DataSources.Add(dsDetail);

            this.rptViewer.LocalReport.Refresh();
            this.rptViewer.RefreshReport();
        }

        public void LoadDailyReport()
        {
            rptViewer.LocalReport.ReportEmbeddedResource = "cypos.Reports.rptDailyReport.rdlc";
            ReportParameter prmFromDate = new ReportParameter();
            prmFromDate.Name = "prm_date_from";
            prmFromDate.Values.Add(dtpDateFrom.Text);
            rptViewer.LocalReport.SetParameters(prmFromDate);

            ReportParameter prmDateTo = new ReportParameter();
            prmDateTo.Name = "prm_date_to";
            prmDateTo.Values.Add(dtpDateTo.Text);
            rptViewer.LocalReport.SetParameters(prmDateTo);

            //Invoice Header 
            string strSQLHeader = "SELECT tbl_InvoiceHeader.invoice_id, tbl_InvoiceHeader.order_type, tbl_InvoiceHeader.invoice_no," +
                                  "tbl_InvoiceHeader.invoice_date, tbl_InvoiceHeader.invoice_time,tbl_Tables.table_name, tbl_Tables.no_of_chairs," +
                                  "tbl_TableLocation.location_name, tbl_InvoiceHeader.no_of_guests, tbl_User.name AS waiter_name," +
                                  "ISNULL(tbl_Customer.name, 'Guest') AS customer_name, tbl_Customer.address AS customer_address, " +
                                  "tbl_Customer.city AS customer_city, tbl_Customer.phone AS customer_phone,tbl_Customer.email AS customer_email," +
                                  "tbl_InvoiceHeader.payment_type, tbl_InvoiceHeader.payment_amount, tbl_InvoiceHeader.paid_amount," +
                                  "tbl_InvoiceHeader.change_amount, tbl_InvoiceHeader.due_amount, tbl_InvoiceHeader.discount_rate, " +
                                  "tbl_InvoiceHeader.discount_amount, tbl_InvoiceHeader.tax1_name, tbl_InvoiceHeader.tax1_rate, " +
                                  "tbl_InvoiceHeader.tax1_amount, tbl_InvoiceHeader.tax2_name, tbl_InvoiceHeader.tax2_rate," +
                                  "tbl_InvoiceHeader.tax2_amount, tbl_InvoiceHeader.sc_rate, tbl_InvoiceHeader.sc_charge, tbl_InvoiceHeader.note," +
                                  "tbl_InvoiceHeader.user_name,tbl_InvoiceHeader.log_date, tbl_Company.company_name, tbl_Company.company_address," +
                                  "tbl_Company.company_phone, tbl_Company.email AS company_email, tbl_Company.web AS company_web, tbl_Company.tax_no," +
                                  "tbl_Company.footer_message, tbl_Company.logo FROM tbl_InvoiceHeader " +
                                  "LEFT JOIN tbl_User ON tbl_InvoiceHeader.waiter_id = tbl_User.id " +
                                  "LEFT JOIN tbl_Tables ON tbl_InvoiceHeader.table_id = tbl_Tables.id " +
                                  "LEFT JOIN tbl_TableLocation ON tbl_Tables.location_id = tbl_TableLocation.Id " +
                                  "LEFT JOIN tbl_Customer ON tbl_InvoiceHeader.customer_id = tbl_Customer.id " +
                                  "CROSS JOIN tbl_Company WHERE tbl_InvoiceHeader.invoice_date  >= '" + dtpDateFrom.Text + "' " +
                                  "AND tbl_InvoiceHeader.invoice_date  <= '" + dtpDateTo.Text + "' ";

            
            DataTable dtHeader = SecureDataAccess.GetDataTable(strSQLHeader);
            //Invoice Detail
            string strSQLDetail = "SELECT tbl_InvoiceDetail.detail_id,tbl_InvoiceDetail.header_id,tbl_InvoiceDetail.invoice_date," +
                                  "tbl_InvoiceDetail.invoice_time,tbl_InvoiceDetail.item_code, tbl_InvoiceDetail.item_name," +
                                  "tbl_Item.cost_price, tbl_Item.selling_price, tbl_Item.discount, tbl_Category.category_name," +
                                  "tbl_Item.image_name, tbl_Item.show_kitchen, tbl_Item.print_kot, tbl_Item.show_pos, tbl_Item.stock_item," +
                                  "tbl_Item.reorder_level,tbl_Item.stock_quantity, tbl_Item.active, tbl_InvoiceDetail.qty," +
                                  "tbl_InvoiceDetail.selling_price AS price, tbl_InvoiceDetail.total,tbl_InvoiceDetail.discount AS discount_rate," +
                                  "tbl_InvoiceDetail.discount_amount, tbl_InvoiceDetail.net_amount, tbl_InvoiceDetail.profit," +
                                  "tbl_InvoiceDetail.tax_apply,tbl_InvoiceDetail.log_date FROM tbl_InvoiceDetail " +
                                  "INNER JOIN tbl_Item ON tbl_InvoiceDetail.item_code = tbl_Item.item_code " +
                                  "INNER JOIN tbl_Category ON tbl_Item.category_id = tbl_Category.id " +
                                  "WHERE tbl_InvoiceDetail.invoice_date  >= '" + dtpDateFrom.Text + "' " +
                                  "AND tbl_InvoiceDetail.invoice_date  <= '" + dtpDateTo.Text + "' ";

            
            DataTable dtDetail = SecureDataAccess.GetDataTable(strSQLDetail);

            this.rptViewer.LocalReport.DataSources.Clear();

            ReportDataSource dsHeader = new ReportDataSource("dsHeader", dtHeader);
            this.rptViewer.LocalReport.DataSources.Add(dsHeader);

            ReportDataSource dsDetail = new ReportDataSource("dsDetail", dtDetail);
            this.rptViewer.LocalReport.DataSources.Add(dsDetail);

            this.rptViewer.LocalReport.Refresh();
            this.rptViewer.RefreshReport();
        }

        public void LoadPayTypeReport()
        {
            rptViewer.LocalReport.ReportEmbeddedResource = "cypos.Reports.rptPayTypeReport.rdlc";

            ReportParameter prmFromDate = new ReportParameter();
            prmFromDate.Name = "prm_date_from";
            prmFromDate.Values.Add(dtpDateFrom.Text);
            rptViewer.LocalReport.SetParameters(prmFromDate);

            ReportParameter prmDateTo = new ReportParameter();
            prmDateTo.Name = "prm_date_to";
            prmDateTo.Values.Add(dtpDateTo.Text);
            rptViewer.LocalReport.SetParameters(prmDateTo);

            ReportParameter prmPayType = new ReportParameter();
            prmPayType.Name = "prm_payment";
            prmPayType.Values.Add(cmbSearch.Text);
            rptViewer.LocalReport.SetParameters(prmPayType);

            //Invoice Header 
            string strSQLHeader = "SELECT tbl_InvoiceHeader.invoice_id, tbl_InvoiceHeader.order_type, tbl_InvoiceHeader.invoice_no," +
                                  "tbl_InvoiceHeader.invoice_date, tbl_InvoiceHeader.invoice_time,tbl_Tables.table_name, tbl_Tables.no_of_chairs," +
                                  "tbl_TableLocation.location_name, tbl_InvoiceHeader.no_of_guests, tbl_User.name AS waiter_name," +
                                  "ISNULL(tbl_Customer.name, 'Guest') AS customer_name, tbl_Customer.address AS customer_address, " +
                                  "tbl_Customer.city AS customer_city, tbl_Customer.phone AS customer_phone,tbl_Customer.email AS customer_email," +
                                  "tbl_InvoiceHeader.payment_type, tbl_InvoiceHeader.payment_amount, tbl_InvoiceHeader.paid_amount," +
                                  "tbl_InvoiceHeader.change_amount, tbl_InvoiceHeader.due_amount, tbl_InvoiceHeader.discount_rate, " +
                                  "tbl_InvoiceHeader.discount_amount, tbl_InvoiceHeader.tax1_name, tbl_InvoiceHeader.tax1_rate, " +
                                  "tbl_InvoiceHeader.tax1_amount, tbl_InvoiceHeader.tax2_name, tbl_InvoiceHeader.tax2_rate," +
                                  "tbl_InvoiceHeader.tax2_amount, tbl_InvoiceHeader.sc_rate, tbl_InvoiceHeader.sc_charge, tbl_InvoiceHeader.note," +
                                  "tbl_InvoiceHeader.user_name,tbl_InvoiceHeader.log_date, tbl_Company.company_name, tbl_Company.company_address," +
                                  "tbl_Company.company_phone, tbl_Company.email AS company_email, tbl_Company.web AS company_web, tbl_Company.tax_no," +
                                  "tbl_Company.footer_message, tbl_Company.logo FROM tbl_InvoiceHeader " +
                                  "LEFT JOIN tbl_User ON tbl_InvoiceHeader.waiter_id = tbl_User.id " +
                                  "LEFT JOIN tbl_Tables ON tbl_InvoiceHeader.table_id = tbl_Tables.id " +
                                  "LEFT JOIN tbl_TableLocation ON tbl_Tables.location_id = tbl_TableLocation.Id " +
                                  "LEFT JOIN tbl_Customer ON tbl_InvoiceHeader.customer_id = tbl_Customer.id " +
                                  "CROSS JOIN tbl_Company WHERE tbl_InvoiceHeader.invoice_date  >= '" + dtpDateFrom.Text + "' " +
                                  "AND tbl_InvoiceHeader.invoice_date  <= '" + dtpDateTo.Text + "'";
            if (cmbSearch.Text != "All")
            {
                strSQLHeader += " AND tbl_InvoiceHeader.payment_type='" + cmbSearch.Text + "'";
            }

            
            DataTable dtHeader = SecureDataAccess.GetDataTable(strSQLHeader);

            this.rptViewer.LocalReport.DataSources.Clear();
            ReportDataSource dsHeader = new ReportDataSource("dsHeader", dtHeader);
            this.rptViewer.LocalReport.DataSources.Add(dsHeader);

            this.rptViewer.LocalReport.Refresh();
            this.rptViewer.RefreshReport();
        }

        public void LoadSalesByCategory()
        {
            rptViewer.LocalReport.ReportEmbeddedResource = "cypos.Reports.rptSalesByCategory.rdlc";

            ReportParameter prmCategory = new ReportParameter();
            prmCategory.Name = "prm_category";
            prmCategory.Values.Add(cmbSearch.Text);
            rptViewer.LocalReport.SetParameters(prmCategory);

            ReportParameter prmFromDate = new ReportParameter();
            prmFromDate.Name = "prm_date_from";
            prmFromDate.Values.Add(dtpDateFrom.Text);
            rptViewer.LocalReport.SetParameters(prmFromDate);

            ReportParameter prmDateTo = new ReportParameter();
            prmDateTo.Name = "prm_date_to";
            prmDateTo.Values.Add(dtpDateTo.Text);
            rptViewer.LocalReport.SetParameters(prmDateTo);

            //Invoice Header 
            string strSQLHeader = "SELECT tbl_InvoiceHeader.invoice_id, tbl_InvoiceHeader.order_type, tbl_InvoiceHeader.invoice_no," +
                                  "tbl_InvoiceHeader.invoice_date, tbl_InvoiceHeader.invoice_time,tbl_Tables.table_name, tbl_Tables.no_of_chairs," +
                                  "tbl_TableLocation.location_name, tbl_InvoiceHeader.no_of_guests, tbl_User.name AS waiter_name," +
                                  "ISNULL(tbl_Customer.name, 'Guest') AS customer_name, tbl_Customer.address AS customer_address, " +
                                  "tbl_Customer.city AS customer_city, tbl_Customer.phone AS customer_phone,tbl_Customer.email AS customer_email," +
                                  "tbl_InvoiceHeader.payment_type, tbl_InvoiceHeader.payment_amount, tbl_InvoiceHeader.paid_amount," +
                                  "tbl_InvoiceHeader.change_amount, tbl_InvoiceHeader.due_amount, tbl_InvoiceHeader.discount_rate, " +
                                  "tbl_InvoiceHeader.discount_amount, tbl_InvoiceHeader.tax1_name, tbl_InvoiceHeader.tax1_rate, " +
                                  "tbl_InvoiceHeader.tax1_amount, tbl_InvoiceHeader.tax2_name, tbl_InvoiceHeader.tax2_rate," +
                                  "tbl_InvoiceHeader.tax2_amount, tbl_InvoiceHeader.sc_rate, tbl_InvoiceHeader.sc_charge, tbl_InvoiceHeader.note," +
                                  "tbl_InvoiceHeader.user_name,tbl_InvoiceHeader.log_date, tbl_Company.company_name, tbl_Company.company_address," +
                                  "tbl_Company.company_phone, tbl_Company.email AS company_email, tbl_Company.web AS company_web, tbl_Company.tax_no," +
                                  "tbl_Company.footer_message, tbl_Company.logo FROM tbl_InvoiceHeader " +
                                  "LEFT JOIN tbl_User ON tbl_InvoiceHeader.waiter_id = tbl_User.id " +
                                  "LEFT JOIN tbl_Tables ON tbl_InvoiceHeader.table_id = tbl_Tables.id " +
                                  "LEFT JOIN tbl_TableLocation ON tbl_Tables.location_id = tbl_TableLocation.Id " +
                                  "LEFT JOIN tbl_Customer ON tbl_InvoiceHeader.customer_id = tbl_Customer.id " +
                                  "CROSS JOIN tbl_Company WHERE tbl_InvoiceHeader.invoice_date  >= '" + dtpDateFrom.Text + "' " +
                                  "AND tbl_InvoiceHeader.invoice_date  <= '" + dtpDateTo.Text + "' ";

            
            DataTable dtHeader = SecureDataAccess.GetDataTable(strSQLHeader);
            //Invoice Detail
            string strSQLDetail = "SELECT tbl_InvoiceDetail.detail_id,tbl_InvoiceDetail.header_id,tbl_InvoiceDetail.invoice_date," +
                                  "tbl_InvoiceDetail.invoice_time,tbl_InvoiceDetail.item_code, tbl_InvoiceDetail.item_name," +
                                  "tbl_Item.cost_price, tbl_Item.selling_price, tbl_Item.discount, tbl_Category.category_name," +
                                  "tbl_Item.image_name, tbl_Item.show_kitchen, tbl_Item.print_kot, tbl_Item.show_pos, tbl_Item.stock_item," +
                                  "tbl_Item.reorder_level,tbl_Item.stock_quantity, tbl_Item.active, tbl_InvoiceDetail.qty," +
                                  "tbl_InvoiceDetail.selling_price AS price, tbl_InvoiceDetail.total,tbl_InvoiceDetail.discount AS discount_rate," +
                                  "tbl_InvoiceDetail.discount_amount, tbl_InvoiceDetail.net_amount, tbl_InvoiceDetail.profit," +
                                  "tbl_InvoiceDetail.tax_apply,tbl_InvoiceDetail.log_date FROM tbl_InvoiceDetail " +
                                  "INNER JOIN tbl_Item ON tbl_InvoiceDetail.item_code = tbl_Item.item_code " +
                                  "INNER JOIN tbl_Category ON tbl_Item.category_id = tbl_Category.id " +
                                  "WHERE tbl_InvoiceDetail.invoice_date  >= '" + dtpDateFrom.Text + "' " +
                                  "AND tbl_InvoiceDetail.invoice_date  <= '" + dtpDateTo.Text + "' ";
            if (cmbSearch.Text != "All Categories")
            {
                strSQLDetail += " AND tbl_Category.category_name='" + cmbSearch.Text + "'";
            }

            
            DataTable dtDetail = SecureDataAccess.GetDataTable(strSQLDetail);

            this.rptViewer.LocalReport.DataSources.Clear();

            ReportDataSource dsHeader = new ReportDataSource("dsHeader", dtHeader);
            this.rptViewer.LocalReport.DataSources.Add(dsHeader);

            ReportDataSource dsDetail = new ReportDataSource("dsDetail", dtDetail);
            this.rptViewer.LocalReport.DataSources.Add(dsDetail);

            this.rptViewer.LocalReport.Refresh();
            this.rptViewer.RefreshReport();
        }

        public void LoadStockReport()
        {
            rptViewer.LocalReport.ReportEmbeddedResource = "cypos.Reports.rptStockReport.rdlc";

            ReportParameter prmCategory = new ReportParameter();
            prmCategory.Name = "prm_category";
            prmCategory.Values.Add(cmbSearch.Text);
            rptViewer.LocalReport.SetParameters(prmCategory);

            //Items
            string strSQLItem = "SELECT tbl_Item.id, tbl_Item.item_code, tbl_Item.item_name, tbl_Item.cost_price," +
                                  "tbl_Item.selling_price, tbl_Item.discount, tbl_Category.category_name," +
                                  "tbl_Item.image_name, tbl_Item.tax_apply, tbl_Item.show_kitchen, tbl_Item.print_kot," +
                                  "tbl_Item.show_pos, tbl_Item.stock_item, tbl_Item.reorder_level, tbl_Item.active," +
                                  "tbl_Item.stock_quantity, tbl_Item.sort_order, tbl_Item.log_date,tbl_Company.company_name " +
                                  "FROM tbl_Item INNER JOIN tbl_Category ON tbl_Item.category_id = tbl_Category.id " +
                                  "CROSS JOIN tbl_Company WHERE tbl_Item.stock_item=1";

            if (cmbSearch.Text != "All Categories")
            {
                strSQLItem += " AND tbl_Category.category_name='" + cmbSearch.Text + "'";
            }
            
            DataTable dtItems = SecureDataAccess.GetDataTable(strSQLItem);

            this.rptViewer.LocalReport.DataSources.Clear();

            ReportDataSource dsItem = new ReportDataSource("dsItems", dtItems);
            this.rptViewer.LocalReport.DataSources.Add(dsItem);

            this.rptViewer.LocalReport.Refresh();
            this.rptViewer.RefreshReport();
        }

        public void LoadReOrderReport()
        {
            rptViewer.LocalReport.ReportEmbeddedResource = "cypos.Reports.rptReOrderReport.rdlc";

            ReportParameter prmCategory = new ReportParameter();
            prmCategory.Name = "prm_category";
            prmCategory.Values.Add(cmbSearch.Text);
            rptViewer.LocalReport.SetParameters(prmCategory);

            //Items
            string strSQLItem = "SELECT tbl_Item.id, tbl_Item.item_code, tbl_Item.item_name, tbl_Item.cost_price," +
                                  "tbl_Item.selling_price, tbl_Item.discount, tbl_Category.category_name," +
                                  "tbl_Item.image_name, tbl_Item.tax_apply, tbl_Item.show_kitchen, tbl_Item.print_kot," +
                                  "tbl_Item.show_pos, tbl_Item.stock_item, tbl_Item.reorder_level, tbl_Item.active," +
                                  "tbl_Item.stock_quantity, tbl_Item.sort_order, tbl_Item.log_date,tbl_Company.company_name " +
                                  "FROM tbl_Item INNER JOIN tbl_Category ON tbl_Item.category_id = tbl_Category.id " +
                                  "CROSS JOIN tbl_Company WHERE tbl_Item.stock_item=1 AND tbl_Item.stock_quantity <= tbl_Item.reorder_level";

            if (cmbSearch.Text != "All Categories")
            {
                strSQLItem += " AND tbl_Category.category_name='" + cmbSearch.Text + "'";
            }
            
            DataTable dtItems = SecureDataAccess.GetDataTable(strSQLItem);

            this.rptViewer.LocalReport.DataSources.Clear();

            ReportDataSource dsItem = new ReportDataSource("dsItems", dtItems);
            this.rptViewer.LocalReport.DataSources.Add(dsItem);

            this.rptViewer.LocalReport.Refresh();
            this.rptViewer.RefreshReport();
        }

        private void FillPaymentType()
        {
            string strSQL = "SELECT * FROM tbl_PaymentType ORDER BY id ";
            
            DataTable dtPayType = SecureDataAccess.GetDataTable(strSQL);
            DataRow drow = dtPayType.NewRow();
            drow["id"] = "0";
            drow["payment_type"] = "All";
            dtPayType.Rows.InsertAt(drow, 0);
            cmbSearch.DataSource = dtPayType;
            cmbSearch.DisplayMember = "payment_type";
            cmbSearch.ValueMember = "id";
        }

        private void FillCategory()
        {
            string strSQL = "SELECT * FROM tbl_Category ORDER BY id ";
            
            DataTable dtCategory = SecureDataAccess.GetDataTable(strSQL);
            DataRow drow = dtCategory.NewRow();
            drow["id"] = "0";
            drow["category_name"] = "All Categories";
            dtCategory.Rows.InsertAt(drow, 0);
            cmbSearch.DataSource = dtCategory;
            cmbSearch.DisplayMember = "category_name";
            cmbSearch.ValueMember = "id";
        }

        private void dgvReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.rptViewer.Reset();
            LoadReport(dgvReports.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (strReport == "SalesByPayType")
            {
                LoadPayTypeReport();
            }
            else if (strReport == "SalesByCategory")
            {
                LoadSalesByCategory();
            }
            else if (strReport == "StockReport")
            {
                LoadStockReport();
            }
            else if (strReport == "ReOrderReport")
            {
                LoadReOrderReport();
            }
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            if (strReport == "ZReport")
            {
                LoadZReport();
            }
            else if (strReport == "DailyReport")
            {
                LoadDailyReport();
            }
            else if (strReport == "SalesByPayType")
            {
                LoadPayTypeReport();
            }
            else if (strReport == "SalesByCategory")
            {
                LoadSalesByCategory();
            }
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            if (strReport == "ZReport")
            {
                LoadZReport();
            }
            else if (strReport == "DailyReport")
            {
                LoadDailyReport();
            }
            else if (strReport == "SalesByPayType")
            {
                LoadPayTypeReport();
            }
            else if (strReport == "SalesByCategory")
            {
                LoadSalesByCategory();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Selet Printer
            string strPrinter = DirectPrint.GetDefaultPrinter(); //System Default Printer

            if (DirectPrint.Print(rptViewer.LocalReport, strPrinter))
            {
                //Do Nothing
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            var fBrowser = new FolderBrowserDialog();
            fBrowser.Description = "Choose a folder to save this file as Adobe Reader (.pdf)";
            DialogResult result = fBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                string strFolder = fBrowser.SelectedPath;
                SavePDF(rptViewer, strFolder + @"\" + strReport + ".pdf");
            }   
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            var fBrowser = new FolderBrowserDialog();
            fBrowser.Description = "Choose a folder to save this file as Microsoft Excel (.xls)";
            DialogResult result = fBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                string strFolder = fBrowser.SelectedPath;
                SaveExcel(rptViewer, strFolder + @"\" + strReport + ".xls");
            }  
        }

        public void SavePDF(ReportViewer viewer, string savePath)
        {
            byte[] Bytes = viewer.LocalReport.Render(format: "PDF", deviceInfo: "");

            using (FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                stream.Write(Bytes, 0, Bytes.Length);
            }
        }

        public void SaveExcel(ReportViewer viewer, string savePath)
        {
            byte[] Bytes = viewer.LocalReport.Render(format: "Excel", deviceInfo: "");

            using (FileStream stream = new FileStream(savePath, FileMode.Create))
            {
                stream.Write(Bytes, 0, Bytes.Length);
            }
        }


    }
}
