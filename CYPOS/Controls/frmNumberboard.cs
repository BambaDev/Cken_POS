using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace cypos
{
    public partial class frmNumberboard : Form
    {
        TextBox _TextBox;

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

        public frmNumberboard(TextBox tBox)
        {
            this.SuspendLayout();
            InitializeComponent();
            _TextBox = tBox;
            WireAllControls(numPad1);
            this.ResumeLayout(false);
        }

        private void WireAllControls(Control cont)
        {
            foreach (Control ctl in cont.Controls)
            {
                ctl.Click += ctrl_Click;
                ctl.Enter += textBox_Enter;
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
        }

        private void ctrl_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);

            if (_TextBox != null)
            {
                // put something in textbox
                _TextBox.Text = numPad1.KeyPadReturnValue;

            }
        }

        void textBox_Enter(object sender, EventArgs e)
        {
            numPad1.KeyPadReturnValue = _TextBox.Text;
        }

        private void frmKeyboard_Load(object sender, EventArgs e)
        {
            Application.AddMessageFilter(new PopupWindowHelperMessageFilter(this, _TextBox));
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
    }
}
