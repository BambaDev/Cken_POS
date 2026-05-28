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
    public partial class frmTableLocation : Form
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

        public frmTableLocation(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm; 
        }
	


        public string TableId
        {
            set { lblLocationId.Text = value;} 
            get{return lblLocationId.Text;}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                 if (txtLocation.Text == "") 
                 { 
                     Messages.InformationMessage("Enter table location"); 
                     txtLocation.Focus(); 
                 }
                else
                 {
                     if (lblLocationId.Text == "-")
                     {
                         if (DataAccess.RecordExits("tbl_TableLocation", "location_name", txtLocation.Text) == 1)
                         {
                             Messages.InformationMessage("Location already exist");
                             txtLocation.Focus();
                         }
                         else
                         {
                             string strSQLInsert = "INSERT INTO tbl_TableLocation (location_name) VALUES (@locationName)";

                             System.Data.SqlClient.SqlParameter[] parameters = {
                                 new System.Data.SqlClient.SqlParameter("@locationName", System.Data.SqlDbType.NVarChar) { Value = txtLocation.Text }
                             };

                             SecureDataAccess.ExecuteNonQuery(strSQLInsert, parameters);
                             LoadLocationList("");
                             Clear();
                         }
                     }
                     else
                     {
                         int locationId = 0;
                         int.TryParse(lblLocationId.Text, out locationId);

                         string strSQLUpdate = "UPDATE tbl_TableLocation SET location_name = @locationName WHERE id = @locationId";

                         System.Data.SqlClient.SqlParameter[] parameters = {
                             new System.Data.SqlClient.SqlParameter("@locationName", System.Data.SqlDbType.NVarChar) { Value = txtLocation.Text },
                             new System.Data.SqlClient.SqlParameter("@locationId", System.Data.SqlDbType.Int) { Value = locationId }
                         };

                         SecureDataAccess.ExecuteNonQuery(strSQLUpdate, parameters);
                         LoadLocationList("");
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

        private void frmTableLocation_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLocationList();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void Clear()
        {
            lblLocationId.Text = "-";
            txtLocation.Clear();
            txtLocation.Focus();
        }

        public void LoadLocationList(string value="")
        {
            floLocationList.Controls.Clear();

            try
            {
                string strSQL = "SELECT * FROM tbl_TableLocation ORDER BY location_name";
                DataTable dt = SecureDataAccess.GetDataTable(strSQL);

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button btnTable = new Button();
                    btnTable.Name = dataReader["id"].ToString();
                    btnTable.Tag = dataReader["id"];
                    btnTable.Text = dataReader["location_name"].ToString();
                    //btnTable.Text += dataReader["no_of_chairs"].ToString();

                    btnTable.Margin = new Padding(3, 3, 3, 3);
                    btnTable.Size = new Size(100, 50);

                    btnTable.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
                    btnTable.TextAlign = ContentAlignment.MiddleCenter;
                    btnTable.Click += new EventHandler(btnTable_Click);
                    floLocationList.Controls.Add(btnTable);
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
                if (lblLocationId.Text != "-")
                {
                    int locationId = 0;
                    int.TryParse(lblLocationId.Text, out locationId);

                    string strSQLDelete = "DELETE FROM tbl_TableLocation WHERE id = @locationId";

                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@locationId", System.Data.SqlDbType.Int) { Value = locationId }
                    };

                    SecureDataAccess.ExecuteNonQuery(strSQLDelete, parameters);
                    //Messages.DeletedMessage();
                    LoadLocationList("");
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
            if (lblLocationId.Text != "-")
            {
                GetLocationById(lblLocationId.Text);
                btnDelete.Visible = true;
            }
        }

        private void GetLocationById(string strLocationId)
        {
            string strSQL = "SELECT * FROM tbl_TableLocation WHERE (id = @locationId)";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@locationId", System.Data.SqlDbType.Int) { Value = int.Parse(strLocationId) }
            };

            DataTable dtTable = SecureDataAccess.GetDataTable(strSQL, parameters);

            lblLocationId.Text = dtTable.Rows[0]["id"].ToString();
            txtLocation.Text = dtTable.Rows[0]["location_name"].ToString();
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


        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnKbLocation_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtLocation);
            frmKeyboard.ShowDialog();
        }
    }
}
