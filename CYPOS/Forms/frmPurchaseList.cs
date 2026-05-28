using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace cypos
{
    public partial class frmPurchaseList : Form
    {
        private frmMain _frmMain;

        /****** To make the window movable *********/

        public const int WM_NCLBUTTONDOWN = 0xA1; 
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

        public frmPurchaseList(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;
            dgvPurchase.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvPurchase.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvPurchase.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
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

        private void btnNewPurchase_Click(object sender, EventArgs e)
        {
            frmPurchase frmPurchase = new frmPurchase(this);
            frmPurchase.ShowDialog();
        }

        public void LoadPurchaseList()
        {
            try
            {
                dgvPurchase.AutoGenerateColumns = false;
                string strSQL = @"SELECT tbl_Purchase.id, tbl_Purchase.purchase_date, tbl_Purchase.ref_no,
                                 tbl_Purchase.supplier_id, ISNULL(tbl_Supplier.name, 'Cash') AS supplier_name,
                                 tbl_Purchase.product_id, tbl_Item.item_code, tbl_Item.item_name, tbl_Item.cost_price,
                                 tbl_Item.selling_price, tbl_Item.discount, tbl_Item.category_id, tbl_Category.category_name,
                                 tbl_Item.stock_item, tbl_Purchase.quantity, tbl_Purchase.price, tbl_Purchase.amount,
                                 tbl_Purchase.purchase_type
                                 FROM tbl_Purchase
                                 INNER JOIN tbl_Item ON tbl_Purchase.product_id = tbl_Item.id
                                 LEFT JOIN tbl_Supplier ON tbl_Purchase.supplier_id = tbl_Supplier.id
                                 INNER JOIN tbl_Category ON tbl_Item.category_id = tbl_Category.id
                                 WHERE tbl_Purchase.purchase_date >= @dateFrom
                                 AND tbl_Purchase.purchase_date <= @dateTo";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@dateFrom", System.Data.SqlDbType.NVarChar) { Value = dtpFrom.Text },
                    new System.Data.SqlClient.SqlParameter("@dateTo", System.Data.SqlDbType.NVarChar) { Value = dtpTo.Text }
                };

                DataTable dtGroup = SecureDataAccess.GetDataTable(strSQL, parameters);
                dgvPurchase.DataSource = dtGroup;
                dgvPurchase.Columns["clmAmount"].Width = 100;

                lblRows.Text = dgvPurchase.RowCount.ToString() + " Records Found";

                double dblSum = 0;
                for (int i = 0; i < dgvPurchase.Rows.Count; ++i)
                {
                    dblSum += Convert.ToDouble(dgvPurchase.Rows[i].Cells["clmAmount"].Value);
                }
                lblTotal.Text = "Total: " + Currency.Format(dblSum);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void frmPurchaseList_Load(object sender, EventArgs e)
        {
            LoadPurchaseList();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPurchaseList();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPurchaseList();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
    }
}
