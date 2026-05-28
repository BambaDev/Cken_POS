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
    public partial class frmPrintView : Form
    {
        private frmMain _frmMain;
        string strReport;
        string strRefNo;

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
        public frmPrintView(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;
        }

        public string RefNo
        {
            set { strRefNo = value; }
            get { return strRefNo; }
        }

        public string Report
        {
            set { strReport = value; }
            get { return strReport; }
        }

        public void LoadReport()
        {
            this.rptViewer.ShowToolBar = false;
            this.rptViewer.HorizontalScroll.Visible = false;
            this.rptViewer.SetDisplayMode(DisplayMode.PrintLayout);
            this.rptViewer.ZoomMode = ZoomMode.PageWidth;
            //this.reportViewer1.ZoomPercent = 80;
            rptViewer.LocalReport.EnableExternalImages = true;

            if (strReport == "Invoice")
            {
                pnlHeader.Height = 50;
                LoadInvoice();
            }
            else if (strReport == "Kot")
            {
                pnlHeader.Height = 50;
                LoadKot();
            }
        }

        public void LoadInvoice()
        {
            rptViewer.LocalReport.ReportEmbeddedResource = "cypos.Reports.rptReceipt.rdlc";
            rptViewer.LocalReport.DisplayName = "Receipt-" + strRefNo;
            ReportParameter paramLogo = new ReportParameter();
            paramLogo.Name = "logo_path";
            paramLogo.Values.Add("file:///" + Application.StartupPath + @"\Images\" + Company.Logo);
            rptViewer.LocalReport.SetParameters(paramLogo);

            string strSQL = @"SELECT tbl_InvoiceHeader.invoice_id, tbl_InvoiceHeader.order_type, tbl_InvoiceHeader.invoice_no, tbl_InvoiceHeader.invoice_date,
                             tbl_InvoiceHeader.invoice_time, tbl_InvoiceHeader.table_id, tbl_Tables.table_name,
                             tbl_TableLocation.location_name, tbl_InvoiceHeader.no_of_guests, tbl_InvoiceHeader.waiter_id,
                             tbl_User.name AS waiter_name, tbl_InvoiceHeader.customer_id,
                             CASE WHEN tbl_InvoiceHeader.customer_id = 0 THEN 'Cash' ELSE tbl_Customer.name END AS customer_name,
                             tbl_Customer.address AS customer_address, tbl_Customer.city AS customer_city,
                             tbl_Customer.phone AS customer_phone, tbl_Customer.email AS customer_email,
                             tbl_InvoiceHeader.payment_type, tbl_InvoiceHeader.payment_amount, tbl_InvoiceHeader.paid_amount, tbl_InvoiceHeader.change_amount,
                             tbl_InvoiceHeader.due_amount, tbl_InvoiceHeader.discount_rate, tbl_InvoiceHeader.discount_amount,
                             tbl_InvoiceHeader.tax1_name, tbl_InvoiceHeader.tax1_rate, tbl_InvoiceHeader.tax1_amount,
                             tbl_InvoiceHeader.tax2_name, tbl_InvoiceHeader.tax2_rate, tbl_InvoiceHeader.tax2_amount,
                             tbl_InvoiceHeader.sc_rate, tbl_InvoiceHeader.sc_charge, tbl_InvoiceHeader.note, tbl_InvoiceHeader.user_name,
                             tbl_InvoiceHeader.log_date, tbl_InvoiceDetail.detail_id, tbl_InvoiceDetail.item_code, tbl_InvoiceDetail.item_name,
                             tbl_InvoiceDetail.qty, tbl_InvoiceDetail.selling_price, tbl_InvoiceDetail.total,
                             tbl_InvoiceDetail.discount, tbl_InvoiceDetail.tax_apply, tbl_InvoiceDetail.show_kitchen,
                             tbl_Company.company_name, tbl_Company.company_address, tbl_Company.company_phone,
                             tbl_Company.email AS company_email, tbl_Company.web AS company_web, tbl_Company.tax_no,
                             tbl_Company.footer_message, tbl_Company.logo, tbl_Settings.ask_table, tbl_Settings.ask_guest_count,
                             tbl_Settings.ask_waiter, tbl_Settings.show_logo, tbl_Settings.enable_sc
                             FROM tbl_InvoiceHeader
                             LEFT JOIN tbl_InvoiceDetail ON tbl_InvoiceHeader.invoice_id = tbl_InvoiceDetail.header_id
                             LEFT JOIN tbl_Tables ON tbl_InvoiceHeader.table_id = tbl_Tables.id
                             LEFT JOIN tbl_TableLocation ON tbl_Tables.location_id = tbl_TableLocation.Id
                             LEFT JOIN tbl_User ON tbl_InvoiceHeader.waiter_id = tbl_User.id
                             LEFT JOIN tbl_Customer ON tbl_InvoiceHeader.customer_id = tbl_Customer.id
                             CROSS JOIN tbl_Company
                             CROSS JOIN tbl_Settings
                             WHERE tbl_InvoiceHeader.invoice_no = @invoiceNo";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@invoiceNo", System.Data.SqlDbType.NVarChar) { Value = strRefNo }
            };

            DataTable dt = SecureDataAccess.GetDataTable(strSQL, parameters);

            ReportDataSource reportDSDetail = new ReportDataSource("dsReceipt", dt);
            this.rptViewer.LocalReport.DataSources.Clear();
            this.rptViewer.LocalReport.DataSources.Add(reportDSDetail);
            this.rptViewer.LocalReport.Refresh();
            this.rptViewer.RefreshReport();
        }

        public void LoadKot()
        {
            rptViewer.LocalReport.ReportEmbeddedResource = "cypos.Reports.rptKot.rdlc";

            string strSQL = @"SELECT tbl_TempHeader.id, tbl_TempHeader.order_type, tbl_TempHeader.invoice_date, tbl_TempHeader.invoice_time,
                             tbl_TempHeader.kot_no, tbl_TempHeader.table_id, tbl_Tables.table_name, tbl_TableLocation.location_name,
                             tbl_TempHeader.no_of_guests, tbl_TempHeader.waiter_id, tbl_User.name, tbl_TempHeader.note,
                             tbl_TempHeader.user_name, tbl_TempDetail.item_code, tbl_TempDetail.item_name, tbl_TempDetail.kot_qty AS qty,
                             tbl_TempDetail.show_kitchen, tbl_TempDetail.print_kot, tbl_Company.company_name
                             FROM tbl_TempHeader
                             INNER JOIN tbl_TempDetail ON tbl_TempHeader.id = tbl_TempDetail.header_id
                             LEFT JOIN tbl_Tables ON tbl_TempHeader.table_id = tbl_Tables.id
                             LEFT JOIN tbl_TableLocation ON tbl_Tables.location_id = tbl_TableLocation.Id
                             LEFT OUTER JOIN tbl_User ON tbl_TempHeader.waiter_id = tbl_User.id
                             CROSS JOIN tbl_Company
                             WHERE tbl_TempHeader.id = @tempHeaderId
                             AND tbl_TempDetail.print_kot = 1
                             AND kot_qty > 0";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@tempHeaderId", System.Data.SqlDbType.Int) { Value = int.Parse(strRefNo) }
            };

            DataTable dt = SecureDataAccess.GetDataTable(strSQL, parameters);

            ReportDataSource reportDSDetail = new ReportDataSource("dsKot", dt);
            this.rptViewer.LocalReport.DataSources.Clear();
            this.rptViewer.LocalReport.DataSources.Add(reportDSDetail);
            this.rptViewer.LocalReport.Refresh();
            this.rptViewer.RefreshReport();
        }

        private void frmPrintView_Load(object sender, EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void pbxClose_Click(object sender, EventArgs e)
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Selet Printer
            string strPrinter = DirectPrint.GetDefaultPrinter(); //System Default Printer
            if (strReport == "Invoice")
            {
                strPrinter=Settings.InvoicePrinter;
            }
            if (strReport == "Kot")
            {
                 strPrinter=Settings.KotPrinter;
            }

            if (DirectPrint.Print(rptViewer.LocalReport,strPrinter))
            {
                _frmMain.UpdateKotPrintedItems();
                _frmMain.Clear();
                OpenedForms.Close();
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

        private void frmPrintView_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (strReport!="Kot")
            //{
                _frmMain.Clear();
            //}
        }
    }
}
