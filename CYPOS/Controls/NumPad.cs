using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cypos
{
    public partial class NumPad : UserControl
    {
        public NumPad()
        {
            InitializeComponent();
            Start_Events();
        }
        #region Attributes
        public string KeyPadReturnValue = "";

        #endregion

        #region Functions 

        public void Start_Events()
        {
            //Button Click Events
            this.btnNum1.Click += new System.EventHandler(this.btnClicks);
            this.btnNum2.Click += new System.EventHandler(this.btnClicks);
            this.btnNum3.Click += new System.EventHandler(this.btnClicks);
            this.btnNum4.Click += new System.EventHandler(this.btnClicks);
            this.btnNum5.Click += new System.EventHandler(this.btnClicks);
            this.btnNum6.Click += new System.EventHandler(this.btnClicks);
            this.btnNum7.Click += new System.EventHandler(this.btnClicks);
            this.btnNum8.Click += new System.EventHandler(this.btnClicks);
            this.btnNum9.Click += new System.EventHandler(this.btnClicks);
            this.btnNum0.Click += new System.EventHandler(this.btnClicks);
            this.btnBackSpace.Click += new System.EventHandler(this.btnBackSpaceClick);
            this.btnOk.Click += new System.EventHandler(this.btnOkClick);
        }
        #endregion


        #region Button Click Events 
        /////////////// Common Functions ////////////////////
        void btnClearClicks(object sender, EventArgs e)
        {
            KeyPadReturnValue = "";
        }

        void btnClicks(object sender, EventArgs e)
        {
            Button button = sender as Button;

            string buttonText = button.Text;

            KeyPadReturnValue = KeyPadReturnValue + buttonText;
            if (!this.Focused)
                this.Focus();
        }

        void btnBackSpaceClick(object sender, EventArgs e)
        {
            if (KeyPadReturnValue.Length > 0)
            {

                KeyPadReturnValue = KeyPadReturnValue.Remove(KeyPadReturnValue.Length - 1, 1);
            }
        }

        void btnOkClick(object sender, EventArgs e)
        {
            ThisForm.Close();
            SendKeys.Send("{TAB}");
        }

        #endregion  

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Escape) return true;
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Text = "";   // for example
                e.SuppressKeyPress = true;
                return;
            }
            base.OnKeyDown(e);
        }
    }
}
