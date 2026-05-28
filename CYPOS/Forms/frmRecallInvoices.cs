using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace cypos
{
    public partial class frmRecallInvoices : Form
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

        public frmRecallInvoices(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;
            dgvItems.AutoGenerateColumns = false;

            //Grids Fonts
            dgvItems.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvItems.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvItems.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);

            LoadOrderList();

            lblOrderType.Text = "";
            lblTable.Text = "";
            lblGuests.Text = "";
            lblTotal.Text = "0.00";
            btnPrintKot.Enabled = false;
            btnRecall.Enabled = false;
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

        private void tbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbMain.SelectedIndex == 0)//Dine In
            {
                floDineIn.Controls.Clear();
                LoadOrderList(1);
            }
            else if (tbMain.SelectedIndex == 1)//Take Away
            {
                floTakeAway.Controls.Clear();
                LoadOrderList(2);
            }
            else if (tbMain.SelectedIndex == 2)//Delivery Order
            {
                floDeliveryOrder.Controls.Clear();
                LoadOrderList(3);
            }
            else if (tbMain.SelectedIndex == 3)//Pickup order
            {
                floPickupOrder.Controls.Clear();
                LoadOrderList(4);
            }
            lblOrderType.Text = "";
            lblTable.Text = "";
            lblGuests.Text ="";
            lblTotal.Text = "";
            dgvItems.DataSource = null;
        }

        public void LoadOrderList(int orderType=1)
        {
            try
            {
                string strSQL = "SELECT tbl_TempHeader.id, tbl_TempHeader.invoice_date," +
                               "tbl_TempHeader.order_type, tbl_TempHeader.table_id, tbl_TempHeader.no_of_guests," +
                               "tbl_TempHeader.waiter_id, tbl_TempHeader.customer_id, tbl_TempHeader.payment_type," +
                               "tbl_TempHeader.payment_amount, tbl_TempHeader.change_amount,tbl_TempHeader.due_amount," +
                               "tbl_TempHeader.discount_rate, tbl_TempHeader.discount_amount, tbl_TempHeader.tax1_name," +
                               "tbl_TempHeader.tax1_rate,tbl_TempHeader.tax1_amount, tbl_TempHeader.tax2_name," +
                               "tbl_TempHeader.tax2_rate, tbl_TempHeader.tax2_amount, tbl_TempHeader.note," +
                               "tbl_TempHeader.user_name,tbl_TempHeader.status, tbl_TempHeader.log_date,tbl_Tables.table_name,tbl_User.name AS waiter_name," +
                               "CASE WHEN tbl_TempHeader.customer_id = 0 THEN 'Cash' ELSE tbl_Customer.name END AS customer_name " +
                               "FROM tbl_TempHeader LEFT JOIN tbl_Tables ON tbl_TempHeader.table_id = tbl_Tables.id " +
                               "LEFT JOIN tbl_Customer ON tbl_TempHeader.customer_id = tbl_Customer.id " +
                               "LEFT JOIN tbl_User ON tbl_TempHeader.waiter_id = tbl_User.id " +
                               "WHERE order_type = @orderType";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@orderType", System.Data.SqlDbType.NVarChar) { Value = orderType }
                };

                DataTable dt = SecureDataAccess.GetDataTable(strSQL, parameters);

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];
                    Button btnInvoice = new Button();
                    btnInvoice.FlatStyle = FlatStyle.Flat;
                    btnInvoice.FlatAppearance.BorderSize = 1;
                    btnInvoice.FlatAppearance.BorderColor = Color.Gray;
                    string strStatus = dt.Rows[i]["status"].ToString();
                    if (strStatus == "Done")
                    {
                        btnInvoice.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        btnInvoice.BackColor = Color.Orange;
                    }

                    btnInvoice.Tag = dataReader["id"];
                    btnInvoice.Click += new EventHandler(btnInvoice_Click);

                    btnInvoice.Name = dataReader["id"].ToString();

                    btnInvoice.Margin = new Padding(3, 3, 3, 3);

                    btnInvoice.Size = new Size(150, 55);

                    btnInvoice.Text = "Hold Id: " + dataReader["id"] + "\n";
                    if (orderType != 1)
                    {
                        btnInvoice.Text += "Customer: " + dataReader["customer_name"]  + "\n";
                        btnInvoice.Text += "Amount: " + dataReader["payment_amount"].ToString();
                    }
                    else
                    {
                        btnInvoice.Text += "Table #: " + dataReader["table_name"] + " (" + dataReader["no_of_guests"] + ")" + "\n";
                        btnInvoice.Text += "Waiter: " + dataReader["waiter_name"].ToString();
                    }
                    btnInvoice.Font = new Font("Tahoma", 9, FontStyle.Regular, GraphicsUnit.Point);
                    btnInvoice.TextAlign = ContentAlignment.TopLeft;
                    btnInvoice.TextImageRelation = TextImageRelation.ImageBeforeText;
                    if (orderType == 1)
                    {
                        floDineIn.Controls.Add(btnInvoice);
                        tbMain.SelectedIndex = 0;
                    }
                    else if (orderType == 2)
                    {
                        floTakeAway.Controls.Add(btnInvoice);
                        tbMain.SelectedIndex = 1;
                    }
                    else if (orderType == 3)
                    {
                        floDeliveryOrder.Controls.Add(btnInvoice);
                        tbMain.SelectedIndex = 2;
                    }
                    else if (orderType == 4)
                    {
                        floPickupOrder.Controls.Add(btnInvoice);
                        tbMain.SelectedIndex = 3;
                    }
                    currentImage++;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        protected void btnInvoice_Click(object sender, EventArgs e)
        {
            Button btnInvoice = sender as Button;

            string strSQL = "SELECT tbl_TempHeader.id, tbl_TempHeader.invoice_date,tbl_TempHeader.invoice_time, tbl_TempHeader.order_type," +
                            "tbl_TempHeader.table_id,tbl_Tables.table_name, tbl_TempHeader.no_of_guests,tbl_TempHeader.waiter_id,"+
                            "tbl_User.name AS waiter_name,tbl_TempHeader.user_name,tbl_TempHeader.payment_amount,tbl_TempDetail.item_code," +
                            "tbl_TempDetail.item_name, tbl_TempDetail.qty,tbl_TempDetail.total,tbl_TempDetail.show_kitchen,tbl_TempDetail.print_kot," +
                            "tbl_TempDetail.kot_qty FROM tbl_TempDetail INNER JOIN tbl_TempHeader ON tbl_TempDetail.header_id = tbl_TempHeader.id " +
                            "LEFT JOIN tbl_Tables ON tbl_TempHeader.table_id = tbl_Tables.id " +
                            "LEFT JOIN tbl_User ON tbl_TempHeader.waiter_id = tbl_User.id " +
                            "WHERE tbl_TempHeader.id = @headerId";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@headerId", System.Data.SqlDbType.Int)
                    { Value = int.Parse(btnInvoice.Tag.ToString()) }
            };

            DataTable dt = SecureDataAccess.GetDataTable(strSQL, parameters);

            dgvItems.DataSource = dt;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                lblHoldId.Text = dr["id"].ToString();
                int iOrderType = int.Parse(dr["order_type"].ToString());
                string strOrderType=string.Empty;
                if (iOrderType == 1)
                {
                    strOrderType = "Dine In";
                }
                else if (iOrderType == 2)
                {
                    strOrderType = "Take Away";
                }
                else if (iOrderType == 3)
                {
                    strOrderType = "Delivery order";
                }
                else if (iOrderType == 4)
                {
                    strOrderType = "Pickup Order";
                }
                lblOrderTypeId.Text = dr["order_type"].ToString();
                lblOrderType.Text = strOrderType.ToString();
                lblTableId.Text = dr["table_id"].ToString();
                lblTable.Text = dr["table_name"].ToString();
                lblGuests.Text = dr["no_of_guests"].ToString();
                lblWaiterId.Text = dr["waiter_id"].ToString();
                lblWaiterName.Text = dr["waiter_name"].ToString();

                lblDate.Text = dr["invoice_date"].ToString();
                lblTime.Text = dr["invoice_time"].ToString();
                lblUser.Text = dr["user_name"].ToString();

                decimal decTotal = decimal.Parse(dr["payment_amount"].ToString());
                lblTotal.Text = decTotal.ToString("N2");
                btnRecall.Enabled = true;
                btnPrintKot.Enabled = true;
            }
        }

        private void btnRecall_Click(object sender, EventArgs e)
        {
            try
            {
                _frmMain.RecallInvoice(lblHoldId.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }

        }

        private void btnPrintKot_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        #region KOT

        private void NextKotNumber()
        {
            int inNextAutoNo;
            int inStartNo;
            int inLastAutoNo;
            string strNextAutoNo;
            string strNextKotNo;

            inStartNo = Settings.StartingKotNo;
            inLastAutoNo = Settings.LastKotAutoNo;

            if (inLastAutoNo == 0)//First Use
            {
                inNextAutoNo = inStartNo;
            }
            else
            {
                inNextAutoNo = inLastAutoNo + 1;
            }
            if (Settings.KotLeadingZeros)
            {
                strNextAutoNo = inNextAutoNo.ToString().PadLeft(Settings.KotZerosCount, '0');
            }
            else
            {
                strNextAutoNo = inNextAutoNo.ToString();
            }
            strNextKotNo = Settings.KotNoPrefix + strNextAutoNo;
            lblKotNo.Text = strNextKotNo;
        }


        #endregion
    }
}
