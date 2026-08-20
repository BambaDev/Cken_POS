using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace cypos
{
    public partial class frmSalesReturn : Form
    {
        ErrorLog objerror = new ErrorLog();

        #region Window Movable

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

        #endregion

        #region Functions

        public frmSalesReturn()
        {
            InitializeComponent();
            //Grid
            dgvReturnedItems.AutoGenerateColumns = false;
            //Grid Fonts
            dgvReturnedItems.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvReturnedItems.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvReturnedItems.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

            //History Grid Alignment
            dgvReturnedItems.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvReturnedItems.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvReturnedItems.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvReturnedItems.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvReturnedItems.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvReturnedItems.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvReturnedItems.Columns[2].DefaultCellStyle.Format = "N2";
            dgvReturnedItems.Columns[3].DefaultCellStyle.Format = "N2";
            dgvReturnedItems.Columns[4].DefaultCellStyle.Format = "N2";

            dgvReturnedItems.Columns[0].Width = 100;
            dgvReturnedItems.Columns[1].Width = 350;
            dgvReturnedItems.Columns[2].Width = 75;
            dgvReturnedItems.Columns[3].Width = 100;
            //dgvReturnedItems.Columns[4].Width = 100;
        }
        
        private void CalculateTotal()
          {
              // // subtotal without dis vat sum 
              double totalsum = 0;
              for (int i = 0; i < dgvReturnedItems.Rows.Count; ++i)
              {
                  totalsum += Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmAmount"].Value);
              }
              lblTotal.Text = totalsum.ToString();
              double CalculateTotal = Convert.ToDouble(totalsum.ToString());

              ////  Discount amount sum Calculation              
              double DisCount = 0.00;
              for (int i = 0; i < dgvReturnedItems.Rows.Count; ++i)
              {
                  DisCount += Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmDiscAmount"].Value);
              }
              DisCount = Math.Round(DisCount, 2);
              lblDiscount.Text = DisCount.ToString();

              //Overall sold discount / counter discount calculation
               
              double Discountvalue = Convert.ToDouble(txtDiscountRate.Text) ;
              double subtotal = Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(lblDiscount.Text); // CalculateTotal - item discount  100 - 5 = 95        
              double totaldiscount = (subtotal * Discountvalue) / 100;  //Counter discount  // 95 * 5 /100 = 4.75  

              double disPlusOverallDiscount = totaldiscount + Convert.ToDouble(lblDiscount.Text); // 4.75 + 5 = 9.75
              disPlusOverallDiscount = Math.Round(disPlusOverallDiscount, 2);
              lblTotalDiscount.Text = disPlusOverallDiscount.ToString();  // Overall discount 9.75

              double subtotalafteroveralldiscount = subtotal - totaldiscount; // 95 - 4.75 = 90.25
              subtotalafteroveralldiscount = Math.Round(subtotalafteroveralldiscount, 2);
              lblSubTotal.Text = subtotalafteroveralldiscount.ToString();
              

              //Tax 1 Calculation              
              double dblTax1 = 0.00;
              for (int i = 0; i < dgvReturnedItems.Rows.Count; ++i)
              {
                  dblTax1 += Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmTax1Amount"].Value);
              }
              dblTax1 = Math.Round(dblTax1, 2);
              lblTotalTax1.Text = dblTax1.ToString();

              //Tax 2 Calculation              
              double dblTax2 = 0.00;
              for (int i = 0; i < dgvReturnedItems.Rows.Count; ++i)
              {
                  dblTax2 += Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmTax2Amount"].Value);
              }
              dblTax2 = Math.Round(dblTax2, 2);
              lblTotalTax2.Text = dblTax2.ToString();


             // double Subtotal = CalculateTotal - DisCount;
              double sum = subtotalafteroveralldiscount + dblTax1 + dblTax2;
              sum = Math.Round(sum, 2);            
              lblTotalReturn.Text = sum.ToString();        
              txtReturnAmount.Text = lblTotalReturn.Text;
          }

        public void SaveRecord()
        {
            // Use transaction to ensure all operations succeed or all fail
            SecureDataAccess.ExecuteTransaction((conn, transaction) =>
            {
                int rows = dgvReturnedItems.Rows.Count;

                for (int i = 0; i < rows; i++)
                {
                    // Validate row data exists
                    if (dgvReturnedItems.Rows[i].Cells["clmItemCode"].Value == null)
                        continue;

                    string strInvoiceNo = txtInvoiceNo.Text;
                    string strReturnDate = dtpReturnDate.Value.ToString("yyyy-MM-dd");
                    string strCustomerId = (lblCustomer.Tag != null) ? lblCustomer.Tag.ToString() : "0";
                    string strItemCode = dgvReturnedItems.Rows[i].Cells["clmItemCode"].Value.ToString();
                    string strItemName = dgvReturnedItems.Rows[i].Cells["clmItemName"].Value.ToString();
                    double dblPrice = Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmPrice"].Value);
                    double dblQty = Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmQty"].Value);
                    double dblTotal = Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmAmount"].Value);
                    double dblDiscRate = string.IsNullOrEmpty(txtDiscountRate.Text) ? 0 : Convert.ToDouble(txtDiscountRate.Text);
                    double dblDiscAmount = string.IsNullOrEmpty(lblTotalDiscount.Text) ? 0 : Convert.ToDouble(lblTotalDiscount.Text);

                    string strTax1Name = (dgvReturnedItems.Rows[i].Cells["clmTax1Name"].Value != null) ? dgvReturnedItems.Rows[i].Cells["clmTax1Name"].Value.ToString() : "";
                    double dblTax1Rate = Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmTax1Rate"].Value);
                    double dblTax1Amount = Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmTax1Amount"].Value);

                    string strTax2Name = (dgvReturnedItems.Rows[i].Cells["clmTax2Name"].Value != null) ? dgvReturnedItems.Rows[i].Cells["clmTax2Name"].Value.ToString() : "";
                    double dblTax2Rate = Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmTax2Rate"].Value);
                    double dblTax2Amount = Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmTax2Amount"].Value);

                    // INSERT return item with parameterized query
                    string strSQLInsert = @"INSERT INTO tbl_ReturnItem
                                           (return_date, invoice_no, customer_id, item_code, item_name, qty, price, total,
                                            discount_rate, discount_amount, tax1_name, tax1_rate, tax1_amount,
                                            tax2_name, tax2_rate, tax2_amount, note, user_name, log_date)
                                           VALUES
                                           (@returnDate, @invoiceNo, @customerId, @itemCode, @itemName, @qty, @price, @total,
                                            @discountRate, @discountAmount, @tax1Name, @tax1Rate, @tax1Amount,
                                            @tax2Name, @tax2Rate, @tax2Amount, @note, @userName, @logDate)";

                    using (System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand(strSQLInsert, conn, transaction))
                    {
                        cmdInsert.Parameters.AddWithValue("@returnDate", strReturnDate);
                        cmdInsert.Parameters.AddWithValue("@invoiceNo", strInvoiceNo);
                        cmdInsert.Parameters.AddWithValue("@customerId", strCustomerId);
                        cmdInsert.Parameters.AddWithValue("@itemCode", strItemCode);
                        cmdInsert.Parameters.AddWithValue("@itemName", strItemName);
                        cmdInsert.Parameters.AddWithValue("@qty", dblQty);
                        cmdInsert.Parameters.AddWithValue("@price", dblPrice);
                        cmdInsert.Parameters.AddWithValue("@total", dblTotal);
                        cmdInsert.Parameters.AddWithValue("@discountRate", dblDiscRate);
                        cmdInsert.Parameters.AddWithValue("@discountAmount", dblDiscAmount);
                        cmdInsert.Parameters.AddWithValue("@tax1Name", strTax1Name);
                        cmdInsert.Parameters.AddWithValue("@tax1Rate", dblTax1Rate);
                        cmdInsert.Parameters.AddWithValue("@tax1Amount", dblTax1Amount);
                        cmdInsert.Parameters.AddWithValue("@tax2Name", strTax2Name);
                        cmdInsert.Parameters.AddWithValue("@tax2Rate", dblTax2Rate);
                        cmdInsert.Parameters.AddWithValue("@tax2Amount", dblTax2Amount);
                        cmdInsert.Parameters.AddWithValue("@note", txtNote.Text);
                        cmdInsert.Parameters.AddWithValue("@userName", UserInfo.UserName);
                        cmdInsert.Parameters.AddWithValue("@logDate", DateTime.Now);

                        cmdInsert.ExecuteNonQuery();
                    }

                    // Update stock quantity (increase)
                    string strSQLStock = "SELECT stock_quantity FROM tbl_Item WHERE item_code = @itemCode";
                    using (System.Data.SqlClient.SqlCommand cmdStock = new System.Data.SqlClient.SqlCommand(strSQLStock, conn, transaction))
                    {
                        cmdStock.Parameters.AddWithValue("@itemCode", strItemCode);
                        object result = cmdStock.ExecuteScalar();

                        if (result == null)
                        {
                            throw new Exception(string.Format("Item code {0} not found in tbl_Item", strItemCode));
                        }

                        double dblStockQuantity = Convert.ToDouble(result) + dblQty;

                        string strSQLUpdateStock = "UPDATE tbl_Item SET stock_quantity = @stockQty WHERE item_code = @itemCode";
                        using (System.Data.SqlClient.SqlCommand cmdUpdateStock = new System.Data.SqlClient.SqlCommand(strSQLUpdateStock, conn, transaction))
                        {
                            cmdUpdateStock.Parameters.AddWithValue("@stockQty", dblStockQuantity);
                            cmdUpdateStock.Parameters.AddWithValue("@itemCode", strItemCode);
                            cmdUpdateStock.ExecuteNonQuery();
                        }
                    }

                    // Update invoice detail (decrease qty)
                    string strSQLSalesQty = "SELECT qty FROM tbl_InvoiceDetail WHERE item_code = @itemCode";
                    using (System.Data.SqlClient.SqlCommand cmdSalesQty = new System.Data.SqlClient.SqlCommand(strSQLSalesQty, conn, transaction))
                    {
                        cmdSalesQty.Parameters.AddWithValue("@itemCode", strItemCode);
                        object result = cmdSalesQty.ExecuteScalar();

                        if (result == null)
                        {
                            throw new Exception(string.Format("Item code {0} not found in tbl_InvoiceDetail", strItemCode));
                        }

                        double dblSalesQty = Convert.ToDouble(result) - dblQty;
                        double dblTotalSale = dblSalesQty * dblPrice;

                        string strSQLStatus = @"UPDATE tbl_InvoiceDetail
                                               SET qty = @qty, total = @total
                                               WHERE item_code = @itemCode";

                        using (System.Data.SqlClient.SqlCommand cmdUpdateSales = new System.Data.SqlClient.SqlCommand(strSQLStatus, conn, transaction))
                        {
                            cmdUpdateSales.Parameters.AddWithValue("@qty", dblSalesQty);
                            cmdUpdateSales.Parameters.AddWithValue("@total", dblTotalSale);
                            cmdUpdateSales.Parameters.AddWithValue("@itemCode", strItemCode);
                            cmdUpdateSales.ExecuteNonQuery();
                        }
                    }
                }
            });
        }
        
        private bool RowIsVisible(DataGridViewRow row)
        {
            DataGridView dgv = row.DataGridView;
            int firstVisibleRowIndex = dgv.FirstDisplayedCell.RowIndex;
            int lastVisibleRowIndex = firstVisibleRowIndex + dgv.DisplayedRowCount(false) - 1;
            //return row.Index >= firstVisibleRowIndex && row.Index <= lastVisibleRowIndex;
            return row.Index >= lastVisibleRowIndex;
        }

        #endregion

        #region Events

        private void frmSalesReturn_Load(object sender, EventArgs e)
            {
                try
                {
                    dtpReturnDate.Format = DateTimePickerFormat.Custom;
                    dtpReturnDate.CustomFormat = "yyyy-MM-dd";

                    lblTax1Rate.Text = TaxValue.Tax1Rate;
                   

                    //DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                    //dgvReturnedItems.Columns.Add(del);
                    //del.HeaderText = "Del";
                    //del.Text = "X";
                    //del.Name = "del";
                    //del.ToolTipText = "Delete item";
                    //del.UseColumnTextForButtonValue = true;


                    //DataGridViewButtonColumn minus = new DataGridViewButtonColumn();
                    //dgvReturnedItems.Columns.Add(minus);
                    //minus.HeaderText = "Dec";
                    //minus.Text = "-";
                    //minus.Name = "minus";
                    //minus.ToolTipText = "minus Item Qty";
                    //minus.UseColumnTextForButtonValue = true;
                }
                catch (Exception exp)
                {
                    Messages.ExceptionMessage(exp.Message);
                }
            }
    
            private void disDecrease_Click(object sender, EventArgs e)  // // vat decrease
            {             
                if (txtReturnAmount.Text == "")
                {
                    Messages.InformationMessage("Please add item(s)");
                }
                else
                {
                    double Discountvalue = Convert.ToDouble(txtDiscountRate.Text) - 1;
                    txtDiscountRate.Text = Discountvalue.ToString();
                    double subtotal = Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(lblDiscount.Text);    
                    double totaldiscount = (subtotal * Discountvalue) / 100;
                    double disPlusOverallDiscount = totaldiscount + Convert.ToDouble(lblDiscount.Text);
                    disPlusOverallDiscount = Math.Round(disPlusOverallDiscount, 2);
                    lblTotalDiscount.Text = disPlusOverallDiscount.ToString(); 

                    double subtotalafteroveralldiscount = subtotal - totaldiscount; 
                    subtotalafteroveralldiscount = Math.Round(subtotalafteroveralldiscount, 2);
                    lblSubTotal.Text = subtotalafteroveralldiscount.ToString();

                    double payable = subtotalafteroveralldiscount + Convert.ToDouble(lblTotalTax1.Text);
                    payable = Math.Round(payable, 2);
                    lblTotalReturn.Text = payable.ToString();
                   
                    txtReturnAmount.Text = lblTotalReturn.Text;
                }
            }

            private void disIncreasebtn_Click(object sender, EventArgs e)   // Discount Increase 
            {              
                if (txtReturnAmount.Text == "")
                {
                    Messages.InformationMessage("Please add item(s)");
                }
                else
                {
                    double Discountvalue = Convert.ToDouble(txtDiscountRate.Text) + 1;
                    txtDiscountRate.Text = Discountvalue.ToString();
                    double subtotal = Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(lblDiscount.Text); // CalculateTotal - item discount  100 - 5 = 95        
                    double totaldiscount = (subtotal * Discountvalue) / 100;  //Counter discount  // 95 * 5 /100 = 4.75  

                    double disPlusOverallDiscount = totaldiscount + Convert.ToDouble(lblDiscount.Text); // 4.75 + 5 = 9.75
                    disPlusOverallDiscount = Math.Round(disPlusOverallDiscount, 2);
                    lblTotalDiscount.Text = disPlusOverallDiscount.ToString();  // Overall discount 9.75

                    double subtotalafteroveralldiscount = subtotal - totaldiscount; // 95 - 4.75 = 90.25
                    subtotalafteroveralldiscount = Math.Round(subtotalafteroveralldiscount, 2);
                    lblSubTotal.Text = subtotalafteroveralldiscount.ToString();

                    double payable = subtotalafteroveralldiscount + Convert.ToDouble(lblTotalTax1.Text);
                    payable = Math.Round(payable, 2);
                    lblTotalReturn.Text = payable.ToString();

                    txtReturnAmount.Text = lblTotalReturn.Text;
                }
            }

            private void btnSave_Click(object sender, EventArgs e)
            {
                bool result = Messages.QuestionMessage("Do you want to Complete Return?");

                if (result == true)
                {
                    if (txtReturnAmount.Text == "" ||  lblTotalReturn.Text == "0")
                    {
                        Messages.InformationMessage("Please enter invoice no");                  
                    }
                    else
                    {
                        try
                        {
                            SaveRecord();
                            Messages.SavedMessage();
                        }
                        catch (Exception exp)
                        {
                            Messages.ExceptionMessage(exp.Message);
                        }
                    }
                }
            }
        
            private void dgvReturnedItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                try
                {
                    // Increase Item Quantity with Edited cell
                    if (e.ColumnIndex == dgvReturnedItems.Columns["clmQty"].Index && e.RowIndex >= 0)
                    {
                        foreach (DataGridViewRow row in dgvReturnedItems.SelectedRows)
                        {
                            double qty = Convert.ToDouble(row.Cells["clmQty"].Value);
                            double Rprice = Convert.ToDouble(row.Cells["clmPrice"].Value);
                            double discount_rate = Convert.ToDouble(row.Cells["clmDiscRate"].Value);
                            double Taxrate    = Convert.ToDouble(lblTax1Rate.Text); // Convert.ToDouble(vatdisvalue.vat);

                            //// show CalculateTotal price   Qty  * Rprice
                            double totalPrice = qty * Rprice;
                            row.Cells["Total"].Value = totalPrice;

                            if (Convert.ToDouble(row.Cells["clmDiscRate"].Value) != 0) // IF discount is not zero then apply discount
                            {
                                double Disamt = (((Rprice * qty) * discount_rate) / 100.00);      // Total Discount amount of this item
                                row.Cells["clmDisAmount"].Value = Disamt;
                            }

                            if (Convert.ToDouble(row.Cells["Tax"].Value) != 0)  // IF tax is not zero then apply tax
                            {
                                double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * discount_rate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                                row.Cells["taxamt"].Value = Taxamt;
                            }

                            CalculateTotal();                     

                        }
                    }
                }
                catch
                {
                }
            }

            private void btnSubmit_Click(object sender, EventArgs e)
            {
                try
                {
                    //// Default tax rate 
                    //if (TaxValue.TaxType == "NoTax")
                    //{
                    //    lblTax1Name.Text = String.Empty;
                    //    lblTax1Rate.Text = "0";
                    //    lblTax2Name.Text = String.Empty;
                    //    lblTax2Rate.Text = "0";

                    //    lblTotalTax1.Text = "0";
                    //    lblTotalTax2.Text = "0";

                    //    lblTotalTax1.Visible = false;
                    //    lblTotalTax2.Visible = false;

                    //    lblTax1Name.Visible = false;
                    //    lblTax1Rate.Visible = false;
                    //    lblTax2Name.Visible = false;
                    //    lblTax2Rate.Visible = false;
                    //}
                    //else if (TaxValue.TaxType == "1LevelofTax")
                    //{
                    //    lblTax1Name.Text = TaxValue.Tax1Name + " (%):";
                    //    lblTax1Rate.Text = TaxValue.Tax1Rate;
                    //    lblTax2Name.Text = String.Empty;
                    //    lblTax2Rate.Text = "0";
                    //    lblTotalTax2.Text = "0";
                    //    lblTotalTax1.Visible = true;
                    //    lblTotalTax2.Visible = false;
                    //    lblTax1Name.Visible = true;
                    //    lblTax1Rate.Visible = true;
                    //    lblTax2Name.Visible = false;
                    //    lblTax2Rate.Visible = false;
                    //}

                    //else if (TaxValue.TaxType == "2LevelofTax")
                    //{
                    //    lblTax1Name.Text = TaxValue.Tax1Name + " (%):";
                    //    lblTax1Rate.Text = TaxValue.Tax1Rate;
                    //    lblTax2Name.Text = TaxValue.Tax2Name + " (%):";
                    //    lblTax2Rate.Text = TaxValue.Tax2Rate;

                    //    lblTotalTax1.Visible = true;
                    //    lblTotalTax2.Visible = true;

                    //    lblTax1Name.Visible = true;
                    //    lblTax1Rate.Visible = true;
                    //    lblTax2Name.Visible = true;
                    //    lblTax2Rate.Visible = true;
                    //}

                    string strSQL = "SELECT tbl_InvoiceHeader.invoice_id, tbl_InvoiceHeader.order_type, tbl_InvoiceHeader.invoice_no," +
                                  "tbl_InvoiceHeader.invoice_date, tbl_InvoiceHeader.invoice_time,ISNULL(tbl_Customer.name,'Guest') AS customer," +
                                  "tbl_InvoiceHeader.payment_type, tbl_InvoiceHeader.payment_amount, tbl_InvoiceHeader.paid_amount," +
                                  "tbl_InvoiceHeader.change_amount, tbl_InvoiceHeader.due_amount, tbl_InvoiceHeader.discount_rate," +
                                  "tbl_InvoiceHeader.discount_amount, tbl_InvoiceHeader.tax1_name, tbl_InvoiceHeader.tax1_rate," +
                                  "tbl_InvoiceHeader.tax1_amount, tbl_InvoiceHeader.tax2_name, tbl_InvoiceHeader.tax2_rate," +
                                  "tbl_InvoiceHeader.tax2_amount, tbl_InvoiceHeader.sc_rate,tbl_InvoiceHeader.sc_charge," +
                                  "tbl_InvoiceHeader.note, tbl_InvoiceHeader.user_name, tbl_InvoiceDetail.item_code," +
                                  "tbl_InvoiceDetail.item_name,tbl_InvoiceDetail.qty, tbl_InvoiceDetail.selling_price," +
                                  "tbl_InvoiceDetail.total, tbl_InvoiceDetail.discount, tbl_InvoiceDetail.discount_amount AS disc_amount, " +
                                  "tbl_InvoiceDetail.net_amount, tbl_InvoiceDetail.profit, tbl_InvoiceDetail.tax_apply," +
                                  "tbl_InvoiceDetail.show_kitchen FROM tbl_InvoiceHeader " +
                                  "LEFT JOIN tbl_InvoiceDetail ON tbl_InvoiceHeader.invoice_id = tbl_InvoiceDetail.header_id " +
                                  "LEFT JOIN tbl_Customer ON tbl_InvoiceHeader.customer_id = tbl_Customer.id " +
                                  "WHERE (tbl_InvoiceHeader.invoice_no = '" + txtInvoiceNo.Text + "' and qty != 0) ";


                
                DataTable dtItems = SecureDataAccess.GetDataTable(strSQL);

                if (dtItems.Rows.Count == 0)
                {
                    Messages.InformationMessage("Invoice not found!");
                    txtInvoiceNo.Clear();
                    txtInvoiceNo.Focus();
                }
                else
                {
                    lblBillDate.Text = dtItems.Rows[0]["invoice_date"].ToString();
                    lblBillDate.Text = dtItems.Rows[0]["payment_type"].ToString();
                    lblInvoiceAmount.Text = dtItems.Rows[0]["payment_amount"].ToString();
                    lblPaidAmount.Text = dtItems.Rows[0]["paid_amount"].ToString();
                    lblDueAmount.Text = dtItems.Rows[0]["due_amount"].ToString();

                    lblUser.Text = dtItems.Rows[0]["user_name"].ToString();
                    lblCustomer.Text = dtItems.Rows[0]["customer"].ToString();
                    lblNote.Text = dtItems.Rows[0]["note"].ToString();

                    dgvReturnedItems.DataSource = dtItems;

                    CalculateTotal();  
                }
                
                }
                catch (Exception ex)
                {
                    objerror.Write(ex.Message.ToString(), this.Name + " - btnSubmit_Click", Global.ERROR_WRITE_PATH);
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

            private void btnRowUp_Click(object sender, EventArgs e)
            {
                DataGridView dgv = dgvReturnedItems;
                try
                {
                    int totalRows = dgv.Rows.Count;
                    // get index of the row for the selected cell
                    int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                    if (rowIndex == 0)
                        return;
                    // get index of the column for the selected cell
                    int colIndex = dgv.SelectedCells[1].OwningColumn.Index;
                    DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                    dgv.ClearSelection();
                    dgv.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
                    dgv.FirstDisplayedScrollingRowIndex = rowIndex - 1;
                }
                catch (Exception ex)
                {
                    Messages.ExceptionMessage(ex.Message);
                }
            }

            private void btnRowDown_Click(object sender, EventArgs e)
            {
                DataGridView dgv = dgvReturnedItems;
                try
                {
                    int totalRows = dgv.Rows.Count;
                    // get index of the row for the selected cell
                    int rowIndex = dgv.SelectedCells[0].OwningRow.Index;
                    if (rowIndex == totalRows - 1)
                        return;
                    // get index of the column for the selected cell
                    int colIndex = dgv.SelectedCells[1].OwningColumn.Index;
                    DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                    dgv.ClearSelection();
                    dgv.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
                    if (RowIsVisible(selectedRow))
                    {
                        dgv.FirstDisplayedScrollingRowIndex = selectedRow.Index + 1;
                    }
                }
                catch (Exception ex)
                {
                    Messages.ExceptionMessage(ex.Message);
                }
            }

            private void btnQtyMinus_Click(object sender, EventArgs e)
            {
                foreach (DataGridViewRow row in dgvReturnedItems.SelectedRows)
                {
                    if (Convert.ToDouble(row.Cells["clmQty"].Value) > 1)
                    {
                        //// Decrease by 1 
                        double dblQtySum = Convert.ToDouble(row.Cells["clmQty"].Value) - 1;
                        row.Cells["clmQty"].Value = dblQtySum;

                        double dblQty = Convert.ToDouble(row.Cells["clmQty"].Value);
                        double dblPrice = Convert.ToDouble(row.Cells["clmPrice"].Value);
                        double dblDiscountRate = Convert.ToDouble(row.Cells["clmDiscRate"].Value);
                        double dblTax1Rate = Convert.ToDouble(TaxValue.Tax1Rate);
                        double dblTax2Rate = Convert.ToDouble(TaxValue.Tax2Rate);

                        //Show total price   Qty  * price
                        double dblTotalPrice = dblQty * dblPrice;
                        row.Cells["clmAmount"].Value = dblTotalPrice;

                        if (Convert.ToDouble(row.Cells["clmDisCAmount"].Value) != 0)
                        {
                            double dblDiscountAmount = (((dblPrice * dblQty) * dblDiscountRate) / 100.00);      // Total Discount amount of this item
                            row.Cells["clmDisCAmount"].Value = dblDiscountAmount;
                        }

                        if (Convert.ToBoolean(row.Cells["clmIsTaxable"].Value) != false)
                        {
                            double dblTax1Amount = ((((dblPrice * dblQty) - (((dblPrice * dblQty) * dblDiscountRate) / 100.00)) * dblTax1Rate) / 100.00); // Total Tax amount  of this item
                            row.Cells["clmTax1Amount"].Value = dblTax1Amount;

                            if (TaxValue.TaxType == "2LevelofTax")
                            {
                                double dblTax2Amount = ((((dblPrice * dblQty) - (((dblPrice * dblQty) * dblDiscountRate) / 100.00)) * dblTax2Rate) / 100.00); // Total Tax amount  of this item
                                row.Cells["clmTax2Amount"].Value = dblTax2Amount;
                            }
                        }

                        DiscountCalculation();
                        TaxCalculation();
                        txtDiscountRate.Text = "0";
                        Console.Beep();
                    }
                }
            }
        #endregion


            public void DiscountCalculation()
            {
                double totalsum = 0.00;
                for (int i = 0; i < dgvReturnedItems.Rows.Count; ++i)
                {
                    totalsum += Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmAmount"].Value);
                }
                lblTotal.Text = Currency.Format(totalsum);

                //Discount amount sum
                double total = Convert.ToDouble(totalsum.ToString());
                double DisCount = 0.00;
                for (int i = 0; i < dgvReturnedItems.Rows.Count; ++i)
                {
                    DisCount += Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmDiscAmount"].Value);
                }

                DisCount = Math.Round(DisCount, 2);
                double sum = total - DisCount;
                sum = Math.Round(sum, 2);
                lblSubTotal.Text = Currency.Format(sum);
                //Service Charge
                double dblScRate = Settings.ServiceChargeRate;
                double dblServiceCharge = 0;
                if (Settings.EnableServiceCharge)
                {
                    dblServiceCharge = (sum / 100) * dblScRate;
                }

                double payable = sum + Convert.ToDouble(lblTotalTax1.Text) + Convert.ToDouble(lblTotalTax2.Text) + dblServiceCharge;
                payable = Math.Round(payable, 2);
                lblTotalReturn.Text = Currency.Format(payable);
                lblTotalDiscount.Text = Currency.Format(DisCount);
            }

            public void TaxCalculation()
            {
                double Subtotal = Convert.ToDouble(lblSubTotal.Text);

                //Tax 1 amount
                double Tax1 = 0.00;
                for (int i = 0; i < dgvReturnedItems.Rows.Count; ++i)
                {
                    Tax1 += Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmTax1Amount"].Value);
                }

                Tax1 = Math.Round(Tax1, 2);
                lblTotalTax1.Text = Currency.Format(Tax1);

                //Tax 2 amount
                double Tax2 = 0.00;
                for (int i = 0; i < dgvReturnedItems.Rows.Count; ++i)
                {
                    Tax2 += Convert.ToDouble(dgvReturnedItems.Rows[i].Cells["clmTax2Amount"].Value);
                }

                Tax2 = Math.Round(Tax2, 2);
                lblTotalTax2.Text = Currency.Format(Tax2);

                double dblScRate = Settings.ServiceChargeRate;
                double dblServiceCharge = 0;
                if (Settings.EnableServiceCharge)
                {
                    dblServiceCharge = (Subtotal / 100) * dblScRate;
                }
                double dblPayable = Subtotal + Tax1 + Tax2 + dblServiceCharge;
                dblPayable = Math.Round(dblPayable, 2);
                //lblScAmount.Text = dblServiceCharge.ToString("N2");
                //lblTotalPayable.Text = dblPayable.ToString("N2");
            }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row2 in dgvReturnedItems.SelectedRows)
            {
                bool result = Messages.DeleteMessage();

                if (result ==true)
                {
                    if (!row2.IsNewRow)
                        dgvReturnedItems.Rows.Remove(row2);
                    CalculateTotal();
                }
            }  
        }
    }
}
