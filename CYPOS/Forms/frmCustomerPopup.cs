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
    public partial class frmCustomerPopup : Form
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

        public frmCustomerPopup(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;

            dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvCustomers.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvCustomers.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

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

        public void CustomerGridFill()
        {
            dgvCustomers.AutoGenerateColumns = false;
            string strSQL = "SELECT * FROM tbl_Customer";
            DataTable dtCustomer = SecureDataAccess.GetDataTable(strSQL);
            dgvCustomers.DataSource = dtCustomer;
            dgvCustomers.Columns["clmCity"].Width = 125;
            dgvCustomers.Columns["clmPhone"].Width = 150;
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

        private bool RowIsVisible(DataGridViewRow row)
        {
            DataGridView dgv = row.DataGridView;
            int firstVisibleRowIndex = dgv.FirstDisplayedCell.RowIndex;
            int lastVisibleRowIndex = firstVisibleRowIndex + dgv.DisplayedRowCount(false) - 1;
            //return row.Index >= firstVisibleRowIndex && row.Index <= lastVisibleRowIndex;
            return row.Index >= lastVisibleRowIndex;
        }

        private void SearchCustomer(string strFieldName, string strSearchText)
        {
            try
            {
                string strSQL = string.Format("SELECT * FROM tbl_Customer WHERE {0} LIKE '%' + @searchText + '%'", strFieldName);

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@searchText", System.Data.SqlDbType.NVarChar) { Value = strSearchText }
                };

                DataTable dtCustomers = SecureDataAccess.GetDataTable(strSQL, parameters);
                dgvCustomers.DataSource = dtCustomers;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "") { Messages.InformationMessage("Enter Customer Name"); txtName.Focus(); }
                else if (txtAddress.Text == "") { Messages.InformationMessage("Enter Address"); txtAddress.Focus(); }
                else if (txtCity.Text == "") { Messages.InformationMessage("Enter City"); txtCity.Focus(); }
                else if (txtPhone.Text == "") { Messages.InformationMessage("Enter Phone No."); txtPhone.Focus(); }
                else
                {
                    if (lblCustomerId.Text == "-")
                    {
                        string strSQLInsert = @"INSERT INTO tbl_Customer (name, address, city, phone, email)
                                               VALUES (@name, @address, @city, @phone, @email);
                                               SELECT CAST(SCOPE_IDENTITY() AS INT)";

                        System.Data.SqlClient.SqlParameter[] parameters = {
                            new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.NVarChar) { Value = txtName.Text },
                            new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.NVarChar) { Value = txtAddress.Text },
                            new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.NVarChar) { Value = txtCity.Text },
                            new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.NVarChar) { Value = txtPhone.Text },
                            new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar) { Value = txtEmail.Text }
                        };

                        object result = SecureDataAccess.ExecuteScalar(strSQLInsert, parameters);
                        int LastInsertedId = Convert.ToInt32(result);
                        _frmMain.SetCustomer(LastInsertedId, txtName.Text);
                        //Messages.InformationMessage("Successfully saved");
                    }
                    else
                    {
                        int customerId = 0;
                        int.TryParse(lblCustomerId.Text, out customerId);

                        string strSQLUpdate = @"UPDATE tbl_Customer
                                               SET name = @name,
                                                   address = @address,
                                                   city = @city,
                                                   phone = @phone,
                                                   email = @email
                                               WHERE id = @customerId";

                        System.Data.SqlClient.SqlParameter[] parameters = {
                            new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.NVarChar) { Value = txtName.Text },
                            new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.NVarChar) { Value = txtAddress.Text },
                            new System.Data.SqlClient.SqlParameter("@city", System.Data.SqlDbType.NVarChar) { Value = txtCity.Text },
                            new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.NVarChar) { Value = txtPhone.Text },
                            new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar) { Value = txtEmail.Text },
                            new System.Data.SqlClient.SqlParameter("@customerId", System.Data.SqlDbType.Int) { Value = customerId }
                        };

                        SecureDataAccess.ExecuteNonQuery(strSQLUpdate, parameters);
                        _frmMain.SetCustomer(customerId, txtName.Text);
                        //Messages.InformationMessage("Successfully Updated");
                    }
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                Messages.InformationMessage("Record Exits");
            }
        }


        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    lblCustomerId.Text = dgvCustomers.CurrentRow.Cells["clmId"].Value.ToString();
                    txtName.Text = dgvCustomers.CurrentRow.Cells["clmName"].Value.ToString();
                    txtAddress.Text = dgvCustomers.CurrentRow.Cells["clmAddress"].Value.ToString();
                    txtCity.Text = dgvCustomers.CurrentRow.Cells["clmCity"].Value.ToString();
                    txtPhone.Text = dgvCustomers.CurrentRow.Cells["clmPhone"].Value.ToString();
                    txtEmail.Text = dgvCustomers.CurrentRow.Cells["clmEmail"].Value.ToString();
                    btnSelectAndClose.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnKbCusName_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtName);
            frmKeyboard.ShowDialog();
        }

        private void btnKbCusAddress_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtAddress);
            frmKeyboard.ShowDialog();
        }

        private void btnKbCusCity_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtCity);
            frmKeyboard.ShowDialog();
        }

        private void btnKbCusPhone_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtPhone);
            frmKeyboard.ShowDialog();
        }

        private void btnKbCusEmail_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtEmail);
            frmKeyboard.ShowDialog();
        }

        private void frmCustomerPopup_Load(object sender, EventArgs e)
        {
            CustomerGridFill();
            Clear();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer("name", txtName.Text);
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer("city", txtCity.Text);
        }

        private void txtCustomerAddress_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer("address", txtAddress.Text);
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer("phone", txtPhone.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CustomerGridFill();
            Clear();
        }

        private void Clear()
        {
            lblCustomerId.Text = "-";
            txtName.Clear();
            txtAddress.Clear();
            txtCity.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            btnSelectAndClose.Enabled = false;
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

        private void btnSelectAndClose_Click(object sender, EventArgs e)
        {
            _frmMain.SetCustomer(int.Parse(lblCustomerId.Text), txtName.Text);
            this.Close();
        }
    }
}
