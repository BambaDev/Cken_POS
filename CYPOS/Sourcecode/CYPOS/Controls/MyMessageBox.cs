using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace cypos
{
    public partial class MyMessageBox : Form
    {

       #region Variables and Constants

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

        static MyMessageBox newMessageBox;
        public Timer msgTimer;
        public static Result result;
        int disposeFormTimer;

       #endregion

       #region Enumerations

       public enum Buttons
        {
            OK,
            OKCancel,
            YesNo,
        }

        public enum Icons
        {
            Asterisk,
            Error,
            Exclamation,
            Hand,
            Information,
            None,
            Question,
            Stop,
            Warning
        }

        public enum Result
        {
            OK,
            Cancel,
            Yes,
            No,
        }

        #endregion

       #region Functions

        public MyMessageBox()  //Constructor
        {
            InitializeComponent();
        }

        public static void ShowBox(string strMessage)
        {
            newMessageBox = new MyMessageBox();
            newMessageBox.lblMessage.Text = strMessage;
            ShowButtons(Buttons.OK);
            newMessageBox.ShowDialog();
        }

        public static Result ShowBox(string strMessage, string strTitle, Buttons button)
        {
            newMessageBox = new MyMessageBox();
            newMessageBox.lblTitle.Text = strTitle;
            newMessageBox.lblMessage.Text = strMessage;
            ShowButtons(button);
            newMessageBox.ShowDialog();
            return result;
        }

        public static Result ShowBox(string strMessage, string strTitle, Buttons button, Icons icon)
        {
            newMessageBox = new MyMessageBox();
            newMessageBox.lblTitle.Text = strTitle;
            newMessageBox.lblMessage.Text = strMessage;
            ShowButtons(button);
            ShowIcons(icon);
            newMessageBox.ShowDialog();
            return result;
        }
 
        public static void ShowButtons(Buttons button)
        {
            string strButton = button.ToString();
            if (strButton.Contains("OK"))
                newMessageBox.btnCancel.Text = "OK";
                newMessageBox.btnCancel.Image = cypos.Properties.Resources.yes;
                newMessageBox.btnOK.Visible = false;
            if (strButton.Contains("YesNo"))
            {
                newMessageBox.btnOK.Text = "Yes";
                newMessageBox.btnCancel.Text = "No";
                newMessageBox.btnOK.Visible = true;
                newMessageBox.btnOK.Image = cypos.Properties.Resources.yes;
                newMessageBox.btnCancel.Image = cypos.Properties.Resources.no;
            }
            if (strButton.Contains("Cancel"))
            {
                newMessageBox.btnOK.Text = "OK";
                newMessageBox.btnCancel.Text = "Cancel";
                newMessageBox.btnOK.Visible = true;
                newMessageBox.btnOK.Image = cypos.Properties.Resources.yes;
                newMessageBox.btnCancel.Image = cypos.Properties.Resources.no;
            }
        }

        public static void ShowIcons(Icons icon)
        {
            int inIndex = 0;
            if (icon == Icons.Information || icon == Icons.Asterisk)
                inIndex = 1;
            if (icon == Icons.Question)
                inIndex = 2;
            if (icon == Icons.Warning || icon == Icons.Exclamation)
                inIndex = 3;
            if (icon == Icons.Error)
                inIndex = 4;
            if (icon == Icons.Stop)
                inIndex = 5;
            if (icon == Icons.Hand)
                inIndex = 6;
            if (icon != Icons.None)
            {
                newMessageBox.pbxIcon.Image = newMessageBox.imglstIcons.Images[inIndex];
                newMessageBox.pbxIcon.Visible = true;
            }
        }

        public void DrawRoundRect(Graphics g, Pen p, float x, float y, float width, float height, float radius)
        {
            {
                GraphicsPath gp = new GraphicsPath();

                gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
                gp.CloseFigure();
                g.DrawPath(p, gp);
                gp.Dispose();
            }
        }
       #endregion

       #region Event Handlers

        private void MyMessageBox_Load(object sender, EventArgs e)
        {
         /* disposeFormTimer = 15;                                      //uncomment these to enable timer
            newMessageBox.lblTimer.Text = disposeFormTimer.ToString();
            msgTimer = new Timer();
            msgTimer.Interval = 1000;
            msgTimer.Enabled = true;
            msgTimer.Start();
            msgTimer.Tick += new System.EventHandler(this.timer_tick); */
        }

        private void MyMessageBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics mGraphics = e.Graphics;
            Pen pen1 = new Pen(Color.Black, 1);

            Rectangle Area1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush LGB = new LinearGradientBrush(Area1, Color.WhiteSmoke, Color.FromArgb(245, 251, 251), LinearGradientMode.Vertical);
            mGraphics.FillRectangle(LGB, Area1);
            mGraphics.DrawRectangle(pen1, Area1);

            Pen p = new Pen(Color.FromArgb(227, 227, 227), 1);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            for (int inI = 30; inI < this.Size.Height - 1; inI += 5)
            {
                DrawRoundRect(mGraphics, p, 0, inI, this.Size.Width, 0, 1);
            }
            p.Dispose();
        }
      
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (btnOK.Text == "Yes")
                result = Result.Yes;
            else if (btnOK.Text == "OK")
                result = Result.OK;
            else
                result = Result.No;
         /* newMessageBox.msgTimer.Stop();
            newMessageBox.msgTimer.Dispose(); */     //uncomment these to enable timer
            newMessageBox.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "Cancel")
                result = Result.Cancel;
            else if (btnCancel.Text == "No")
                result = Result.No;
            else
                result = Result.OK;
        /*  newMessageBox.msgTimer.Stop();       
            newMessageBox.msgTimer.Dispose();  */     //uncomment these to enable timer
            newMessageBox.Close();

        }


        /************** To make the window movable *********/

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        /****************************************************************/

        private void pbxClose_Click(object sender, EventArgs e)
        {
        /*  newMessageBox.msgTimer.Stop();
            newMessageBox.msgTimer.Dispose();  */   //uncomment these to enabele timer
            result = Result.Cancel;
            newMessageBox.Close();
        }

        private void pbxClose_MouseHover(object sender, EventArgs e)
        {
            pbxClose.Size = new Size(33, 33);
       }

        private void pbxClose_MouseLeave(object sender, EventArgs e)
        {
            pbxClose.Size = new Size(32, 32);
        }

       #endregion
    }
}