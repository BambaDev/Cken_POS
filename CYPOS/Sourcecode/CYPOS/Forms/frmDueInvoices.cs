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
    public partial class frmDueInvoices : Form
    {
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

        public frmDueInvoices()
        {
            InitializeComponent();

            //Grids Fonts
            dgvDueInvoices.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvDueInvoices.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvDueInvoices.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

            dgvDueInvoices.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvDueInvoices.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvDueInvoices.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

            //History Grid Alignment
            dgvDueInvoices.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDueInvoices.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDueInvoices.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDueInvoices.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDueInvoices.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDueInvoices.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDueInvoices.Columns[3].DefaultCellStyle.Format = "N2";
            dgvDueInvoices.Columns[4].DefaultCellStyle.Format = "N2";
            dgvDueInvoices.Columns[5].DefaultCellStyle.Format = "N2";

            dgvDueInvoices.Columns[0].Width = 100;
            dgvDueInvoices.Columns[1].Width = 100;
            //dgvDueInvoices.Columns[2].Width = 200; 
            dgvDueInvoices.Columns[3].Width = 125;
            dgvDueInvoices.Columns[4].Width = 125;
            dgvDueInvoices.Columns[5].Width = 125; 

        }

        private void frmDueInvoices_Load(object sender, EventArgs e)
        {
            dgvDueInvoices.AutoGenerateColumns = false;

            string strSQL = "SELECT tbl_InvoiceHeader.invoice_id, tbl_InvoiceHeader.invoice_date," +
                            "ISNULL(tbl_Customer.name,'Guest') AS customer, tbl_InvoiceHeader.payment_amount," +
                            "tbl_InvoiceHeader.payment_amount - tbl_InvoiceHeader.due_amount AS paid_amount, tbl_InvoiceHeader.due_amount, tbl_InvoiceHeader.note " +
                            "FROM tbl_InvoiceHeader LEFT JOIN tbl_Customer ON tbl_InvoiceHeader.customer_id = tbl_Customer.id " +
                            "WHERE (tbl_InvoiceHeader.due_amount != '0') ";

            DataTable dtInvoices = SecureDataAccess.GetDataTable(strSQL);
            dgvDueInvoices.DataSource = dtInvoices;  
        }

        private void dgvDueInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                DataGridViewRow row = dgvDueInvoices.Rows[e.RowIndex];
                frmCustomerPayment frmPayment = new frmCustomerPayment();

                frmPayment.InvoiceNo = row.Cells[0].Value.ToString();
                frmPayment.InvoiceDate = row.Cells[1].Value.ToString();
                frmPayment.Customer = row.Cells[2].Value.ToString();
                frmPayment.TotalAmount = row.Cells[3].Value.ToString();
                frmPayment.PaidAmount = row.Cells[5].Value.ToString();
                frmPayment.DueAmount = row.Cells[5].Value.ToString();

                frmPayment.ShowDialog();           
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "SELECT tbl_InvoiceHeader.invoice_id, tbl_InvoiceHeader.invoice_date," +
                                "ISNULL(tbl_Customer.name,'Guest') AS customer, tbl_InvoiceHeader.payment_amount," +
                                "tbl_InvoiceHeader.payment_amount - tbl_InvoiceHeader.due_amount AS paid_amount, tbl_InvoiceHeader.due_amount, tbl_InvoiceHeader.note " +
                                "FROM tbl_InvoiceHeader LEFT JOIN tbl_Customer ON tbl_InvoiceHeader.customer_id = tbl_Customer.id " +
                                "WHERE (invoice_id = @invoiceId AND tbl_InvoiceHeader.due_amount != '0') ";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@invoiceId", System.Data.SqlDbType.NVarChar) { Value = txtSearch.Text }
                };

                DataTable dtDue = SecureDataAccess.GetDataTable(strSQL, parameters);
                dgvDueInvoices.DataSource = dtDue;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void dtpInvoiceDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "SELECT tbl_InvoiceHeader.invoice_id, tbl_InvoiceHeader.invoice_date," +
                                "ISNULL(tbl_Customer.name,'Guest') AS customer, tbl_InvoiceHeader.payment_amount," +
                                "tbl_InvoiceHeader.payment_amount - tbl_InvoiceHeader.due_amount AS paid_amount, tbl_InvoiceHeader.due_amount, tbl_InvoiceHeader.note " +
                                "FROM tbl_InvoiceHeader LEFT JOIN tbl_Customer ON tbl_InvoiceHeader.customer_id = tbl_Customer.id " +
                                "WHERE (invoice_date = @invoiceDate AND tbl_InvoiceHeader.due_amount != '0') ";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@invoiceDate", System.Data.SqlDbType.NVarChar) { Value = dtpInvoiceDate.Text }
                };

                DataTable dtDue = SecureDataAccess.GetDataTable(strSQL, parameters);
                dgvDueInvoices.DataSource = dtDue;
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


        #region Navigation

        private void btnRowUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvDueInvoices;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == 0)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[1].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.ClearSelection();
                dgv.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
                dgv.FirstDisplayedScrollingRowIndex = rowIndex - 1;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnRowDown_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvDueInvoices;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[1].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.ClearSelection();
                dgv.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
                if (RowIsVisible(selectedRow))
                {
                    dgv.FirstDisplayedScrollingRowIndex = selectedRow.Index + 1;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private bool RowIsVisible(DataGridViewRow row)
        {
            DataGridView dgv = row.DataGridView;
            int firstVisibleRowIndex = dgv.FirstDisplayedCell.RowIndex;
            int lastVisibleRowIndex = firstVisibleRowIndex + dgv.DisplayedRowCount(false) - 1;
            //return row.Index >= firstVisibleRowIndex && row.Index <= lastVisibleRowIndex;
            return row.Index >= lastVisibleRowIndex;
        }

        #endregion

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {

                DataGridViewRow row = dgvDueInvoices.CurrentRow;
                frmCustomerPayment frmPayment = new frmCustomerPayment();

                frmPayment.InvoiceNo = row.Cells[0].Value.ToString();
                frmPayment.InvoiceDate = row.Cells[1].Value.ToString();
                frmPayment.Customer = row.Cells[2].Value.ToString();
                frmPayment.TotalAmount = row.Cells[3].Value.ToString();
                frmPayment.PaidAmount = row.Cells[5].Value.ToString();
                frmPayment.DueAmount = row.Cells[5].Value.ToString();
                frmPayment.ShowDialog();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnKeyBoard_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtSearch);
            frmKeyboard.ShowDialog();
        }
    }
}
