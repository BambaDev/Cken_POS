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
    public partial class frmOrderType : Form
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

        public frmOrderType(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm; 
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

        private void btnDineIn_Click(object sender, EventArgs e)
        {
            _frmMain.SetOrderType(1,"Dine In");
            this.Close();
        }

        private void btnTakeAway_Click(object sender, EventArgs e)
        {
            _frmMain.SetOrderType(2,"Take Away");
            this.Close();
        }

        private void btnDeliveryOrder_Click(object sender, EventArgs e)
        {
            _frmMain.SetOrderType(3,"Delivery Order");
            this.Close();

            if (Settings.CustomerAfterDO)
            {
                frmCustomerPopup frmCustomerPopup = new frmCustomerPopup(_frmMain);
                frmCustomerPopup.ShowDialog();
            }
        }

        private void btnPickupOrder_Click(object sender, EventArgs e)
        {
            _frmMain.SetOrderType(4,"Pickup Order");
            this.Close();
            if (Settings.CustomerAfterPO)
            {
                frmCustomerPopup frmCustomerPopup = new frmCustomerPopup(_frmMain);
                frmCustomerPopup.ShowDialog();
            }
        }
    }
}
