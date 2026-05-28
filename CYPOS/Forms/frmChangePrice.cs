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
    public partial class frmChangePrice : Form
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

        public string Price
        {
            set { txtPrice.Text = value; }
            get { return txtPrice.Text; }
        }

        public frmChangePrice(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;

            formFunctionPointer += new functioncall(Replicate); 
            currencyPad1.CoinandNotesFunctionPointer = formFunctionPointer;

            numformFunctionPointer += new numvaluefunctioncall(NumericKeypad);
            currencyPad1.NumaricKeypad = numformFunctionPointer;
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

        #region Currency Pad
        public delegate void functioncall(string currencyvalue);
        public delegate void numvaluefunctioncall(string Numvalue);

        private event functioncall formFunctionPointer;
        private event numvaluefunctioncall numformFunctionPointer;

        private void Replicate(string currencyvalue)
        {
            if (currencyvalue == "XX") // All clear
            {
                txtPrice.Text = "";
            }
            else if (currencyvalue == "BXC") //Backspace
            {
                if ((String.Compare(txtPrice.Text, " ") < 0))
                {
                    txtPrice.Text = txtPrice.Text.Substring(0, txtPrice.Text.Length - 1 + 1);
                }
                else
                {
                    txtPrice.Text = txtPrice.Text.Substring(0, txtPrice.Text.Length - 1);
                }
                txtPrice.Focus();
            }
            else
            {
                if (string.IsNullOrEmpty(txtPrice.Text))
                {
                    txtPrice.Text = "0.00";
                    txtPrice.Text = (Convert.ToDouble(txtPrice.Text) + Convert.ToDouble(currencyvalue)).ToString();
                }
                else
                {
                    txtPrice.Text = (Convert.ToDouble(txtPrice.Text) + Convert.ToDouble(currencyvalue)).ToString();
                }
                txtPrice.Focus();
            }

        }

        private void NumericKeypad(string Numvalue)
        {
            if (Numvalue == ".")
            {
                if (!txtPrice.Text.Contains('.'))
                {
                    txtPrice.Text += Numvalue;
                    txtPrice.Focus();
                }
            }
            else
            {
                txtPrice.Text += Numvalue;
                txtPrice.Focus();
            }
        }
        #endregion

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtPrice.Text.ToString(), @"\.\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    IgnoreKeyPress = false;
                else if (matchString)
                    IgnoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    IgnoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    IgnoreKeyPress = true;

                e.Handled = IgnoreKeyPress;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtPrice.Text !=string.Empty)
            {
                _frmMain.UpdatePrice(double.Parse(txtPrice.Text));
                OpenedForms.Close();
            }
        }
    }
}
