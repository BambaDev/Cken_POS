using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
namespace cypos
{
    public partial class frmLogin : Form
    {
        private TextBox txtFocused = null;
        #region Taskbar
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        [Flags]
        private enum SetWindowPosFlags : uint
        {
            SWP_ASYNCWINDOWPOS = 0x4000,
            SWP_DEFERERASE = 0x2000,
            SWP_DRAWFRAME = 0x0020,
            SWP_FRAMECHANGED = 0x0020,
            SWP_HIDEWINDOW = 0x0080,
            SWP_NOACTIVATE = 0x0010,
            SWP_NOCOPYBITS = 0x0100,
            SWP_NOMOVE = 0x0002,
            SWP_NOOWNERZORDER = 0x0200,
            SWP_NOREDRAW = 0x0008,
            SWP_NOREPOSITION = 0x0200,
            SWP_NOSENDCHANGING = 0x0400,
            SWP_NOSIZE = 0x0001,
            SWP_NOZORDER = 0x0004,
            SWP_SHOWWINDOW = 0x0040,
        }

        [DllImport("user32", EntryPoint = "FindWindowA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr parentHwnd, IntPtr childAfterHwnd, IntPtr className, string windowText);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetWindow(IntPtr hWnd, GetWindowCmd uCmd);

        private enum GetWindowCmd : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

        // The taskbar's window handle.
        private IntPtr TaskbarHWnd, StartButtonHWnd;
        #endregion
        public frmLogin()
        {
            InitializeComponent();

            #region Hide Taskbar
            // Get the taskbar's and start button's window handles.
            TaskbarHWnd = FindWindow("Shell_traywnd", "");
            StartButtonHWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, null);

            // Hide the taskbar and start button.
            SetWindowPos(TaskbarHWnd, IntPtr.Zero, 0, 0, 0, 0,
                SetWindowPosFlags.SWP_HIDEWINDOW);
            SetWindowPos(StartButtonHWnd, IntPtr.Zero, 0, 0, 0, 0,
                SetWindowPosFlags.SWP_HIDEWINDOW);

            // Maximize.
            this.Bounds = Screen.PrimaryScreen.Bounds;
            #endregion

            //Payment Panel
            Point pt = pnlLogin.PointToScreen(new Point(0, 0));
            pnlLogin.Parent = this;
            pnlLogin.Location = this.PointToClient(pt);
            pnlLogin.BringToFront();

            btnExit.Enabled = false;
            WireAllControls(keyPad1);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validate username
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                Messages.WarningMessage("Please enter username");
                txtUserName.Focus();
                return;
            }

            // Validate password
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                Messages.WarningMessage("Please enter password");
                txtPassword.Focus();
                return;
            }

            try
            {
                // Use secure authentication method with password hashing
                string userType;
                bool authenticated = SecureDataAccess.AuthenticateUser(
                    txtUserName.Text.Trim(),
                    txtPassword.Text,
                    out userType
                );

                if (authenticated)
                {
                    // Set user info based on user type
                    UserInfo.UserName = txtUserName.Text.Trim();
                    UserInfo.UserType = userType;

                    // Log the successful login
                    WriteLoginRecords();

                    // Navigate to main form
                    frmMain frmMain = new frmMain();
                    frmMain.Show();
                    this.Hide();
                }
                else
                {
                    // Authentication failed
                    lblmsg.Visible = true;
                    lblmsg.Text = "Username or Password does not match";
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage("Login error: " + ex.Message);
                lblmsg.Visible = true;
                lblmsg.Text = "An error occurred during login. Please try again.";
            }
        }


        public void WriteLoginRecords()
        {
            try
            {
                string logdate = DateTime.Now.ToString("yyyy-MM-dd");
                string logtime = DateTime.Now.ToString("HH:mm:ss");

                // Use parameterized query to prevent SQL injection
                string strSQL = @"INSERT INTO tbl_UserLogs (user_name, log_type, log_date, log_time)
                                 VALUES (@userName, @logType, @logDate, @logTime)";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@userName", System.Data.SqlDbType.NVarChar, 50) { Value = UserInfo.UserName },
                    new System.Data.SqlClient.SqlParameter("@logType", System.Data.SqlDbType.NVarChar, 10) { Value = "IN" },
                    new System.Data.SqlClient.SqlParameter("@logDate", System.Data.SqlDbType.Date) { Value = logdate },
                    new System.Data.SqlClient.SqlParameter("@logTime", System.Data.SqlDbType.Time) { Value = logtime }
                };

                SecureDataAccess.ExecuteNonQuery(strSQL, parameters);
            }
            catch (Exception ex)
            {
                // Log error but don't prevent login if logging fails
                ErrorLog errorLog = new ErrorLog();
                errorLog.Write(ex.Message, "frmLogin.WriteLoginRecords",
                             AppDomain.CurrentDomain.BaseDirectory + "Errors\\");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            Progress(); 
        }

        public void Progress()
        { 

            progressBar1.Increment(5);
            lblProgress.Text = " " + progressBar1.Value.ToString() + "%";
            if (lblProgress.Text == " 100%")
            {
                timer1.Stop();
                btnExit.Enabled = true;
                btnLogin.Enabled = true;
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SetWindowPos(TaskbarHWnd, IntPtr.Zero, 0, 0, 0, 0,
            SetWindowPosFlags.SWP_SHOWWINDOW);
            SetWindowPos(StartButtonHWnd, IntPtr.Zero, 0, 0, 0, 0,
            SetWindowPosFlags.SWP_SHOWWINDOW);
            Environment.Exit(0);
        }

        #region KeyPad

        private void WireAllControls(Control cont)
        {
            foreach (Control ctl in cont.Controls)
            {
                ctl.Click += ctrl_Click;
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
            //to get the Textbox Focused
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Enter += textBox_Enter;
            }
        }

        void textBox_Enter(object sender, EventArgs e)
        {
            txtFocused = (TextBox)sender;
            keyPad1.KeyPadReturnValue = txtFocused.Text;
        }

        private void ctrl_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);

            if (txtFocused != null)
            {
                // put something in textbox
                txtFocused.Text = keyPad1.KeyPadReturnValue;
            }
        }

        #endregion

        private void btnFocusPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void btnFocusUser_Click(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            keyPad1.KeyPadReturnValue = txtUserName.Text;
            txtFocused = (TextBox)txtUserName;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            keyPad1.KeyPadReturnValue = txtPassword.Text;
            txtFocused = (TextBox)txtPassword;
        }
 
    }
}
