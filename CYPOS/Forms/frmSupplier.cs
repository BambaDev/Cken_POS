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
    public partial class frmSupplier : Form
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

        public frmSupplier()
        {
            InitializeComponent();
            //Grid Fonts
            dgvSuppliers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvSuppliers.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvSuppliers.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

            SupplierGridFill();
            btnSupplierUp.Enabled = false;
            btnSupplierDown.Enabled = false;
        }


        public void SupplierGridFill()
        {
            dgvSuppliers.AutoGenerateColumns = false;
            string strSQL = "SELECT * FROM tbl_Supplier";
            DataTable dtSupplier = SecureDataAccess.GetDataTable(strSQL);
            dgvSuppliers.DataSource = dtSupplier;
            dgvSuppliers.Columns["clmPhone"].Width = 150;
        }

        private void Clear()
        {
            lblSupplierId.Text = "-";
            txtSupplierName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtSearchSupplier.Clear();
            dgvSuppliers.ClearSelection();
            btnSupplierUp.Enabled = false;
            btnSupplierDown.Enabled = false;
            txtSupplierName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblSupplierId.Text == "-")
                {
                    // CREATE NEW SUPPLIER with secure parameterized query
                    if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
                    {
                        Messages.InformationMessage("Enter supplier name");
                        txtSupplierName.Focus();
                        return;
                    }

                    string strSQLInsert = @"INSERT INTO tbl_Supplier (name, address, phone, email)
                                           VALUES (@name, @address, @phone, @email)";

                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.NVarChar, 100) { Value = txtSupplierName.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.NVarChar, 200) { Value = txtAddress.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.NVarChar, 20) { Value = txtPhone.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar, 100) { Value = txtEmail.Text.Trim() }
                    };

                    SecureDataAccess.ExecuteNonQuery(strSQLInsert, parameters);
                    Messages.SavedMessage();
                    Clear();
                }
                else  //Update
                {
                    // UPDATE EXISTING SUPPLIER with secure parameterized query
                    string strSQLUpdate = @"UPDATE tbl_Supplier
                                           SET name = @name,
                                               address = @address,
                                               phone = @phone,
                                               email = @email
                                           WHERE id = @supplierId";

                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.NVarChar, 100) { Value = txtSupplierName.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.NVarChar, 200) { Value = txtAddress.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@phone", System.Data.SqlDbType.NVarChar, 20) { Value = txtPhone.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar, 100) { Value = txtEmail.Text.Trim() },
                        new System.Data.SqlClient.SqlParameter("@supplierId", System.Data.SqlDbType.Int) { Value = Convert.ToInt32(lblSupplierId.Text) }
                    };

                    SecureDataAccess.ExecuteNonQuery(strSQLUpdate, parameters);
                    Messages.UpdatedMessage();
                }
                SupplierGridFill();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }


        private void frmSupplier_Load(object sender, EventArgs e)
        {
            Clear();
        }


        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //DataGridViewRow row = dgvHistory.Rows[e.RowIndex];                           
                ////this.Hide();
                //Supplier.Due_payment_History go = new Supplier.Due_payment_History(row.Cells["supplier"].Value.ToString(), row.Cells["Invoice#"].Value.ToString());
                //go.MdiParent = this.ParentForm;
                //go.ShowDialog();

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

        private void btnSupplierUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvSuppliers;
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

        private void btnSupplierDown_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvSuppliers;
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

   
        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSupplierUp.Enabled = true;
                btnSupplierDown.Enabled = true;
                DataGridViewRow row = dgvSuppliers.Rows[dgvSuppliers.CurrentRow.Index];

                lblSupplierId.Text = row.Cells["clmSupplierId"].Value.ToString();
                txtSupplierName.Text = row.Cells["clmSupplier"].Value.ToString();
                txtAddress.Text = row.Cells["clmAddress"].Value.ToString();
                txtPhone.Text = row.Cells["clmPhone"].Value.ToString();
                txtEmail.Text = row.Cells["clmEmail"].Value.ToString();
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

        private void txtSearchSupplier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strSQL = @"SELECT * FROM tbl_Supplier
                                 WHERE name LIKE '%' + @searchText + '%' OR
                                       id LIKE '%' + @searchText + '%' OR
                                       phone LIKE '%' + @searchText + '%' OR
                                       address LIKE '%' + @searchText + '%'";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@searchText", System.Data.SqlDbType.NVarChar) { Value = txtSearchSupplier.Text }
                };

                DataTable dtSuppliers = SecureDataAccess.GetDataTable(strSQL, parameters);
                dgvSuppliers.DataSource = dtSuppliers;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Delete supplier
            foreach (DataGridViewRow rowdel in dgvSuppliers.SelectedRows)
            {
                bool result = Messages.DeleteMessage();

                if (result == true)
                {
                    int supplierId = 0;
                    int.TryParse(rowdel.Cells[0].Value.ToString(), out supplierId);

                    string strSQLDelete = "DELETE FROM tbl_Supplier WHERE id = @supplierId";

                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@supplierId", System.Data.SqlDbType.Int) { Value = supplierId }
                    };

                    SecureDataAccess.ExecuteNonQuery(strSQLDelete, parameters);
                    Messages.DeletedMessage();
                    SupplierGridFill();
                    Clear();
                }
            }
        }

        private void btnKbSearch_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtSearchSupplier);
            frmKeyboard.ShowDialog();
        }

        private void btnKbName_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtSupplierName);
            frmKeyboard.ShowDialog();
        }

        private void btnKbAddress_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtAddress);
            frmKeyboard.ShowDialog();
        }

        private void btnKbPhone_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtPhone);
            frmKeyboard.ShowDialog();
        }

        private void btnKbEmail_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtEmail);
            frmKeyboard.ShowDialog();
        }
    }
}
