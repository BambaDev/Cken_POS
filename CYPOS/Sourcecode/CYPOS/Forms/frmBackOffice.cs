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
    public partial class frmBackOffice : Form
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


        public frmBackOffice(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm; 
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            frmCompany frmCompany = new frmCompany();
            frmCompany.ShowDialog();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            frmCategory frmCategory = new frmCategory(_frmMain);
            frmCategory.ShowDialog();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            frmItem frmItem = new frmItem(_frmMain);
            frmItem.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmUser frmUser = new frmUser();
            frmUser.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnKitchenDisplay_Click(object sender, EventArgs e)
        {
            Report.frmKitchenDisplay frmKitchenDisplay = new Report.frmKitchenDisplay();
            frmKitchenDisplay.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmReports frmReports =new frmReports(_frmMain);
            frmReports.ShowDialog();    
        }

        private void btnModifiers_Click(object sender, EventArgs e)
        {
            frmModifiers frmModifiers = new frmModifiers();
            frmModifiers.ShowDialog();
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
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

        private void btnPayments_Click(object sender, EventArgs e)
        {
            frmDueInvoices frmDueInvoices = new frmDueInvoices();
            frmDueInvoices.ShowDialog();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer frmCustomer = new frmCustomer();
            frmCustomer.ShowDialog();
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            frmDatabase frmDataReset = new frmDatabase();
            frmDataReset.ShowDialog();
        }

        private void frmBackOffice_Load(object sender, EventArgs e)
        {

        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            frmPurchaseList frmPurchaseList = new frmPurchaseList(_frmMain);
            frmPurchaseList.ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            frmSupplier frmSupplier = new frmSupplier();
            frmSupplier.ShowDialog();
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            frmExpenses frmExpense = new frmExpenses();
            frmExpense.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frmSettings = new frmSettings(_frmMain);
            frmSettings.ShowDialog();
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            frmTable frmTable = new frmTable(_frmMain);
            frmTable.ShowDialog();
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            frmTableLocation frmTableLocation = new frmTableLocation(_frmMain);
            frmTableLocation.ShowDialog();
        }

        private void btnPaymentTypes_Click(object sender, EventArgs e)
        {
            frmPaymentType frmPaymentType = new frmPaymentType(_frmMain);
            frmPaymentType.ShowDialog();
        }

        private void btnPrinters_Click(object sender, EventArgs e)
        {
            frmPrinters frmPrinters = new frmPrinters(_frmMain);
            frmPrinters.ShowDialog();
        }

        private void btnExpenseGroup_Click(object sender, EventArgs e)
        {
            frmExpenseGroup frmExpenseGroup = new frmExpenseGroup(_frmMain);
            frmExpenseGroup.ShowDialog();
        }
    }
}
