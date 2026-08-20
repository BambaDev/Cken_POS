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
    public partial class frmTableView : Form
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

        public frmTableView(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;

            LoadTableLocation();
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

        #region Table Management

        public void LoadTableLocation()
        {
            tbTableLocation.TabPages.Clear();
            try
            {
                string strSQL = @"SELECT DISTINCT tbl_Tables.location_id, tbl_TableLocation.location_name
                                 FROM tbl_Tables
                                 INNER JOIN tbl_TableLocation ON tbl_Tables.location_id = tbl_TableLocation.Id";
                DataTable dt = SecureDataAccess.GetDataTable(strSQL);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    TabPage tp = new TabPage(dataReader["location_name"].ToString());
                    tp.Padding = new Padding(10, 10, 10, 10);
                    tp.Tag = dataReader["location_id"].ToString();
                    tp.BackColor = Color.White;
                    tbTableLocation.TabPages.Add(tp);

                    FlowLayoutPanel floPanel = new FlowLayoutPanel();
                    floPanel.Dock = DockStyle.Fill;
                    LoadTables(floPanel, int.Parse(tp.Tag.ToString()));
                    tp.Controls.Add(floPanel);
                }
            }
            catch (Exception exp)
            {
                Messages.ExceptionMessage(exp.Message);
            }
        }


        public void LoadTables(FlowLayoutPanel floPanel, int locationId)
        {
            floPanel.Controls.Clear();
            try
            {
                string strSQL = @"SELECT CASE WHEN tbl_TempHeader.table_id > 0 THEN 1 ELSE 0 END AS locked,
                                 tbl_Tables.id, tbl_Tables.table_name, ISNULL(tbl_TempHeader.no_of_guests, 0) AS guest_count
                                 FROM tbl_Tables
                                 LEFT JOIN tbl_TempHeader ON tbl_Tables.id = tbl_TempHeader.table_id
                                 WHERE tbl_Tables.location_id = @locationId
                                 ORDER BY table_name";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@locationId", System.Data.SqlDbType.Int) { Value = locationId }
                };

                DataTable dt = SecureDataAccess.GetDataTable(strSQL, parameters);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Panel pnlTable = new Panel();
                    PictureBox pbxTableImage = new PictureBox();
                    Panel pnlTableName = new Panel();
                    Label lblTableName = new Label();
                    Label lblGuests = new Label();
                    PictureBox pbxTableStatus = new PictureBox();

                    pnlTable.BorderStyle = BorderStyle.FixedSingle;
                    pnlTable.Size = new Size(100, 100);
                    pbxTableImage.Cursor = Cursors.Hand;
                    lblTableName.Cursor = Cursors.Hand;
                    pbxTableStatus.Cursor = Cursors.Hand;
                    string strStatusName = dataReader["table_name"].ToString();
                    pbxTableStatus.Name = "pbx" + strStatusName.Replace(" ", "");
                    pbxTableImage.Image = cypos.Properties.Resources.table;
                    pbxTableImage.SizeMode = PictureBoxSizeMode.CenterImage;

                    pbxTableImage.Click += new EventHandler(Table_Click);
                    lblTableName.Click += new EventHandler(Table_Click);
                    pbxTableStatus.Click += new EventHandler(Table_Click);
                    lblGuests.Click += new EventHandler(Table_Click);

                    pbxTableImage.Parent = pnlTable;
                    lblGuests.Parent = pbxTableImage;
                    pnlTableName.Parent = pnlTable;
                    lblTableName.Parent = pnlTableName;
                    pbxTableStatus.Parent = pnlTableName;

                    pbxTableImage.Dock = DockStyle.Fill;
                    pnlTableName.Dock = DockStyle.Bottom;

                    lblTableName.AutoSize = false;

                    lblTableName.Dock = DockStyle.Fill;
                    pnlTableName.Height = 25;

                    pbxTableStatus.Dock = DockStyle.Right;

                    lblGuests.AutoSize = false;
                    lblGuests.Size = pbxTableImage.Size;
                    lblGuests.TextAlign = ContentAlignment.MiddleCenter;
                    lblGuests.BackColor = Color.Transparent;
                    lblGuests.ForeColor = Color.Yellow;
                    lblGuests.BringToFront();

                    bool isLocked = Convert.ToBoolean(dataReader["locked"]);
                    if (isLocked)
                    {
                        pbxTableStatus.Image = cypos.Properties.Resources.status_red;
                    }
                    else
                    {
                        pbxTableStatus.Image = cypos.Properties.Resources.status_green;
                    }


                    pbxTableStatus.SizeMode = PictureBoxSizeMode.CenterImage;
                    pbxTableStatus.Width = 25;


                    pnlTableName.BackColor = Color.FromArgb(10, 41, 98);
                    lblTableName.Tag = dataReader["id"].ToString();
                    lblTableName.Text = dataReader["table_name"].ToString();
                    int iGuestCount = int.Parse(dataReader["guest_count"].ToString());
                    if (Settings.AskGuestCount && iGuestCount != 0)
                    {
                        lblGuests.Text = dataReader["guest_count"].ToString();
                    }
                    else
                    {
                        lblGuests.Text = string.Empty;
                    }

                    lblGuests.Tag = dataReader["id"].ToString() + "," + dataReader["table_name"].ToString() + "," + isLocked.ToString();
                    lblTableName.Tag = dataReader["id"].ToString() + "," + dataReader["table_name"].ToString() + "," + isLocked.ToString();
                    pbxTableImage.Tag = dataReader["id"].ToString() + "," + dataReader["table_name"].ToString() + "," + isLocked.ToString();
                    pbxTableStatus.Tag = dataReader["id"].ToString() + "," + dataReader["table_name"].ToString() + "," + isLocked.ToString();
                    lblTableName.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
                    lblTableName.TextAlign = ContentAlignment.MiddleLeft;
                    lblTableName.ForeColor = Color.White;
                    floPanel.Controls.Add(pnlTable);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        protected void Table_Click(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Label lblTable = sender as Label;
                string strTable = lblTable.Tag.ToString();

                string[] table = strTable.Split(',');
                string pbxStatus = table[2].ToString();
                if (Settings.AskTable && !Settings.AskGuestCount && !Settings.AskWaiter)
                {
                    if (pbxStatus == "True")
                    {
                        MessageBox.Show("Locked");
                    }
                    else
                    {
                        _frmMain.SetTable(int.Parse(table[0]),table[1].ToString(),0,0,string.Empty);
                        this.Close();
                    }
                }
                else if (Settings.AskTable && (Settings.AskGuestCount || Settings.AskWaiter))
                {
                    if (pbxStatus == "True")
                    {
                        MessageBox.Show("Locked");
                    }
                    else
                    {
                        frmOpenTable frmOpenTable = new frmOpenTable(_frmMain);
                        frmOpenTable.TableId = int.Parse(table[0]);
                        frmOpenTable.TableNo = table[1].ToString();
                        string strStatusName = table[1].ToString();
                        frmOpenTable.pbxStatusName = "pbx" + strStatusName.Replace(" ", "");
                        frmOpenTable.ShowDialog();
                        this.Close();
                    }
                    //PictureBox pbx = (PictureBox)tbTableLocation.Controls.Find("pbx" + table[1].Replace(" ", ""), true)[0];
                    //string pbxStatus = table[2].ToString();

                    //if (pbxStatus == "True")
                    //{
                    //    MessageBox.Show("Locked");
                    //}
                    //else
                    //{
                        //frmOpenTable frmOpenTable = new frmOpenTable(this);
                        //frmOpenTable.TableId = int.Parse(table[0]);
                        //frmOpenTable.TableNo = table[1].ToString();
                        //string strStatusName = table[1].ToString();
                        //frmOpenTable.pbxStatusName = "pbx" + strStatusName.Replace(" ", "");
                        //frmOpenTable.ShowDialog();
                    //}
                }
                //if (Settings.AskTable && !Settings.AskGuestCount && !Settings.AskWaiter)
                //{
                //    lblTableNo.Tag = lblTable.Tag;
                //    lblTableNo.Text = "Table#: " + lblTable.Text.ToString();
                //    pnlTables.Visible = false;
                //    pnlLeft.Enabled = true;
                //    pnlBottom.Enabled = true;
                //}
                //else if (Settings.AskTable && (Settings.AskGuestCount || Settings.AskWaiter))
                //{
                //    frmOpenTable frmOpenTable = new frmOpenTable(this);
                //    frmOpenTable.TableId = int.Parse(lblTable.Tag.ToString());
                //    frmOpenTable.TableNo = lblTable.Text.ToString();

                //    string strStatusName =lblTable.Text.ToString();
                //    frmOpenTable.pbxStatusName = "pbx" + strStatusName.Replace(" ", "");
                //    frmOpenTable.ShowDialog();
                //}
            }
            else if (sender is PictureBox)
            {
                PictureBox pbxTable = sender as PictureBox;
                string strTable = pbxTable.Tag.ToString();

                string[] table = strTable.Split(',');

                if (Settings.AskTable && !Settings.AskGuestCount && !Settings.AskWaiter)
                {
                    //lblTableNo.Tag = table[0];
                    //lblTableNo.Text = "Table#: " + table[1].ToString();
                    //pnlTables.Visible = false;
                    //pnlLeft.Enabled = true;
                    //pnlBottom.Enabled = true;
                }
                else if (Settings.AskTable && (Settings.AskGuestCount || Settings.AskWaiter))
                {
                    //PictureBox pbx = (PictureBox)tbTableLocation.Controls.Find("pbx" + table[1].Replace(" ", ""), true)[0];
                    string pbxStatus = table[2].ToString();

                    if (pbxStatus == "True")
                    {
                        MessageBox.Show("Locked");
                    }
                    else
                    {
                        //frmOpenTable frmOpenTable = new frmOpenTable(this);
                        //frmOpenTable.TableId = int.Parse(table[0]);
                        //frmOpenTable.TableNo = table[1].ToString();
                        //string strStatusName = table[1].ToString();
                        //frmOpenTable.pbxStatusName = "pbx" + strStatusName.Replace(" ", "");
                        //frmOpenTable.ShowDialog();
                    }
                }
            }
        }
        #endregion 
    }
}
