using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace cypos
{
    public partial class frmCustomer : Form
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

        public frmCustomer()
        {
            InitializeComponent();
            //Grid Fonts
            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvCustomers.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvCustomers.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

            //History Grid Alignment
            dgvHistory.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHistory.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHistory.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvHistory.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHistory.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHistory.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvHistory.Columns[3].DefaultCellStyle.Format = "N2";
            dgvHistory.Columns[4].DefaultCellStyle.Format = "N2";
            dgvHistory.Columns[5].DefaultCellStyle.Format = "N2";

            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvHistory.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvHistory.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

            CustomerGridFill();
            btnCustomerUp.Enabled = false;
            btnCustomerDown.Enabled = false;
        }


        public void CustomerGridFill()
        {
            dgvCustomers.AutoGenerateColumns = false;
            string sqlCmd = "SELECT * FROM  tbl_Customer";
            DataTable dt1 = SecureDataAccess.GetDataTable(sqlCmd);
            dgvCustomers.DataSource = dt1;
            dgvCustomers.Columns["clmCity"].Width = 150;
            dgvCustomers.Columns["clmPhone"].Width = 150;
        }

        private void Clear()
        {
            lblCustomerId.Text = "-";
            txtCustomerName.Clear();
            txtCustomerAddress.Clear();
            txtCity.Clear();
            txtPhone.Clear();
            txtEmailAddress.Clear();
            txtSearchCustomer.Clear();
            dgvCustomers.ClearSelection();
            dgvHistory.DataSource = null;
            btnCustomerUp.Enabled = false;
            btnCustomerDown.Enabled = false;
            txtCustomerName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCustomerId.Text == "-")
                {
                    // CREATE NEW CUSTOMER with secure parameterized query
                    if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
                    {
                        Messages.InformationMessage("Enter customer name");
                        txtCustomerName.Focus();
                        return;
                    }
                    else if (string.IsNullOrWhiteSpace(txtCustomerAddress.Text))
                    {
                        Messages.InformationMessage("Enter address");
                        txtCustomerAddress.Focus();
                        return;
                    }
                    else if (string.IsNullOrWhiteSpace(txtCity.Text))
                    {
                        Messages.InformationMessage("Enter city");
                        txtCity.Focus();
                        return;
                    }
                    else if (string.IsNullOrWhiteSpace(txtPhone.Text))
                    {
                        Messages.InformationMessage("Enter phone");
                        txtPhone.Focus();
                        return;
                    }

                    string strSQLInsert = @"INSERT INTO tbl_Customer (name, address, city, phone, email)
                                           VALUES (@name, @address, @city, @phone, @email)";

                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.NVarChar, 100) { Value = txtCustomerName.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.NVarChar, 200) { Value = txtCustomerAddress.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.NVarChar, 50) { Value = txtCity.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.NVarChar, 20) { Value = txtPhone.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar, 100) { Value = txtEmailAddress.Text.Trim() }
                    };

                    SecureDataAccess.ExecuteNonQuery(strSQLInsert, parameters);
                    Messages.SavedMessage();
                    Clear();
                }
                else  //Update
                {
                    // UPDATE EXISTING CUSTOMER with secure parameterized query
                    string strSQLUpdate = @"UPDATE tbl_Customer
                                           SET name = @name,
                                               address = @address,
                                               city = @city,
                                               phone = @phone,
                                               email = @email
                                           WHERE id = @customerId";

                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.NVarChar, 100) { Value = txtCustomerName.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.NVarChar, 200) { Value = txtCustomerAddress.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.NVarChar, 50) { Value = txtCity.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.NVarChar, 20) { Value = txtPhone.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar, 100) { Value = txtEmailAddress.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@customerId", System.Data.SqlDbType.Int) { Value = Convert.ToInt32(lblCustomerId.Text) }
                    };

                    SecureDataAccess.ExecuteNonQuery(strSQLUpdate, parameters);
                    Messages.UpdatedMessage();
                }
                CustomerGridFill();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }   
        }


        private void frmCustomer_Load(object sender, EventArgs e)
        {
            Clear();
        }


        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


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

        private void btnCustomerUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvCustomers;
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

        private void btnCustomerDown_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvCustomers;
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

        #region Common
        private bool RowIsVisible(DataGridViewRow row)
        {
            DataGridView dgv = row.DataGridView;
            int firstVisibleRowIndex = dgv.FirstDisplayedCell.RowIndex;
            int lastVisibleRowIndex = firstVisibleRowIndex + dgv.DisplayedRowCount(false) - 1;
            //return row.Index >= firstVisibleRowIndex && row.Index <= lastVisibleRowIndex;
            return row.Index >= lastVisibleRowIndex;
        }

        #endregion

        private void LoadHistory(string strCustomerId)
        {
            try
            {
                dgvHistory.AutoGenerateColumns = false;

                string strSQL = "SELECT invoice_id, invoice_date, payment_amount, " +
                            "   (payment_amount - due_amount) AS paid_amount,  payment_type, " +
                            "   due_amount, user_name,customer_id, note " +
                            "   FROM tbl_InvoiceHeader   WHERE customer_id = @customerId ORDER BY  invoice_id DESC";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@customerId", System.Data.SqlDbType.Int) { Value = int.Parse(strCustomerId) }
                };

                DataTable dtHistory = SecureDataAccess.GetDataTable(strSQL, parameters);
                dgvHistory.DataSource = dtHistory;

                //dgvHistory.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvHistory.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvHistory.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                //dgvHistory.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvHistory.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgvHistory.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //dgvHistory.Columns[3].DefaultCellStyle.Format="N2";
                //dgvHistory.Columns[4].DefaultCellStyle.Format="N2";
                //dgvHistory.Columns[5].DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }   
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnCustomerUp.Enabled = true;
                btnCustomerDown.Enabled = true;
                DataGridViewRow row = dgvCustomers.Rows[dgvCustomers.CurrentRow.Index];

                lblCustomerId.Text = row.Cells["clmCustomerId"].Value.ToString();
                txtCustomerName.Text = row.Cells["clmCustomer"].Value.ToString();
                txtCustomerAddress.Text = row.Cells["clmAddress"].Value.ToString();
                txtCity.Text = row.Cells["clmCity"].Value.ToString();
                txtPhone.Text = row.Cells["clmPhone"].Value.ToString();
                txtEmailAddress.Text = row.Cells["clmEmail"].Value.ToString();

                LoadHistory(lblCustomerId.Text);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
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

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvHistory.DataSource = null;
                string strSQL = @" SELECT * FROM  tbl_Customer
                                WHERE name like '%' + @searchText + '%' or
                                id like '%' + @searchText + '%' or
                                phone like '%' + @searchText + '%' or
                                city like '%' + @searchText + '%' or
                                address like '%' + @searchText + '%'";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@searchText", System.Data.SqlDbType.NVarChar) { Value = txtSearchCustomer.Text }
                };

                DataTable dtCustomers = SecureDataAccess.GetDataTable(strSQL, parameters);
                dgvCustomers.DataSource = dtCustomers;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Delete customer  
            foreach (DataGridViewRow rowdel in dgvCustomers.SelectedRows)
            {
                bool result = Messages.DeleteMessage();

                if (result == true)
                {
                    int customerId = 0;
                    int.TryParse(rowdel.Cells[0].Value.ToString(), out customerId);

                    string strSQLDelete = "DELETE FROM tbl_Customer WHERE id = @customerId";

                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@customerId", System.Data.SqlDbType.Int) { Value = customerId }
                    };

                    SecureDataAccess.ExecuteNonQuery(strSQLDelete, parameters);
                    Messages.DeletedMessage();
                    CustomerGridFill();
                    Clear();
                }
            }
        }

        private void btnKbCustomerSearch_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtSearchCustomer);
            frmKeyboard.ShowDialog();
        }

        private void btnKbName_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtCustomerName);
            frmKeyboard.ShowDialog();
        }

        private void btnKbAddress_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtCustomerAddress);
            frmKeyboard.ShowDialog();
        }

        private void btnKbCity_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtCity);
            frmKeyboard.ShowDialog();
        }

        private void btnKbPhone_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtPhone);
            frmKeyboard.ShowDialog();
        }

        private void btnKbEmail_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtEmailAddress);
            frmKeyboard.ShowDialog();
        }
    }
}
