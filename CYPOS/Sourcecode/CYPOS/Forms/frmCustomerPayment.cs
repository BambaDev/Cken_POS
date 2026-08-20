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
    public partial class frmCustomerPayment : Form
    {

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

        public frmCustomerPayment()
        {
            InitializeComponent();

            //Currency Pad
            formFunctionPointer += new functioncall(Replicate); // Coin and Paper Notes
            currencyPad1.CoinandNotesFunctionPointer = formFunctionPointer;

            numformFunctionPointer += new numvaluefunctioncall(NumericKeypad);
            currencyPad1.NumaricKeypad = numformFunctionPointer;
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
                txtPaidAmount.Text = "";
            }
            else if (currencyvalue == "BXC") //Backspace
            {
                if ((String.Compare(txtPaidAmount.Text, " ") < 0))
                {
                    txtPaidAmount.Text = txtPaidAmount.Text.Substring(0, txtPaidAmount.Text.Length - 1 + 1);
                }
                else if (txtPaidAmount.Text.Length > 0)
                {
                    txtPaidAmount.Text = txtPaidAmount.Text.Substring(0, txtPaidAmount.Text.Length - 1);
                }
                txtPaidAmount.Focus();
            }
            else
            {
                // Sécuriser les conversions avec TryParse
                decimal currentAmount = 0;
                if (!string.IsNullOrEmpty(txtPaidAmount.Text))
                {
                    decimal.TryParse(txtPaidAmount.Text, out currentAmount);
                }

                decimal currencyAmount = 0;
                decimal.TryParse(currencyvalue, out currencyAmount);

                decimal newAmount = currentAmount + currencyAmount;
                txtPaidAmount.Text = newAmount.ToString("0.00");
                txtPaidAmount.Focus();
            }

        }

        private void NumericKeypad(string Numvalue)
        {
            if (Numvalue == ".")
            {
                if (!txtPaidAmount.Text.Contains('.'))
                {
                    txtPaidAmount.Text += Numvalue;
                    txtPaidAmount.Focus();
                }
            }
            else
            {
                txtPaidAmount.Text += Numvalue;
                txtPaidAmount.Focus();
            }
        }
        #endregion



        #region Data get from Due Invoices
        

        public string InvoiceNo
        {
            set { lblInvoiceNo.Text = value; }       
            get { return lblInvoiceNo.Text; }
        }
        public string InvoiceDate
        {
            set { lblInvoiceDate.Text = value; }           
            get { return lblInvoiceDate.Text; }
        }
        public string TotalAmount
        {
            set { lblTotalAmount.Text = value; }       
            get { return lblTotalAmount.Text; }
        }
        public string PaidAmount
        {
            set { lblPaidAmount.Text = value; }         
            get { return lblDueAmount.Text; }
        }
        public string DueAmount
        {
            set { lblDueAmount.Text = value; }
            get { return lblDueAmount.Text; }
        }

        //public string CustomerId
        //{
        //    set { lblCustomer.Tag = value; }
        //    get { return lblCustomer.Tag; }
        //}

        public string Customer
        {
            set { lblCustomer.Text = value; }         
            get { return lblCustomer.Text; }
        }

        #endregion
      
        private void DueUpdate_Load(object sender, EventArgs e)
        {
            dtpPaymentDate.Format = DateTimePickerFormat.Custom;
            dtpPaymentDate.CustomFormat = "yyyy-MM-dd";
        }


  

        private void DueUpdate_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
            }
        }

        #region Request submit
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPaidAmount.Text == "" )
            {
                Messages.InformationMessage("Enter amount");
            }
            else if (txtPaidAmount.Text == "")
            {
                Messages.InformationMessage("Enter amount");
            }
            else
            {
                try
                {
                    // Utiliser Currency.Parse() pour gérer le format "X XXX FCFA"
                    decimal paidAmount = Currency.Parse(txtPaidAmount.Text);
                    decimal dueAmount = Currency.Parse(lblDueAmount.Text);
                    decimal totalAmount = Currency.Parse(lblTotalAmount.Text);

                    if (paidAmount <= dueAmount)
                    {
                        decimal decPaidAmount = dueAmount - paidAmount;
                        decimal decBalanceAmount = dueAmount - paidAmount;

                        // ===============================================================================
                        // OPÉRATION CRITIQUE AVEC TRANSACTION SQL
                        // UPDATE InvoiceHeader + INSERT DuePayment doivent être atomiques
                        // Si une étape échoue, TOUT est rollback automatiquement
                        // ===============================================================================
                        SecureDataAccess.ExecuteTransaction((conn, transaction) =>
                        {
                            // ÉTAPE 1 : UPDATE Invoice Due Amount
                            string strSQLUpdate = "UPDATE tbl_InvoiceHeader SET due_amount = @dueAmount WHERE invoice_id = @invoiceId";

                            using (System.Data.SqlClient.SqlCommand cmdUpdate = new System.Data.SqlClient.SqlCommand(strSQLUpdate, conn, transaction))
                            {
                                cmdUpdate.Parameters.AddWithValue("@dueAmount", decPaidAmount);
                                cmdUpdate.Parameters.AddWithValue("@invoiceId", lblInvoiceNo.Text);
                                cmdUpdate.ExecuteNonQuery();
                            }

                            // ÉTAPE 2 : INSERT Due Payment History
                            string strSQLInsert = @"INSERT INTO tbl_DuePayment
                                (payment_date, invoice_id, total_amount, due_amount, paid_amount, payment_type, customer_id)
                                VALUES
                                (@paymentDate, @invoiceId, @totalAmount, @dueAmount, @paidAmount, @paymentType, @customerId)";

                            using (System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand(strSQLInsert, conn, transaction))
                            {
                                cmdInsert.Parameters.AddWithValue("@paymentDate", dtpPaymentDate.Text);
                                cmdInsert.Parameters.AddWithValue("@invoiceId", lblInvoiceNo.Text);
                                cmdInsert.Parameters.AddWithValue("@totalAmount", totalAmount);
                                cmdInsert.Parameters.AddWithValue("@dueAmount", decBalanceAmount);
                                cmdInsert.Parameters.AddWithValue("@paidAmount", paidAmount);
                                cmdInsert.Parameters.AddWithValue("@paymentType", cmbPaymentType.Text);
                                cmdInsert.Parameters.AddWithValue("@customerId", lblCustomer.Text);
                                cmdInsert.ExecuteNonQuery();
                            }
                        });

                        Messages.SavedMessage();
                        txtPaidAmount.Text = string.Empty;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("You are Not able to Update \n\n Excced Due amount ", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
                catch
                {
                }
            }
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

        private void btnPayFullAmount_Click(object sender, EventArgs e)
        {
            try
            {
                txtPaidAmount.Text = lblDueAmount.Text;
                btnSave_Click(sender, e);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtPaidAmount.Text.ToString(), @"\.\d\d");

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
    }
}
