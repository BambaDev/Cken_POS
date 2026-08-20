using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace cypos
{
    public partial class frmDatabase : Form
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

        public frmDatabase()
        {
            InitializeComponent();
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
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

        private void btnTruncate_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = Messages.QuestionMessage("Do you want to reset database?");

                if (result == true)
                {
                    bool isChecked = false;
                    foreach (var control in grpMasters.Controls) 
                    {
                        if (control is CheckBox)
                        {
                            if (((CheckBox)control).Checked)
                            {
                                isChecked = true;
                            }
                        }
                    }

                    foreach (var control in grpTransaction.Controls)
                    {
                        if (control is CheckBox)
                        {
                            if (((CheckBox)control).Checked)
                            {
                                isChecked = true;
                            }
                        }
                    }

                    if (!isChecked)
                    {
                        Messages.InformationMessage("Nothing selected!");
                    }
                    else
                    {
                        if (cbxItem.Checked)
                        {
                            string strSQL = "TRUNCATE TABLE tbl_Item; DBCC CHECKIDENT ('tbl_Item', RESEED, 1)";
                            SecureDataAccess.ExecuteNonQuery(strSQL);
                        }

                        if (cbxCategory.Checked)
                        {
                            string strSQL = "TRUNCATE TABLE tbl_Category; DBCC CHECKIDENT ('tbl_Category', RESEED, 1)";
                            SecureDataAccess.ExecuteNonQuery(strSQL);
                        }

                        if (cbxTables.Checked)
                        {
                            string strSQL = "TRUNCATE TABLE tbl_Tables; DBCC CHECKIDENT ('tbl_Tables', RESEED, 1)";
                            SecureDataAccess.ExecuteNonQuery(strSQL);
                        }

                        if (cbxTableLocation.Checked)
                        {
                            string strSQL = "TRUNCATE TABLE tbl_TableLocation; DBCC CHECKIDENT ('tbl_TableLocation', RESEED, 1)";
                            SecureDataAccess.ExecuteNonQuery(strSQL);
                        }

                        if (cbxSuppliers.Checked)
                        {
                            string strSQL = "TRUNCATE TABLE tbl_Supplier; DBCC CHECKIDENT ('tbl_Supplier', RESEED, 1)";
                            SecureDataAccess.ExecuteNonQuery(strSQL);
                        }

                        if (cbxCustomers.Checked)
                        {
                            string strSQL = "TRUNCATE TABLE tbl_Customer; DBCC CHECKIDENT ('tbl_Customer', RESEED, 1)";
                            SecureDataAccess.ExecuteNonQuery(strSQL);
                        }

                        if (cbxInvoices.Checked)
                        {
                            string strSQL = @"TRUNCATE TABLE tbl_InvoiceHeader;
                                             TRUNCATE TABLE tbl_InvoiceDetail;
                                             TRUNCATE TABLE tbl_InvoiceNo;
                                             TRUNCATE TABLE tbl_TempHeader;
                                             TRUNCATE TABLE tbl_TempDetail;
                                             TRUNCATE TABLE tbl_KotNo;
                                             TRUNCATE TABLE tbl_HoldNo;";
                            SecureDataAccess.ExecuteNonQuery(strSQL);

                            //Update Starting Invoice Numbers / Auto Index (Identity)
                            int autoInvoiceNo = Settings.StartingInvoiceNo;
                            string strSQLInvoiceNo = "DBCC CHECKIDENT ('tbl_InvoiceNo', RESEED, @invoiceNo)";
                            System.Data.SqlClient.SqlParameter[] paramsInvoice = {
                                new System.Data.SqlClient.SqlParameter("@invoiceNo", System.Data.SqlDbType.Int) { Value = autoInvoiceNo }
                            };
                            SecureDataAccess.ExecuteNonQuery(strSQLInvoiceNo, paramsInvoice);

                            //Update Starting Kot Numbers / Auto Index (Identity)
                            int autoKotNo = Settings.StartingKotNo;
                            string strSQLKotNo = "DBCC CHECKIDENT ('tbl_KotNo', RESEED, @kotNo)";
                            System.Data.SqlClient.SqlParameter[] paramsKot = {
                                new System.Data.SqlClient.SqlParameter("@kotNo", System.Data.SqlDbType.Int) { Value = autoKotNo }
                            };
                            SecureDataAccess.ExecuteNonQuery(strSQLKotNo, paramsKot);

                            //Update Starting Auto Index (Identity)
                            string strSQLHold = "DBCC CHECKIDENT ('tbl_HoldNo', RESEED, 1)";
                            SecureDataAccess.ExecuteNonQuery(strSQLHold);
                        }

                        if (cbxPurchases.Checked)
                        {
                            string strSQL = "TRUNCATE TABLE tbl_Purchase; DBCC CHECKIDENT ('tbl_Purchase', RESEED, 1)";
                            SecureDataAccess.ExecuteNonQuery(strSQL);
                        }

                        if (cbxExpenses.Checked)
                        {
                            string strSQL = "TRUNCATE TABLE tbl_Expense; DBCC CHECKIDENT ('tbl_Expense', RESEED, 1)";
                            SecureDataAccess.ExecuteNonQuery(strSQL);
                        }
                        //Messages.InformationMessage("Successfully truncated");
                        OpenedForms.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }   
        }
    }
}
