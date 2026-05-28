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
    public partial class frmOpenTable : Form
    {
        private frmMain _frmMain;
        string pbxName;
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

        int tableId;

        public frmOpenTable(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm; 
            formFunctionPointer += new functioncall(Replicate); 
            numberPad1.CoinandNotesFunctionPointer = formFunctionPointer;

            numformFunctionPointer += new numvaluefunctioncall(NumaricKeypad);
            numberPad1.NumaricKeypad = numformFunctionPointer;
        }

        public int TableId
        {
            set
            {
                tableId = value;
            }
            get
            {
                return tableId;
            }
        }

        public string TableNo
        {
            set
            {
                lblTableNo.Text = value;
            }
            get
            {
                return lblTableNo.Text;
            }
        }

        public string pbxStatusName
        {
            set
            {
                pbxName = value;
            }
            get
            {
                return pbxName;
            }
        }


        #region Number Pad
        public delegate void functioncall(string currencyvalue);
        public delegate void numvaluefunctioncall(string Numvalue);

        private event functioncall formFunctionPointer;
        private event numvaluefunctioncall numformFunctionPointer;

        private void Replicate(string currencyvalue)
        {
            if (currencyvalue == "XX") // All clear
            {
                txtGuestCount.Text = "";
            }
            else if (currencyvalue == "BXC") //Backspace
            {
                if ((String.Compare(txtGuestCount.Text, " ") < 0))
                {
                    txtGuestCount.Text = txtGuestCount.Text.Substring(0, txtGuestCount.Text.Length - 1 + 1);
                }
                else
                {
                    txtGuestCount.Text = txtGuestCount.Text.Substring(0, txtGuestCount.Text.Length - 1);
                }
                txtGuestCount.Focus();
            }
        }

        private void NumaricKeypad(string Numvalue)
        {
            txtGuestCount.Text += Numvalue;
            txtGuestCount.Focus();
        }
        #endregion

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

        public void LoadUserList()
        {
            floUserList.Controls.Clear();
            string strSQL = string.Empty;
            string img_directory = Application.StartupPath + @"\Images\";
            string[] files = Directory.GetFiles(img_directory, "*.jpg *.png"); // "*.png"

            try
            {
                strSQL = "SELECT * FROM tbl_User WHERE user_type != 'Admin'";
                DataTable dt = SecureDataAccess.GetDataTable(strSQL);

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    //Button click event
                    Button b = new Button();
                    b.Tag = dataReader["id"];
                    b.Click += new EventHandler(btnUser_Click);
                    b.Name = dataReader["name"].ToString() + "\n Contact: " + dataReader["contact"].ToString();

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(88, 88);
                    il.Images.Add(Image.FromFile(img_directory + dataReader["image_name"]));

                    b.Image = il.Images[0];
                    b.Margin = new Padding(2, 2, 2, 2);

                    b.Size = new Size(100,120);

                    b.Text = "\n" + dataReader["name"].ToString();

                    b.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
                    b.TextAlign = ContentAlignment.BottomCenter;
                    b.TextImageRelation = TextImageRelation.ImageAboveText;
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    floUserList.Controls.Add(b);
                    currentImage++;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        protected void btnUser_Click(object sender, EventArgs e)
        {
            Button btnUser = sender as Button;
            int iUserId = int.Parse(btnUser.Tag.ToString());
            string strWaiter = btnUser.Text.Replace("\n", "");

            if (Settings.AskTable && Settings.AskGuestCount && Settings.AskWaiter)
            {
                _frmMain.SetTable(tableId, lblTableNo.Text, int.Parse(txtGuestCount.Text), iUserId, strWaiter);
            }
            else if (Settings.AskTable && Settings.AskGuestCount && !Settings.AskWaiter)
            {
                _frmMain.SetTable(tableId, lblTableNo.Text, int.Parse(txtGuestCount.Text), 0, string.Empty);
            }
            else if (Settings.AskTable && !Settings.AskGuestCount && Settings.AskWaiter)
            {
                _frmMain.SetTable(tableId, lblTableNo.Text, 0, iUserId, strWaiter);
            }

            this.Close();
        }

        private void frmOpenTable_Load(object sender, EventArgs e)
        {
            if (Settings.AskTable && Settings.AskGuestCount && Settings.AskWaiter)
            {
                lblTitle.Text = "Enter Number of Guest (s)";
                pnlGuest.Visible = true;
                pnlWaiters.Visible = true;
                pnlWaiters.Parent = pnlInner;
                pnlWaiters.Dock = DockStyle.Fill;
                pnlGuest.Parent = pnlInner;
                pnlGuest.Dock = DockStyle.Fill;
                btnOk.Visible = true;
                btnBack.Visible = false;
            }
            else if (Settings.AskTable && Settings.AskGuestCount && !Settings.AskWaiter)
            {
                lblTitle.Text = "Enter Number of Guest (s)";
                pnlGuest.Visible = true;
                pnlWaiters.Visible = false;
                pnlWaiters.Parent = pnlInner;
                pnlWaiters.Dock = DockStyle.Fill;
                pnlGuest.Parent = pnlInner;
                pnlGuest.Dock = DockStyle.Fill;
                btnOk.Visible = true;
                btnBack.Visible = false;
            }
            else if (Settings.AskTable && !Settings.AskGuestCount && Settings.AskWaiter)
            {
                lblTitle.Text = "Select Waiter";
                pnlGuest.Visible = false;
                pnlWaiters.Visible = true;
                pnlWaiters.Parent = pnlInner;
                pnlWaiters.Dock = DockStyle.Fill;
                pnlGuest.Parent = pnlInner;
                pnlGuest.Dock = DockStyle.Fill;
                btnOk.Visible = false;
                btnBack.Visible = false;

            }
            LoadUserList();
        }

        private void txtGuest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Settings.AskTable && Settings.AskWaiter)
            {
                if (txtGuestCount.Text == "0" || txtGuestCount.Text == null || txtGuestCount.Text == "")
                {
                    txtGuestCount.Focus();
                }
                else
                {
                    lblTitle.Text = "Select Waiter";
                    pnlGuest.Visible = false;
                    pnlWaiters.Visible = true;
                    pnlWaiters.Parent = pnlInner;
                    pnlWaiters.Dock = DockStyle.Fill;
                    pnlWaiters.BringToFront();
                    btnOk.Visible = false;
                    btnBack.Visible = true;
                }
            }
            else if (Settings.AskTable && !Settings.AskWaiter)
            {
                if (txtGuestCount.Text == "0" || txtGuestCount.Text == null || txtGuestCount.Text == "")
                {
                    txtGuestCount.Focus();
                }
                else
                {
                    _frmMain.SetTable(tableId, lblTableNo.Text,int.Parse(txtGuestCount.Text),0,string.Empty);
                    this.Close();
                }
            }
        }

        private void txtGuestCount_TextChanged(object sender, EventArgs e)
        {
            lblGuestCount.Text = txtGuestCount.Text;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Settings.AskTable && Settings.AskGuestCount)
            {
                lblTitle.Text = "Enter Number of Guest (s)";
                pnlGuest.Visible = true;
                pnlWaiters.Visible = false;
                pnlGuest.Parent = pnlInner;
                pnlGuest.Dock = DockStyle.Fill;
                pnlGuest.BringToFront();
                btnBack.Visible = false;
                btnOk.Visible = true;
            }
        }

    }
}
