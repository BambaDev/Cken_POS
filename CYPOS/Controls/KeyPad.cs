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
    public partial class KeyPad : UserControl
    {
        public KeyPad()
        {
            InitializeComponent();
            Start_Events();
        }
        #region Attributes
        ////////////////////////////////
        public bool capsOn = false;
        public bool hangulOn = false;
        public bool numbersOn = false;
        public string KeyPadReturnValue;

        #endregion

        #region Functions 

        public void loadCaps()
        {
            if (capsOn == true)
            {
                btn_a.Text = btn_a.Text.ToUpper();
                btn_b.Text = btn_b.Text.ToUpper();
                btn_c.Text = btn_c.Text.ToUpper();
                btn_d.Text = btn_d.Text.ToUpper();
                btn_e.Text = btn_e.Text.ToUpper();
                btn_f.Text = btn_f.Text.ToUpper();
                btn_g.Text = btn_g.Text.ToUpper();
                btn_h.Text = btn_h.Text.ToUpper();
                btn_i.Text = btn_i.Text.ToUpper();
                btn_j.Text = btn_j.Text.ToUpper();
                btn_k.Text = btn_k.Text.ToUpper();
                btn_l.Text = btn_l.Text.ToUpper();
                btn_m.Text = btn_m.Text.ToUpper();
                btn_n.Text = btn_n.Text.ToUpper();
                btn_o.Text = btn_o.Text.ToUpper();
                btn_p.Text = btn_p.Text.ToUpper();
                btn_q.Text = btn_q.Text.ToUpper();
                btn_r.Text = btn_r.Text.ToUpper();
                btn_s.Text = btn_s.Text.ToUpper();
                btn_t.Text = btn_t.Text.ToUpper();

                btn_u.Text = btn_u.Text.ToUpper();
                btn_v.Text = btn_v.Text.ToUpper();
                btn_w.Text = btn_w.Text.ToUpper();
                btn_x.Text = btn_x.Text.ToUpper();
                btn_y.Text = btn_y.Text.ToUpper();
                btn_z.Text = btn_z.Text.ToUpper();

                // capsOn = true;
            }
            else
            {
                btn_a.Text = btn_a.Text.ToLower();
                btn_b.Text = btn_b.Text.ToLower();
                btn_c.Text = btn_c.Text.ToLower();
                btn_d.Text = btn_d.Text.ToLower();
                btn_e.Text = btn_e.Text.ToLower();
                btn_f.Text = btn_f.Text.ToLower();
                btn_g.Text = btn_g.Text.ToLower();
                btn_h.Text = btn_h.Text.ToLower();
                btn_i.Text = btn_i.Text.ToLower();
                btn_j.Text = btn_j.Text.ToLower();
                btn_k.Text = btn_k.Text.ToLower();
                btn_l.Text = btn_l.Text.ToLower();
                btn_m.Text = btn_m.Text.ToLower();
                btn_n.Text = btn_n.Text.ToLower();
                btn_o.Text = btn_o.Text.ToLower();
                btn_p.Text = btn_p.Text.ToLower();
                btn_q.Text = btn_q.Text.ToLower();
                btn_r.Text = btn_r.Text.ToLower();
                btn_s.Text = btn_s.Text.ToLower();
                btn_t.Text = btn_t.Text.ToLower();

                btn_u.Text = btn_u.Text.ToLower();
                btn_v.Text = btn_v.Text.ToLower();
                btn_w.Text = btn_w.Text.ToLower();
                btn_x.Text = btn_x.Text.ToLower();
                btn_y.Text = btn_y.Text.ToLower();
                btn_z.Text = btn_z.Text.ToLower();

                //capsOn = false;
            }
        }

        public void loadbtnNumbers()
        {
            if (numbersOn == true)
            {
                btn_a.Text = ".";
                btn_b.Text = "#";
                btn_c.Text = "(";
                btn_d.Text = "~";
                btn_e.Text = "3";
                btn_f.Text = "!";
                btn_g.Text = "?";
                btn_h.Text = "^";
                btn_i.Text = "8";
                btn_j.Text = "$";
                btn_k.Text = "*";
                btn_l.Text = "-";
                btn_m.Text = "/";
                btn_n.Text = "@";
                btn_o.Text = "9";
                btn_p.Text = "0";
                btn_q.Text = "1";
                btn_r.Text = "4";
                btn_s.Text = ",";
                btn_t.Text = "5";
                btn_u.Text = "7";
                btn_v.Text = ")";
                btn_w.Text = "2";
                btn_x.Text = ":";
                btn_y.Text = "6";
                btn_z.Text = "_";

                // hangulOn = true;
            }
            else
            {
                btn_a.Text = "a";
                btn_b.Text = "b";
                btn_c.Text = "c";
                btn_d.Text = "d";
                btn_e.Text = "e";
                btn_f.Text = "f";
                btn_g.Text = "g";
                btn_h.Text = "h";
                btn_i.Text = "i";
                btn_j.Text = "j";
                btn_k.Text = "k";
                btn_l.Text = "l";
                btn_m.Text = "m";
                btn_n.Text = "n";
                btn_o.Text = "o";
                btn_p.Text = "p";
                btn_q.Text = "q";
                btn_r.Text = "r";
                btn_s.Text = "s";
                btn_t.Text = "t";
                btn_u.Text = "u";
                btn_v.Text = "v";
                btn_w.Text = "w";
                btn_x.Text = "x";
                btn_y.Text = "y";
                btn_z.Text = "z";
            }
        }

        public void Start_Events()
        {
            //Button Click Events
            this.btn_a.Click += new System.EventHandler(this.btnClicks);
            this.btn_b.Click += new System.EventHandler(this.btnClicks);
            this.btn_c.Click += new System.EventHandler(this.btnClicks);
            this.btn_d.Click += new System.EventHandler(this.btnClicks);
            this.btn_e.Click += new System.EventHandler(this.btnClicks);
            this.btn_f.Click += new System.EventHandler(this.btnClicks);
            this.btn_g.Click += new System.EventHandler(this.btnClicks);
            this.btn_h.Click += new System.EventHandler(this.btnClicks);
            this.btn_i.Click += new System.EventHandler(this.btnClicks);
            this.btn_j.Click += new System.EventHandler(this.btnClicks);
            this.btn_k.Click += new System.EventHandler(this.btnClicks);
            this.btn_l.Click += new System.EventHandler(this.btnClicks);
            this.btn_m.Click += new System.EventHandler(this.btnClicks);
            this.btn_n.Click += new System.EventHandler(this.btnClicks);
            this.btn_o.Click += new System.EventHandler(this.btnClicks);
            this.btn_p.Click += new System.EventHandler(this.btnClicks);
            this.btn_q.Click += new System.EventHandler(this.btnClicks);
            this.btn_r.Click += new System.EventHandler(this.btnClicks);
            this.btn_s.Click += new System.EventHandler(this.btnClicks);
            this.btn_t.Click += new System.EventHandler(this.btnClicks);
            this.btn_u.Click += new System.EventHandler(this.btnClicks);
            this.btn_v.Click += new System.EventHandler(this.btnClicks);
            this.btn_w.Click += new System.EventHandler(this.btnClicks);
            this.btn_x.Click += new System.EventHandler(this.btnClicks);
            this.btn_y.Click += new System.EventHandler(this.btnClicks);
            this.btn_z.Click += new System.EventHandler(this.btnClicks);

            this.btnSpace.Click += new System.EventHandler(this.btnSpaceClicks);
            this.btnBackSpace.Click += new System.EventHandler(this.btnBackSpaceClicks);
            this.btnCaps.Click += new System.EventHandler(this.btnCapsClicks);
            this.btnNumber.Click += new System.EventHandler(this.btnNumberClicks);
            this.btnClear.Click += new System.EventHandler(this.btnClearClicks);
        }
        #endregion


        #region Button & ETC Click Events 
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


        void btnSpaceClicks(object sender, EventArgs e)
        {
            KeyPadReturnValue = KeyPadReturnValue + " ";
        }

        void btnBackSpaceClicks(object sender, EventArgs e)
        {


            if (KeyPadReturnValue.Length > 0)
            {

                KeyPadReturnValue = KeyPadReturnValue.Remove(KeyPadReturnValue.Length - 1, 1);
            }


        }

        void btnCapsClicks(object sender, EventArgs e)
        {
            if (hangulOn == true)
            {
                return;
            }
            if (numbersOn == true)
            {
                return;
            }
            if (capsOn == false)
            {
                capsOn = true;
                btnCaps.Text = btnCaps.Text.ToUpper();
            }
            else
            {
                capsOn = false;
                btnCaps.Text = btnCaps.Text.ToLower();
            }

            loadCaps();
        }

        void btnNumberClicks(object sender, EventArgs e)
        {
            if (numbersOn == false)
            {
                numbersOn = true;
            }
            else
            {
                numbersOn = false;
            }
            loadbtnNumbers();
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
