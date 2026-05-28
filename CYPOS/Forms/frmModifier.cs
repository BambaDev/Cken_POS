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
    public partial class frmModifiers : Form
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

        public frmModifiers()
        {
            InitializeComponent();
        }
	
	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public string ModifierID
        {
            set { lblModifierId.Text = value;} 
            get{return lblModifierId.Text;}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                 if (txtModifierName.Text == "") 
                 { 
                     Messages.InformationMessage("Enter modifier name"); 
                     txtModifierName.Focus(); 
                 }
                else
                 {
                     string strPriceMethod = string.Empty;
                     bool isKitchenPrint;

                     if (rdbPriceAdd.Checked)
                     {
                         strPriceMethod = "+";
                     }
                     else
                     {
                         strPriceMethod = "-";
                     }

                     if (rdbKitchenYes.Checked)
                     {
                         isKitchenPrint = true;
                     }
                     else
                     {
                         isKitchenPrint = false;
                     }
                     if (txtPrice.Text == string.Empty)
                     {
                         txtPrice.Text = "0";
                     }
                     if (lblModifierId.Text == "-")
                     {
                         decimal price = 0;
                         decimal.TryParse(txtPrice.Text, out price);
                         int sortOrder = 0;
                         int.TryParse(txtSortOrder.Text, out sortOrder);

                         string strSQLInsert = @"INSERT INTO tbl_Modifier (name, price, price_method, item_code, print_to_kitchen, back_color, fore_color, sort_order)
                                                VALUES (@name, @price, @priceMethod, @itemCode, @printToKitchen, @backColor, @foreColor, @sortOrder)";

                         System.Data.SqlClient.SqlParameter[] parameters = {
                             new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.NVarChar) { Value = txtModifierName.Text },
                             new System.Data.SqlClient.SqlParameter("@price", System.Data.SqlDbType.Decimal) { Value = price },
                             new System.Data.SqlClient.SqlParameter("@priceMethod", System.Data.SqlDbType.NVarChar, 1) { Value = strPriceMethod },
                             new System.Data.SqlClient.SqlParameter("@itemCode", System.Data.SqlDbType.NVarChar) { Value = txtItemCode.Text },
                             new System.Data.SqlClient.SqlParameter("@printToKitchen", System.Data.SqlDbType.Bit) { Value = isKitchenPrint },
                             new System.Data.SqlClient.SqlParameter("@backColor", System.Data.SqlDbType.Int) { Value = crpBackColor.Value.ToArgb() },
                             new System.Data.SqlClient.SqlParameter("@foreColor", System.Data.SqlDbType.Int) { Value = crpForeColor.Value.ToArgb() },
                             new System.Data.SqlClient.SqlParameter("@sortOrder", System.Data.SqlDbType.Int) { Value = sortOrder }
                         };

                         SecureDataAccess.ExecuteNonQuery(strSQLInsert, parameters);
                         LoadModifierList("");
                         Clear();
                     }
                     else
                     {
                         decimal price = 0;
                         decimal.TryParse(txtPrice.Text, out price);
                         int sortOrder = 0;
                         int.TryParse(txtSortOrder.Text, out sortOrder);
                         int modifierId = 0;
                         int.TryParse(lblModifierId.Text, out modifierId);

                         string strSQLUpdate = @"UPDATE tbl_Modifier
                                                SET name = @name,
                                                    price = @price,
                                                    price_method = @priceMethod,
                                                    item_code = @itemCode,
                                                    print_to_kitchen = @printToKitchen,
                                                    back_color = @backColor,
                                                    fore_color = @foreColor,
                                                    sort_order = @sortOrder
                                                WHERE id = @modifierId";

                         System.Data.SqlClient.SqlParameter[] parameters = {
                             new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.NVarChar) { Value = txtModifierName.Text },
                             new System.Data.SqlClient.SqlParameter("@price", System.Data.SqlDbType.Decimal) { Value = price },
                             new System.Data.SqlClient.SqlParameter("@priceMethod", System.Data.SqlDbType.NVarChar, 1) { Value = strPriceMethod },
                             new System.Data.SqlClient.SqlParameter("@itemCode", System.Data.SqlDbType.NVarChar) { Value = txtItemCode.Text },
                             new System.Data.SqlClient.SqlParameter("@printToKitchen", System.Data.SqlDbType.Bit) { Value = isKitchenPrint },
                             new System.Data.SqlClient.SqlParameter("@backColor", System.Data.SqlDbType.Int) { Value = crpBackColor.Value.ToArgb() },
                             new System.Data.SqlClient.SqlParameter("@foreColor", System.Data.SqlDbType.Int) { Value = crpForeColor.Value.ToArgb() },
                             new System.Data.SqlClient.SqlParameter("@sortOrder", System.Data.SqlDbType.Int) { Value = sortOrder },
                             new System.Data.SqlClient.SqlParameter("@modifierId", System.Data.SqlDbType.Int) { Value = modifierId }
                         };

                         SecureDataAccess.ExecuteNonQuery(strSQLUpdate, parameters);
                         LoadModifierList("");
                         Clear();
                     }
                 }         
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void frmModifier_Load(object sender, EventArgs e)
        {
            try
            {
                LoadModifierList();
                Clear();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void Clear()
        {
            txtModifierName.Clear();
            lblModifierId.Text = "-";
            txtPrice.Clear();
            txtSortOrder.Clear();
            txtItemCode.Clear();
            rdbPriceAdd.Checked = true;
            rdbKitchenYes.Checked = true;
            crpBackColor.Value = Color.White;
            crpForeColor.Value = Color.Black;
            btnSave.BackgroundImage = cypos.Properties.Resources.save100x45;
            txtModifierName.Focus();
        }

        public void LoadModifierList(string value="")
        {
            floModifierList.Controls.Clear();

            try
            {
                string strSQL = "SELECT * FROM tbl_Modifier WHERE name LIKE @searchValue + '%'";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@searchValue", System.Data.SqlDbType.NVarChar) { Value = value }
                };

                DataTable dt = SecureDataAccess.GetDataTable(strSQL, parameters);
                lblRows.Text = "Total " + dt.Rows.Count.ToString() + " Modifiers Found";

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button btnModifier = new Button();
                    btnModifier.FlatStyle = FlatStyle.Flat;
                    btnModifier.FlatAppearance.BorderSize = 0;
                    btnModifier.Name = dataReader["name"].ToString();
                    btnModifier.Tag = dataReader["id"];
                    btnModifier.Text = dataReader["name"].ToString();
                    btnModifier.BackColor = Color.FromArgb(int.Parse(dataReader["back_color"].ToString()));
                    btnModifier.ForeColor = Color.FromArgb(int.Parse(dataReader["fore_color"].ToString()));
                    btnModifier.Margin = new Padding(3, 3, 3, 3);
                    btnModifier.Size = new Size(125, 50);

                    btnModifier.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
                    btnModifier.TextAlign = ContentAlignment.MiddleCenter;
                    btnModifier.Click += new EventHandler(btnModifier_Click);
                    floModifierList.Controls.Add(btnModifier);
                    currentImage++;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string s;
            s = b.Tag.ToString();
            this.ModifierID = s;
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


        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = Messages.DeleteMessage();

            if (result == true)
            {
                if (lblModifierId.Text != "-")
                {
                    int modifierId = 0;
                    int.TryParse(lblModifierId.Text, out modifierId);

                    string sqldel = "DELETE FROM tbl_Modifier WHERE id = @modifierId";

                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@modifierId", System.Data.SqlDbType.Int) { Value = modifierId }
                    };

                    SecureDataAccess.ExecuteNonQuery(sqldel, parameters);
                    Messages.DeletedMessage();
                    LoadModifierList("");
                    Clear();
                }
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

        private void lblModifierId_TextChanged(object sender, EventArgs e)
        {
            if (lblModifierId.Text != "-")
            {
                GetModifierById(lblModifierId.Text);
                btnSave.BackgroundImage = cypos.Properties.Resources.update100x45;
                btnDelete.Visible = true;
            }
        }

        private void GetModifierById(string ModifierId)
        {
            string strSQL = "SELECT * FROM tbl_Modifier WHERE id = @modifierId";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@modifierId", System.Data.SqlDbType.Int) { Value = int.Parse(ModifierId) }
            };

            DataTable dtTable = SecureDataAccess.GetDataTable(strSQL, parameters);

            //lblModifierId.Text = dtTable.Rows[0].ItemArray[0].ToString();
            txtModifierName.Text = dtTable.Rows[0]["name"].ToString();
            txtPrice.Text = dtTable.Rows[0]["price"].ToString();
            string strPriceMethod = dtTable.Rows[0]["price_method"].ToString();
            if (strPriceMethod == "+")
            {
                rdbPriceAdd.Checked = true;
            }
            else
            {
                rdbPriceDeduct.Checked = true;
            }

            txtItemCode.Text = dtTable.Rows[0]["item_code"].ToString();

            bool isKitchenPrint = bool.Parse(dtTable.Rows[0]["print_to_kitchen"].ToString());

            if (isKitchenPrint)
            {
                rdbKitchenYes.Checked = true;
            }
            else
            {
                rdbKitchenNo.Checked = true;
            }
            crpBackColor.Value = Color.FromArgb(int.Parse(dtTable.Rows[0]["back_color"].ToString()));
            crpForeColor.Value = Color.FromArgb(int.Parse(dtTable.Rows[0]["fore_color"].ToString()));
            txtSortOrder.Text = dtTable.Rows[0]["sort_order"].ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtSearchModifier_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadModifierList(txtSearchModifier.Text.ToString());
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtSortOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

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

        private void btnItem_Click(object sender, EventArgs e)
        {
            frmItemPopup frmItemPopup = new frmItemPopup(this);
            frmItemPopup.ShowDialog();
        }

        public void SetItemCode(string strItemCode)
        {
            lblTitle.Text = "Select an item";
            txtItemCode.Text = strItemCode;
        }

        private void btnKbSearch_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtSearchModifier);
            frmKeyboard.ShowDialog();
        }

        private void btnKbSortOrder_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtSortOrder);
            frmNumberboard.ShowDialog();
        }

        private void btnKbPrice_Click(object sender, EventArgs e)
        {
            frmCurrencyboard frmCurrencyboard = new frmCurrencyboard(txtPrice);
            frmCurrencyboard.ShowDialog();
        }

        private void btnKbName_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtModifierName);
            frmKeyboard.ShowDialog();
        }
    }
}
