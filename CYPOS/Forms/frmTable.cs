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
    public partial class frmTable : Form
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

        public frmTable(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm; 
        }
	


        public string TableId
        {
            set { lblTableId.Text = value;} 
            get{return lblTableId.Text;}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                 if (txtTableName.Text == "") 
                 { 
                     Messages.InformationMessage("Enter table name"); 
                     txtTableName.Focus(); 
                 }
                else
                 {
                     int noOfChairs = 0;
                     int.TryParse(txtNoOfChairs.Text, out noOfChairs);

                     if (lblTableId.Text == "-")
                     {
                         if (DataAccess.RecordExits("tbl_Tables", "table_name", txtTableName.Text) ==1)
                         {
                             Messages.InformationMessage("Table already exist");
                             txtTableName.Focus();
                         }
                         else
                         {
                             string strSQLInsert = @"INSERT INTO tbl_Tables (table_name, no_of_chairs, location_id)
                                                    VALUES (@tableName, @noOfChairs, @locationId)";

                             System.Data.SqlClient.SqlParameter[] parameters = {
                                 new System.Data.SqlClient.SqlParameter("@tableName", System.Data.SqlDbType.NVarChar) { Value = txtTableName.Text },
                                 new System.Data.SqlClient.SqlParameter("@noOfChairs", System.Data.SqlDbType.Int) { Value = noOfChairs },
                                 new System.Data.SqlClient.SqlParameter("@locationId", System.Data.SqlDbType.Int) { Value = cmbLocation.SelectedValue }
                             };

                             SecureDataAccess.ExecuteNonQuery(strSQLInsert, parameters);
                             LoadTableList("");
                             Clear();
                         }
                     }
                     else
                     {
                         int tableId = 0;
                         int.TryParse(lblTableId.Text, out tableId);

                         string strSQLUpdate = @"UPDATE tbl_Tables SET
                              table_name = @tableName,
                              no_of_chairs = @noOfChairs,
                              location_id = @locationId
                              WHERE id = @tableId";

                         System.Data.SqlClient.SqlParameter[] parameters = {
                             new System.Data.SqlClient.SqlParameter("@tableName", System.Data.SqlDbType.NVarChar) { Value = txtTableName.Text },
                             new System.Data.SqlClient.SqlParameter("@noOfChairs", System.Data.SqlDbType.Int) { Value = noOfChairs },
                             new System.Data.SqlClient.SqlParameter("@locationId", System.Data.SqlDbType.Int) { Value = cmbLocation.SelectedValue },
                             new System.Data.SqlClient.SqlParameter("@tableId", System.Data.SqlDbType.Int) { Value = tableId }
                         };

                         SecureDataAccess.ExecuteNonQuery(strSQLUpdate, parameters);
                         LoadTableList("");
                         Clear();
                         OpenedForms.Close();
                     }
                 }         
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void frmTable_Load(object sender, EventArgs e)
        {
            try
            {
                //Table Location
                string strSQL = "SELECT id,location_name FROM tbl_TableLocation ORDER BY location_name";
                DataTable dtLocation = SecureDataAccess.GetDataTable(strSQL);
                cmbLocation.DataSource = dtLocation;
                cmbLocation.ValueMember = "id";
                cmbLocation.DisplayMember = "location_name";

                LoadTableList();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void Clear()
        {
            lblTableId.Text = "-";
            txtTableName.Clear();
            txtNoOfChairs.Text = "0";
            cmbLocation.SelectedIndex = 0;
            txtTableName.Focus();
        }

        public void LoadTableList(string value="")
        {
            floTableList.Controls.Clear();

            try
            {
                string strSQL = "SELECT * FROM tbl_Tables WHERE (table_name like @searchValue + '%' ) ORDER BY table_name";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@searchValue", System.Data.SqlDbType.NVarChar) { Value = value }
                };

                DataTable dt = SecureDataAccess.GetDataTable(strSQL, parameters);
                lblRows.Text = "Total " + dt.Rows.Count.ToString() + " Tables Found";

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button btnTable = new Button();
                    btnTable.Name = dataReader["id"].ToString();
                    btnTable.Tag = dataReader["id"];
                    btnTable.Text = "Table" + "\n " + dataReader["table_name"].ToString();
                    //btnTable.Text += dataReader["no_of_chairs"].ToString();

                    btnTable.Margin = new Padding(3, 3, 3, 3);
                    btnTable.Size = new Size(100, 50);

                    btnTable.Font = new Font("Tahoma", 9, FontStyle.Regular, GraphicsUnit.Point);
                    btnTable.TextAlign = ContentAlignment.MiddleCenter;
                    btnTable.Click += new EventHandler(btnTable_Click);
                    floTableList.Controls.Add(btnTable);
                    currentImage++;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        protected void btnTable_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string s;
            s = b.Tag.ToString();
            this.TableId = s;
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
            bool result = Messages.DeleteMessage();

            if (result == true)
            {
                if (lblTableId.Text != "-")
                {
                    int tableId = 0;
                    int.TryParse(lblTableId.Text, out tableId);

                    string strSQLDelete = "DELETE FROM tbl_Tables WHERE id = @tableId";

                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@tableId", System.Data.SqlDbType.Int) { Value = tableId }
                    };

                    SecureDataAccess.ExecuteNonQuery(strSQLDelete, parameters);
                    //Messages.DeletedMessage();
                    LoadTableList("");
                    Clear();
                }
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

        private void lblTableId_TextChanged(object sender, EventArgs e)
        {
            if (lblTableId.Text != "-")
            {
                GetTableById(lblTableId.Text);
                btnDelete.Visible = true;
            }
        }

        private void GetTableById(string TableId)
        {
            string strSQL = "SELECT * FROM tbl_Tables WHERE (id = @tableId)";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@tableId", System.Data.SqlDbType.Int) { Value = int.Parse(TableId) }
            };

            DataTable dtTable = SecureDataAccess.GetDataTable(strSQL, parameters);

            lblTableId.Text = dtTable.Rows[0]["id"].ToString();
            txtTableName.Text = dtTable.Rows[0]["table_name"].ToString();
            txtNoOfChairs.Text = dtTable.Rows[0]["no_of_chairs"].ToString();
            cmbLocation.SelectedValue = int.Parse(dtTable.Rows[0]["location_id"].ToString());
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTableList(txtSearch.Text.ToString());
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtNoOfChairs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

        private void btnKbSearch_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtSearch);
            frmKeyboard.ShowDialog();
        }

        private void btnKbTable_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtTableName);
            frmKeyboard.ShowDialog();
        }

        private void btnKbNoOfCharge_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtNoOfChairs);
            frmNumberboard.ShowDialog();
        }
    }
}
