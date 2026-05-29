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
    public partial class frmPurchase : Form
    {
        private frmPurchaseList _frmPurchaseList;  

        /****** To make the window movable *********/

        public const int WM_NCLBUTTONDOWN = 0xA1; 
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        /*********************************************/

        public frmPurchase(frmPurchaseList _frm)
        {
            InitializeComponent();
            _frmPurchaseList = _frm; 
        }

        #region Item List

        public void LoadItemList()
        {
            try
            {
                //Item Category
                string strSQL = "SELECT DISTINCT tbl_Category.id, tbl_Category.category_name,tbl_Category.sort_order," +
                "tbl_Category.back_color,tbl_Category.fore_color, tbl_Category.active FROM tbl_Item " +
                "INNER JOIN tbl_Category ON tbl_Item.category_id = tbl_Category.id WHERE tbl_Item.stock_item=1";

                DataTable dtCategory = SecureDataAccess.GetDataTable(strSQL);
                cmbSearchCategory.DataSource = dtCategory;
                cmbSearchCategory.ValueMember = "id";
                cmbSearchCategory.DisplayMember = "category_name";

                LoadItemList("");

            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        public void LoadItemList(string value)
        {
            floItemList.Controls.Clear();
            string img_directory = Application.StartupPath + @"\ItemImages\";
            string[] files = Directory.GetFiles(img_directory, "*.png *.jpg");
            try
            {
                string strSQL="SELECT tbl_Item.*, tbl_Category.category_name FROM tbl_Item " +
                              "LEFT JOIN tbl_Category ON tbl_Item.category_id = tbl_Category.id " +
                              "WHERE (( item_name LIKE @searchTerm ) " +
                              "OR ( item_code LIKE @searchTerm ) " +
                              "OR (category_name = @exactValue)) AND stock_item=1";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@searchTerm", System.Data.SqlDbType.NVarChar) { Value = value + "%" },
                    new System.Data.SqlClient.SqlParameter("@exactValue", System.Data.SqlDbType.NVarChar) { Value = value }
                };

                DataTable dt = SecureDataAccess.GetDataTable(strSQL, parameters);
                lblRows.Text = "Total " + dt.Rows.Count.ToString() + " Items Found";

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];
                    Button b = new Button();
                    //b.FlatStyle = FlatStyle.Flat;
                    //b.FlatAppearance.BorderSize = 1;
                    //b.FlatAppearance.BorderColor= Color.Gray;
                    //b.BackColor = Color.LightYellow;
                    b.Tag = dataReader["item_code"];
                    b.Click += new EventHandler(btnItem_Click);

                    b.Name = dataReader["id"].ToString(); 

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(32, 32);

                    // Load image with error handling
                    string imagePath = img_directory + dataReader["image_name"].ToString();
                    if (File.Exists(imagePath))
                    {
                        il.Images.Add(Image.FromFile(imagePath));
                        b.Image = il.Images[0];
                    }
                    else
                    {
                        // Use default image if file not found
                        il.Images.Add(Properties.Resources.no_image);
                        b.Image = il.Images[0];
                    }
                    b.Margin = new Padding(3, 3, 3, 3);

                    b.Size = new Size(150, 50);

                    b.Text += " " + dataReader["item_code"] + "\n ";
                    b.Text += dataReader["item_name"].ToString();
                    b.Text += "\n Price: " + Currency.Format(Convert.ToDecimal(dataReader["selling_price"]));

                    b.Font = new Font("Tahoma", 9, FontStyle.Regular, GraphicsUnit.Point);
                    b.TextAlign = ContentAlignment.TopLeft;
                    b.TextImageRelation = TextImageRelation.ImageBeforeText;
                    floItemList.Controls.Add(b);
                    currentImage++;
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        protected void btnItem_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string s;
            s = b.Tag.ToString();
            this.ItemCode = s;
        }

        #endregion

        public string ItemCode
        {
            set { lblItemCode.Text = value; }
            get { return lblItemCode.Text; }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region DataBind

        private void GetItemByCode()
        {
            string strSQL="SELECT id, item_code, item_name, cost_price, selling_price, discount," +
                          "category_id, image_name, tax_apply, show_kitchen, print_kot, show_pos,"+
                          "stock_item,reorder_level,stock_quantity,active,sort_order FROM tbl_Item WHERE item_code = @itemCode";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@itemCode", System.Data.SqlDbType.NVarChar) { Value = lblItemCode.Text }
            };

            DataTable dtItem = SecureDataAccess.GetDataTable(strSQL, parameters);

            lblItemId.Text= dtItem.Rows[0]["id"].ToString();
            lblItemName.Text = dtItem.Rows[0]["item_name"].ToString();
            lblCostPrice.Text = dtItem.Rows[0]["cost_price"].ToString();
            lblSellingPrice.Text = dtItem.Rows[0]["selling_price"].ToString();
            lblReOrderLevel.Text = dtItem.Rows[0]["reorder_level"].ToString();
            lblCurrentStock.Text = dtItem.Rows[0]["stock_quantity"].ToString();
        }


        private void frmItem_Load(object sender, EventArgs e)
        {
            try
            {
                if (UserInfo.UserType == "1")
                {
                    
                }
                else
                {
                    
                }

                //Supplier
                string strSQL = "SELECT id,name FROM tbl_Supplier ORDER BY name ";

                DataTable dtCategory = SecureDataAccess.GetDataTable(strSQL);
                DataRow dr = dtCategory.NewRow();
                dr["id"] = 0;
                dr["name"] = "Cash";
                dtCategory.Rows.InsertAt(dr, 0);
                cmbSupplier.DataSource = dtCategory;
                cmbSupplier.ValueMember = "id";
                cmbSupplier.DisplayMember = "name";
                LoadItemList();
                Clear();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }
        #endregion

        #region Insert , Update and delete Item
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblItemId.Text == "0")
            {
                Messages.InformationMessage("Select an item");
            }
            else if (txtQty.Text == "0" || txtQty.Text == string.Empty)
            {
                Messages.InformationMessage("Enter quantity");
                txtQty.Focus();
            }
            else if (txtPrice.Text == "0" || txtPrice.Text==string.Empty)
            {
                Messages.InformationMessage("Enter price");
                txtPrice.Focus();
            }
            else
            {
                //Add to Purchase Table (avec transaction atomique : INSERT + UPDATE Stock)
                SavePurchase("NEW", dtpDate.Text, Convert.ToDouble(txtQty.Text));
                Clear();
            }

        }

        private void Clear()
        {
            lblItemId.Text = "0";
            lblItemCode.Text = string.Empty;
            lblItemName.Text = string.Empty;
            lblCostPrice.Text = string.Empty;
            lblSellingPrice.Text = string.Empty;
            lblCurrentStock.Text = string.Empty;
            lblReOrderLevel.Text = string.Empty;
            dtpDate.Value = DateTime.Now;
            cmbSearchCategory.SelectedIndex = 0;
            cmbSupplier.SelectedValue = 0;
            txtRefNo.Clear();
            txtQty.Clear();
            txtPrice.Clear();
            lblAmount.Text = string.Empty;
        }
              
  

        
        #endregion

     

        #region Purchase

        // ===============================================================================
        // OPÉRATION CRITIQUE AVEC TRANSACTION SQL
        // SavePurchase + UpdateStock doivent être atomiques
        // Si une étape échoue, TOUT est rollback automatiquement
        // ===============================================================================
        public void SavePurchase(string strType, string strDate, double dblQty)
        {
            try
            {
                int iItemId = int.Parse(lblItemId.Text.ToString());
                double dblPrice = Convert.ToDouble(txtPrice.Text);
                double dblAmount = Convert.ToDouble(lblAmount.Text);
                double dblStockQty = Convert.ToDouble(lblCurrentStock.Text) + dblQty;

                SecureDataAccess.ExecuteTransaction((conn, transaction) =>
                {
                    // ÉTAPE 1 : INSERT Purchase Record
                    string strSQLInsert = @"INSERT INTO tbl_Purchase
                        (purchase_date, ref_no, supplier_id, product_id, quantity, price, amount, purchase_type)
                        VALUES
                        (@purchaseDate, @refNo, @supplierId, @productId, @quantity, @price, @amount, @purchaseType)";

                    using (System.Data.SqlClient.SqlCommand cmdInsert = new System.Data.SqlClient.SqlCommand(strSQLInsert, conn, transaction))
                    {
                        cmdInsert.Parameters.AddWithValue("@purchaseDate", strDate);
                        cmdInsert.Parameters.AddWithValue("@refNo", txtRefNo.Text);
                        cmdInsert.Parameters.AddWithValue("@supplierId", cmbSupplier.SelectedValue);
                        cmdInsert.Parameters.AddWithValue("@productId", iItemId);
                        cmdInsert.Parameters.AddWithValue("@quantity", dblQty);
                        cmdInsert.Parameters.AddWithValue("@price", dblPrice);
                        cmdInsert.Parameters.AddWithValue("@amount", dblAmount);
                        cmdInsert.Parameters.AddWithValue("@purchaseType", strType);

                        cmdInsert.ExecuteNonQuery();
                    }

                    // ÉTAPE 2 : UPDATE Stock Quantity
                    string strSQLUpdate = "UPDATE tbl_Item SET stock_quantity = @newStock WHERE id = @itemId";

                    using (System.Data.SqlClient.SqlCommand cmdUpdate = new System.Data.SqlClient.SqlCommand(strSQLUpdate, conn, transaction))
                    {
                        cmdUpdate.Parameters.AddWithValue("@newStock", dblStockQty);
                        cmdUpdate.Parameters.AddWithValue("@itemId", iItemId);

                        cmdUpdate.ExecuteNonQuery();
                    }
                });

                // Si on arrive ici : COMMIT réussi
                _frmPurchaseList.LoadPurchaseList();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage("Erreur lors de l'enregistrement de l'achat: " + ex.Message);
                throw; // Re-throw pour que l'appelant sache qu'il y a eu erreur
            }
        }

        // OBSOLÈTE - Maintenant intégré dans SavePurchase avec transaction
        public void UpdatePurchase()
        {
            // Cette méthode n'est plus utilisée
            // La mise à jour du stock est maintenant dans SavePurchase() en transaction atomique
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

        private void btnKbSearchProduct_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtSearchItem);
            frmKeyboard.ShowDialog(); 
        }


        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadItemList(txtSearchItem.Text);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void cmbSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadItemList(cmbSearchCategory.Text);
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void lblItemCode_TextChanged(object sender, EventArgs e)
        {
            if (lblItemCode.Text != string.Empty)
            {
                GetItemByCode();
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text != string.Empty && txtPrice.Text != string.Empty)
            {
                decimal decAmount = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtPrice.Text);
                lblAmount.Text = Currency.Format(decAmount);
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtQty.Text.ToString(), @"\.\d\d");

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

        // Arrondi automatique au format Franc CFA (sans décimales)
        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                decimal rounded = Currency.Parse(txtPrice.Text);
                txtPrice.Text = Currency.FormatInput(rounded);

                // Recalculer le montant total (même logique que txtPrice_TextChanged)
                if (txtQty.Text != string.Empty && txtPrice.Text != string.Empty)
                {
                    decimal decAmount = Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtPrice.Text);
                    lblAmount.Text = Currency.Format(decAmount);
                }
            }
        }

        private void btnKbRef_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtRefNo);
            frmKeyboard.ShowDialog();
        }

        private void btnKbQty_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtQty);
            frmNumberboard.ShowDialog();
        }

        private void btnKbPrice_Click(object sender, EventArgs e)
        {
            frmCurrencyboard frmCurrencyboard = new frmCurrencyboard(txtPrice);
            frmCurrencyboard.ShowDialog();
        }
    }
}
