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
using Microsoft.Reporting.WinForms;
namespace cypos.Report
{
    public partial class frmKitchenDisplay : Form
    {
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

        public frmKitchenDisplay()
        {
            InitializeComponent();
        }

        //Show Kitchen item Products with images
        public void LoadOrders()
        {
            floPanel.Controls.Clear();
            try
            {
                string strSQLHeader = "SELECT tbl_TempHeader.id, tbl_TempHeader.order_type, tbl_TempHeader.invoice_date," +
                                      "tbl_TempHeader.invoice_time, tbl_TempHeader.kot_no, tbl_Tables.table_name, " +
                                      "tbl_TableLocation.location_name, tbl_TempHeader.no_of_guests, tbl_TempHeader.user_name," +
                                      "tbl_TempHeader.note,tbl_TempHeader.status,tbl_User.name AS waiter_name FROM tbl_TempHeader " +
                                      "LEFT OUTER JOIN tbl_Tables ON tbl_TempHeader.table_id = tbl_Tables.id " +
                                      "LEFT OUTER JOIN tbl_TableLocation ON tbl_Tables.location_id = tbl_TableLocation.Id " +
                                      "LEFT OUTER JOIN tbl_User ON tbl_TempHeader.waiter_id = tbl_User.id";
                
                DataTable dtHeader = SecureDataAccess.GetDataTable(strSQLHeader);

                Panel pnlOrder=null;
                for (int i = 0; i < dtHeader.Rows.Count; i++)
                {
                    string strStatus = dtHeader.Rows[i]["status"].ToString();

                    pnlOrder = new Panel();
                    pnlOrder.BorderStyle = BorderStyle.FixedSingle;
                    pnlOrder.Width = 200;
                    pnlOrder.Height = 300;
                    pnlOrder.Tag = dtHeader.Rows[i]["id"].ToString();

                    //Waiter
                    Panel pnlWaiter = new Panel();
                    pnlWaiter.Height = 20;
                    pnlWaiter.Dock = DockStyle.Top;
                    //pnlWaiter.BackColor = Color.White;
                    //pnlWaiter.BringToFront();
                    pnlWaiter.Parent = pnlOrder;
                    pnlWaiter.Visible = false;

                    Label lblWaiter = new Label();
                    lblWaiter.Width = 75;
                    lblWaiter.AutoSize = false;
                    lblWaiter.Dock = DockStyle.Left;
                    //lblWaiter.BackColor = Color.Lime;
                    lblWaiter.TextAlign = ContentAlignment.MiddleLeft;
                    lblWaiter.Parent = pnlWaiter;
                    lblWaiter.Text = "Waiter: ";

                    Label lblWaiterName = new Label();
                    lblWaiterName.AutoSize = false;
                    lblWaiterName.Width = 125;
                    lblWaiterName.Dock = DockStyle.Right;
                    //lblWaiterName.BackColor = Color.LightGray;
                    lblWaiterName.BringToFront();
                    lblWaiterName.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
                    lblWaiterName.TextAlign = ContentAlignment.MiddleLeft;
                    lblWaiterName.Parent = pnlWaiter;
                    lblWaiterName.Text = dtHeader.Rows[i]["waiter_name"].ToString();

                    //Table
                    Panel pnlTableInfo = new Panel();
                    pnlTableInfo.Height = 20;
                    pnlTableInfo.Dock = DockStyle.Top;
                    //pnlTableInfo.BackColor = Color.LightGreen;
                    //pnlTableInfo.BringToFront();
                    pnlTableInfo.Parent = pnlOrder;
                    pnlTableInfo.Visible = false;

                    Label lblTable = new Label();
                    lblTable.Width = 75;
                    lblTable.AutoSize = false;
                    lblTable.Dock = DockStyle.Left;
                    //lblTable.BackColor = Color.Lime;
                    lblTable.TextAlign = ContentAlignment.MiddleLeft;
                    lblTable.Parent = pnlTableInfo;
                    lblTable.Text = "Table: ";

                    Label lblTableName = new Label();
                    lblTableName.AutoSize = false;
                    lblTableName.Width = 125;
                    lblTableName.Dock = DockStyle.Right;
                    //lblTableName.BackColor = Color.LightGray;
                    lblTableName.BringToFront();
                    lblTableName.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
                    lblTableName.TextAlign = ContentAlignment.MiddleLeft;
                    lblTableName.Parent = pnlTableInfo;
                    lblTableName.Text = dtHeader.Rows[i]["table_name"].ToString() + " (" + dtHeader.Rows[i]["no_of_guests"].ToString() + ")";

                    //Order Type
                    Panel pnlOrderType = new Panel();
                    pnlOrderType.Height = 20;
                    pnlOrderType.Dock = DockStyle.Top;
                    //pnlOrderType.BackColor = Color.LightGreen;
                    //pnlOrderType.BringToFront();
                    pnlOrderType.Parent = pnlOrder;

                    Label lblOTLeft = new Label();
                    lblOTLeft.Width = 75;
                    lblOTLeft.AutoSize = false;
                    lblOTLeft.Dock = DockStyle.Left;
                    //lblOTLeft.BackColor = Color.LightPink;
                    lblOTLeft.TextAlign = ContentAlignment.MiddleLeft;
                    lblOTLeft.Parent = pnlOrderType;
                    lblOTLeft.Text = "Order Type: ";

                    Label lblOTRight= new Label();
                    lblOTRight.AutoSize = false;
                    lblOTRight.Width = 125;
                    lblOTRight.Dock = DockStyle.Right;
                    //lblOTRight.BackColor = Color.LightGray;
                    lblOTRight.BringToFront();
                    lblOTRight.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
                    lblOTRight.TextAlign = ContentAlignment.MiddleLeft;
                    lblOTRight.Parent = pnlOrderType;

                    string strOtId = dtHeader.Rows[i]["order_type"].ToString();
                    string strOrderType=string.Empty;

                    if (strOtId == "1")
                    {
                        strOrderType = "Dine In";
                        pnlWaiter.Visible = true;
                        pnlTableInfo.Visible = true;
                    }
                    else if (strOtId == "2")
                    {
                        strOrderType = "Take Away";
                    }
                    else if (strOtId == "3")
                    {
                        strOrderType = "Delivery Order";
                    }
                    else if (strOtId == "4")
                    {
                        strOrderType = "Pickup Order";
                    }
                    lblOTRight.Text = strOrderType;

                    Panel pnlKotNo = new Panel();
                    pnlKotNo.Height = 20;
                    pnlKotNo.Dock = DockStyle.Top;
                    pnlKotNo.BackColor = Color.LightSalmon;
                    //pnlKotNo.BringToFront();
                    pnlKotNo.Parent = pnlOrder;

                    Label lblHoldLeft = new Label();
                    lblHoldLeft.Width = 75;
                    lblHoldLeft.AutoSize = false;
                    lblHoldLeft.Dock = DockStyle.Left;
                    lblHoldLeft.BackColor = Color.Yellow;
                    lblHoldLeft.TextAlign = ContentAlignment.MiddleLeft;
                    lblHoldLeft.Parent = pnlKotNo;
                    lblHoldLeft.Text = "Order: ";

                    Label lblHoldRight = new Label();
                    lblHoldRight.AutoSize = false;
                    lblHoldRight.Width = 125;
                    lblHoldRight.Dock = DockStyle.Right;
                    lblHoldRight.BackColor = Color.Yellow;
                    lblHoldRight.BringToFront();
                    lblHoldRight.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
                    lblHoldRight.TextAlign = ContentAlignment.MiddleLeft;
                    lblHoldRight.Parent = pnlKotNo;
                    lblHoldRight.Text = dtHeader.Rows[i]["id"].ToString();

                    string strSQLDetail = "SELECT item_code, item_name,CASE WHEN tbl_TempDetail.kot_qty > 0 THEN CONVERT(VARCHAR(MAX),qty) + ' [' + CONVERT(VARCHAR(MAX),kot_qty)  + ']' ELSE CONVERT(VARCHAR(MAX),qty) END AS qty,kot_qty " +
                                          "FROM tbl_TempDetail WHERE show_kitchen=1 " +
                                          "AND tbl_TempDetail.show_kitchen=1 " +
                                          "AND header_id= '" + int.Parse(pnlOrder.Tag.ToString()) + "'";

                    
                    DataTable dtDetail = SecureDataAccess.GetDataTable(strSQLDetail);

                    DataGridView dgvItem = new DataGridView();
                    dgvItem.AutoGenerateColumns = false;

                    //Grids Fonts
                    dgvItem.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
                    dgvItem.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
                    dgvItem.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);

                    dgvItem.Name = pnlOrder.Tag.ToString();
                    dgvItem.ReadOnly = true;
                    dgvItem.BorderStyle = BorderStyle.None;
                    dgvItem.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
                    dgvItem.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
                    dgvItem.RowHeadersVisible = false;
                    dgvItem.AllowUserToOrderColumns = false;
                    dgvItem.AllowUserToResizeColumns = false;
                    dgvItem.AllowUserToResizeRows = false;
                    dgvItem.AllowUserToAddRows = false;
                    dgvItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; ;
                   
                    dgvItem.Parent = pnlOrder;
                    dgvItem.Dock = DockStyle.Fill;
                    dgvItem.BringToFront();

                    dgvItem.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvItem.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

                    dgvItem.ColumnCount = 4;

                    dgvItem.Columns[0].Name = "clmItemCode" + pnlOrder.Tag.ToString();
                    dgvItem.Columns[0].DataPropertyName = "item_code";
                    dgvItem.Columns[0].Width = 40;
                    dgvItem.Columns[0].HeaderText = "Code";

                    dgvItem.Columns[1].Name = "clmItemName" + pnlOrder.Tag.ToString();
                    dgvItem.Columns[1].DataPropertyName = "item_name";
                    //dgvItem.Columns[1].Width = 100;
                    dgvItem.Columns[1].HeaderText = "Item Name";
                    dgvItem.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
                    dgvItem.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                    dgvItem.Columns[2].Name = "clmQty" + pnlOrder.Tag.ToString();
                    dgvItem.Columns[2].DataPropertyName = "qty";
                    dgvItem.Columns[2].Width = 30;
                    dgvItem.Columns[2].HeaderText = "Qty";
                    dgvItem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgvItem.Columns[3].HeaderText = "KOT Qty";
                    dgvItem.Columns[3].Name = "clmKotQty" + pnlOrder.Tag.ToString();
                    dgvItem.Columns[3].DataPropertyName = "kot_qty";
                    dgvItem.Columns[3].Visible = false;

                    dgvItem.DataSource = dtDetail;

                    dgvItem.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvItem_DataBindingComplete);

                    Panel pnlFooter = new Panel();
                    pnlFooter.Height = 50;
                    pnlFooter.Padding = new Padding(3, 3, 3, 3);
                    pnlFooter.Dock = DockStyle.Bottom;
                    pnlFooter.BackColor = SystemColors.Control;
                    //pnlKotNo.BringToFront();
                    pnlFooter.Parent = pnlOrder;

                    Button btnDone = new Button();
                    btnDone.Size = new Size(90, 45);
                    btnDone.Dock = DockStyle.Right;
                    btnDone.Text = "Done";
                    btnDone.Tag = dtHeader.Rows[i]["id"].ToString();
                    btnDone.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
                    btnDone.Click += new EventHandler(btnDone_Click);
                    btnDone.Parent = pnlFooter;

                    Button btnPrintKot = new Button();
                    btnPrintKot.Size = new Size(90, 45);
                    btnPrintKot.Dock = DockStyle.Left;
                    btnPrintKot.Text = "Print KOT";
                    btnPrintKot.Tag = dtHeader.Rows[i]["id"].ToString();
                    btnPrintKot.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
                    btnPrintKot.Click += new EventHandler(btnPrintKot_Click);
                    btnPrintKot.Parent = pnlFooter;

                    if (strStatus == "Done")
                    {
                        pnlOrder.BackColor = Color.GreenYellow;
                        dgvItem.BackgroundColor = Color.GreenYellow;
                        btnDone.Enabled = false;
                        btnPrintKot.Enabled = false;
                    }
                    else
                    {
                        pnlOrder.BackColor = Color.Orange;
                        dgvItem.BackgroundColor = Color.Orange;
                        btnDone.Enabled = true;
                        btnPrintKot.Enabled = true;
                    }
                    if (dtDetail.Rows.Count > 0)
                    {
                        floPanel.Controls.Add(pnlOrder);
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void dgvItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dgvItem = sender as DataGridView;
            dgvItem.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);

            foreach (DataGridViewRow row in dgvItem.Rows)
            if (Convert.ToDouble(row.Cells[3].Value) > 0)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 0, 16);
                row.DefaultCellStyle.ForeColor = Color.White;
                //dgvItem.Rows[row.Index].Cells[2].Style.BackColor = Color.FromArgb(255, 0, 16);

            }
            dgvItem.ClearSelection();
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            Button btnDone = sender as Button;
            string strHoldId;
            strHoldId = btnDone.Tag.ToString();
            if (UpdateStatus(strHoldId))
            {
                btnDone.Enabled = false;
            }
        }

        protected void btnPrintKot_Click(object sender, EventArgs e)
        {
            Button btnPrintKot = sender as Button;
            string strHoldId;
            strHoldId = btnPrintKot.Tag.ToString();
            PrintKot(strHoldId);
        }

        private void frmKitchenDisplay_Load(object sender, EventArgs e)
        {
            try
            {
                LoadOrders();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private bool UpdateStatus(string holdId)
        {
            bool isUpdated = false;

            int holdIdInt = 0;
            int.TryParse(holdId, out holdIdInt);

            string strSQLUpdate = "UPDATE tbl_TempHeader SET status = @status WHERE id = @holdId";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@status", System.Data.SqlDbType.NVarChar) { Value = "Done" },
                new System.Data.SqlClient.SqlParameter("@holdId", System.Data.SqlDbType.Int) { Value = holdIdInt }
            };

            int id = SecureDataAccess.ExecuteNonQuery(strSQLUpdate, parameters);
            if (id > 0)
            {
                isUpdated = true;
            }
            return isUpdated;
        }

        public void PrintKot(string holdId)
        {
            LocalReport report = new LocalReport();
            report.ReportEmbeddedResource = "cypos.Reports.rptKot.rdlc";

            report.EnableExternalImages = true;

            string strSQL = "SELECT tbl_TempHeader.order_type, tbl_TempHeader.invoice_date, tbl_TempHeader.invoice_time," +
                            "tbl_TempHeader.kot_no, tbl_TempHeader.table_id,tbl_Tables.table_name, tbl_TableLocation.location_name," +
                            "tbl_TempHeader.no_of_guests, tbl_TempHeader.waiter_id, tbl_User.name, tbl_TempHeader.note," +
                            "tbl_TempHeader.user_name, tbl_TempDetail.item_code, tbl_TempDetail.item_name, tbl_TempDetail.qty," +
                            "tbl_TempDetail.show_kitchen, tbl_TempDetail.print_kot,tbl_TempDetail.kot_qty, tbl_Company.company_name " +
                            "FROM tbl_TempHeader INNER JOIN " +
                            "tbl_TempDetail ON tbl_TempHeader.id = tbl_TempDetail.header_id LEFT JOIN " +
                            "tbl_Tables ON tbl_TempHeader.table_id = tbl_Tables.id LEFT JOIN " +
                            "tbl_TableLocation ON tbl_Tables.location_id = tbl_TableLocation.Id LEFT OUTER JOIN " +
                            "tbl_User ON tbl_TempHeader.waiter_id = tbl_User.id " +
                            "CROSS JOIN tbl_Company " +
                            "WHERE tbl_TempHeader.id  = '" + holdId + "' AND tbl_TempDetail.print_kot=1 AND tbl_TempDetail.kot_qty > 0";

            
            DataTable result = SecureDataAccess.GetDataTable(strSQL);

            ReportDataSource reportDSDetail = new ReportDataSource("dsKot", result);
            report.DataSources.Clear();
            report.DataSources.Add(reportDSDetail);
            report.Refresh();
            if (DirectPrint.Print(report, Settings.KotPrinter))
            {
                UpdateKotPrintedItems(holdId);
            }
        }

        public void UpdateKotPrintedItems(string holdId)
        {
            int holdIdInt = 0;
            int.TryParse(holdId, out holdIdInt);

            string strSQLUpdate = "UPDATE tbl_TempDetail SET kot_qty = @kotQty WHERE header_id = @headerId";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@kotQty", System.Data.SqlDbType.Int) { Value = 0 },
                new System.Data.SqlClient.SqlParameter("@headerId", System.Data.SqlDbType.Int) { Value = holdIdInt }
            };

            SecureDataAccess.ExecuteNonQuery(strSQLUpdate, parameters);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            { 
                LoadOrders();
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
    }
}
