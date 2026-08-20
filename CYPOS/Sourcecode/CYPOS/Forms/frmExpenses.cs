using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace cypos
{
    public partial class frmExpenses : Form
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

        public frmExpenses()
        {
            InitializeComponent();
            //Grid Fonts
            dgvExpenses.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvExpenses.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvExpenses.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

            dgvExpenses.Columns["clmAmount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvExpenses.Columns["clmAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvExpenses.Columns["clmAmount"].DefaultCellStyle.Format = "N2";;
        }

        private void FillCategory()
        {
            //Item Category
            string strSQL = "SELECT id,group_name FROM tbl_ExpenseGroup ORDER BY group_name ";

            DataTable dtCategory = SecureDataAccess.GetDataTable(strSQL);
            DataRow dr = dtCategory.NewRow();
            dr["id"] = 0;
            dr["group_name"] = "Select";
            dtCategory.Rows.InsertAt(dr, 0);
            cmbCategory.DataSource = dtCategory;
            cmbCategory.ValueMember = "id";
            cmbCategory.DisplayMember = "group_name";
        }

        private void ExpenseFill(string strSearch,string strDateFrom,string strDateto)
        {
            dgvExpenses.AutoGenerateColumns=false;
            string strSQL = string.Empty;
            System.Data.SqlClient.SqlParameter[] parameters;

            if (txtSearch.Text == string.Empty)
            {
                strSQL = "SELECT tbl_Expense.id, tbl_Expense.expense_date, tbl_Expense.reference_no, tbl_ExpenseGroup.group_name,"+
                         "tbl_Expense.amount, tbl_Expense.note FROM tbl_Expense " +
                         "INNER JOIN tbl_ExpenseGroup ON tbl_Expense.category_id = tbl_ExpenseGroup.id " +
                         "WHERE tbl_Expense.expense_date >= @dateFrom AND tbl_Expense.expense_date <= @dateTo";

                parameters = new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@dateFrom", System.Data.SqlDbType.NVarChar) { Value = strDateFrom },
                    new System.Data.SqlClient.SqlParameter("@dateTo", System.Data.SqlDbType.NVarChar) { Value = strDateto }
                };
            }
            else
            {
                strSQL = "SELECT tbl_Expense.id, tbl_Expense.expense_date, tbl_Expense.reference_no, tbl_ExpenseGroup.group_name," +
                         "tbl_Expense.amount, tbl_Expense.note FROM tbl_Expense " +
                         "INNER JOIN tbl_ExpenseGroup ON tbl_Expense.category_id = tbl_ExpenseGroup.id " +
                         "WHERE (tbl_Expense.reference_no LIKE @searchTerm OR tbl_ExpenseGroup.group_name LIKE @searchTerm " +
                         "OR tbl_Expense.note LIKE @searchTerm) " +
                         "AND tbl_Expense.expense_date >= @dateFrom AND tbl_Expense.expense_date <= @dateTo";

                parameters = new System.Data.SqlClient.SqlParameter[] {
                    new System.Data.SqlClient.SqlParameter("@searchTerm", System.Data.SqlDbType.NVarChar) { Value = "%" + strSearch + "%" },
                    new System.Data.SqlClient.SqlParameter("@dateFrom", System.Data.SqlDbType.NVarChar) { Value = strDateFrom },
                    new System.Data.SqlClient.SqlParameter("@dateTo", System.Data.SqlDbType.NVarChar) { Value = strDateto }
                };
            }

            DataTable dtExpense = SecureDataAccess.GetDataTable(strSQL, parameters);
            dgvExpenses.DataSource = dtExpense;
            lblRows.Text = dgvExpenses.RowCount.ToString() + " Records Found";            

            double dblSum = 0;
            for (int i = 0; i < dgvExpenses.Rows.Count; ++i)
            {
                dblSum += Convert.ToDouble(dgvExpenses.Rows[i].Cells["clmAmount"].Value);
            }
            lblTotal.Text = "Total Amount: " + Currency.Format(dblSum); 
        }

        private void frmExpenses_Load(object sender, EventArgs e)
        {
            try
            {
                ExpenseFill("", DateTime.Now.ToString("dd/MM/yyyy").ToString(), DateTime.Now.ToString("dd/MM/yyyy").ToString());
                FillCategory();
                dtpDate.Focus();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text !=string.Empty)
            {
                ExpenseFill(txtSearch.Text, dtpFrom.Text, dtpTo.Text);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExpenses.RowCount > 0)
                {
                    foreach (DataGridViewRow rowdel in dgvExpenses.SelectedRows)
                    {
                        bool result = Messages.DeleteMessage();

                        if (result == true)
                        {
                            string strSQL = "DELETE FROM tbl_Expense WHERE id = @expenseId";

                            System.Data.SqlClient.SqlParameter[] parameters = {
                                new System.Data.SqlClient.SqlParameter("@expenseId", System.Data.SqlDbType.Int)
                                    { Value = int.Parse(rowdel.Cells["clmId"].Value.ToString()) }
                            };

                            SecureDataAccess.ExecuteNonQuery(strSQL, parameters);

                            Messages.DeletedMessage();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnRowUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvExpenses;
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
            DataGridView dgv = dgvExpenses;
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

        private void Clear()
        {
            dtpDate.Value = DateTime.Now;
            txtReferNo.Clear();
            cmbCategory.SelectedIndex = 0;
            txtAmount.Clear();
            txtNote.Clear();
            dtpDate.Focus();
        }
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            ExpenseFill(txtSearch.Text, dtpFrom.Text, dtpTo.Text);
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            ExpenseFill(txtSearch.Text, dtpFrom.Text, dtpTo.Text);
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtAmount.Text.ToString(), @"\.\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategory.SelectedIndex==0)
                {
                    Messages.InformationMessage("Please select category");
                    cmbCategory.Focus();
                }
                else if (txtAmount.Text == string.Empty || txtAmount.Text == "0")
                {
                    Messages.InformationMessage("Please enter amount");
                    txtAmount.Focus();
                }
                else
                {
                    string strSQL = "INSERT INTO tbl_Expense (expense_date, reference_no, category_id, amount, note, created_by) " +
                                    "VALUES (@expenseDate, @refNo, @categoryId, @amount, @note, @createdBy)";

                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@expenseDate", System.Data.SqlDbType.NVarChar) { Value = dtpDate.Text },
                        new System.Data.SqlClient.SqlParameter("@refNo", System.Data.SqlDbType.NVarChar) { Value = txtReferNo.Text },
                        new System.Data.SqlClient.SqlParameter("@categoryId", System.Data.SqlDbType.Int) { Value = cmbCategory.SelectedValue },
                        new System.Data.SqlClient.SqlParameter("@amount", System.Data.SqlDbType.Decimal) { Value = decimal.Parse(txtAmount.Text) },
                        new System.Data.SqlClient.SqlParameter("@note", System.Data.SqlDbType.NVarChar) { Value = txtNote.Text },
                        new System.Data.SqlClient.SqlParameter("@createdBy", System.Data.SqlDbType.NVarChar) { Value = UserInfo.UserName }
                    };

                    SecureDataAccess.ExecuteNonQuery(strSQL, parameters);
                    //Messages.SavedMessage();
                    ExpenseFill(txtSearch.Text, dtpFrom.Text, dtpTo.Text);
                    Clear();
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnKbSearch_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtSearch);
            frmKeyboard.ShowDialog();
        }

        private void btnKbRef_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtReferNo);
            frmKeyboard.ShowDialog();
        }

        private void btnKbAmount_Click(object sender, EventArgs e)
        {
            frmCurrencyboard frmCurrencyboard = new frmCurrencyboard(txtAmount);
            frmCurrencyboard.ShowDialog();
        }

        private void btnKbNote_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtNote);
            frmKeyboard.ShowDialog();
        }
    }
}
