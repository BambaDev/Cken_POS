using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.InteropServices;

namespace cypos
{
    public partial class frmPrinters : Form
    {
        private frmMain _frmMain;  

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

        public frmPrinters(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;
            GetInstalledPrinters();
        }

        private void frmPrinters_Load(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "SELECT TOP 1 * FROM tbl_Settings";
                DataTable dtSetting = SecureDataAccess.GetDataTable(strSQL);

                cmbInvoicePrinter.Text = dtSetting.Rows[0]["invoice_printer"].ToString();
                cmbKotPrinter.Text = dtSetting.Rows[0]["kot_printer"].ToString();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void GetInstalledPrinters()
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cmbInvoicePrinter.Items.Add(printer);
                cmbKotPrinter.Items.Add(printer);
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strSQLUpdate = @"UPDATE tbl_Settings
                                       SET invoice_printer = @invoicePrinter,
                                           kot_printer = @kotPrinter";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@invoicePrinter", System.Data.SqlDbType.NVarChar) { Value = cmbInvoicePrinter.Text },
                    new System.Data.SqlClient.SqlParameter("@kotPrinter", System.Data.SqlDbType.NVarChar) { Value = cmbKotPrinter.Text }
                };

                SecureDataAccess.ExecuteNonQuery(strSQLUpdate, parameters);
                OpenedForms.Close();
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
    }
}
