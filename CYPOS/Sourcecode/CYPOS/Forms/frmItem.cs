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
    public partial class frmItem : Form
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

        public frmItem(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm;
        }

        #region Item List

        public void LoadItemList()
        {
            try
            {
                //Item Category
                string strSQL = "SELECT id,category_name FROM tbl_Category WHERE active=1 ORDER BY category_name";
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
                string strSQL = @"SELECT tbl_Item.*, tbl_Category.category_name FROM tbl_Item
                              LEFT JOIN tbl_Category ON tbl_Item.category_id = tbl_Category.id
                              WHERE (item_name LIKE @searchValue + '%')
                              OR (item_code LIKE @searchValue + '%')
                              OR (category_name = @searchValue)";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@searchValue", System.Data.SqlDbType.NVarChar) { Value = value }
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
                        // Use default image from resources if image file not found
                        il.Images.Add(Properties.Resources.no_image);
                        b.Image = il.Images[0];
                    }
                    b.Margin = new Padding(3, 3, 3, 3);

                    b.Size = new Size(150, 50);

                    b.Text = " " + dataReader["item_code"] + "\n ";
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
            string strSQL = @"SELECT id, item_code, item_name, cost_price, selling_price, discount,
                          category_id, image_name, tax_apply, show_kitchen, print_kot, show_pos,
                          stock_item, reorder_level, active, sort_order FROM tbl_Item WHERE item_code = @itemCode";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@itemCode", System.Data.SqlDbType.NVarChar) { Value = lblItemCode.Text }
            };

            DataTable dtItem = SecureDataAccess.GetDataTable(strSQL, parameters);

            txtItemCode.Text = dtItem.Rows[0]["item_code"].ToString();
            txtItemName.Text = dtItem.Rows[0]["item_name"].ToString();
            txtCostPrice.Text = dtItem.Rows[0]["cost_price"].ToString();
            txtSellingPrice.Text = dtItem.Rows[0]["selling_price"].ToString();
            txtDiscount.Text = dtItem.Rows[0]["discount"].ToString();
            cmbCategory.SelectedValue =int.Parse(dtItem.Rows[0]["category_id"].ToString());

            lblImageName.Text = dtItem.Rows[0]["image_name"].ToString();
            string strImagePath = Application.StartupPath + @"\ItemImages\" + dtItem.Rows[0]["image_name"].ToString();

            // Load image with error handling
            if (File.Exists(strImagePath))
            {
                pbxItemImage.ImageLocation = strImagePath;
                if (pbxItemImage.InitialImage != null)
                {
                    pbxItemImage.InitialImage.Dispose();
                }
            }
            else
            {
                // Use default image if file not found
                pbxItemImage.Image = Properties.Resources.no_image;
            }
            
            cbxTaxable.Checked = Convert.ToBoolean(dtItem.Rows[0]["tax_apply"]) ? true : false;
            cbxKitchenDisplay.Checked = Convert.ToBoolean(dtItem.Rows[0]["show_kitchen"]) ? true : false;
            cbxPrintInKot.Checked = Convert.ToBoolean(dtItem.Rows[0]["print_kot"]) ? true : false;
            cbxShowInPOS.Checked = Convert.ToBoolean(dtItem.Rows[0]["show_pos"]) ? true : false;
            cbxStockItem.Checked = Convert.ToBoolean(dtItem.Rows[0]["stock_item"]) ? true : false;
            cbxActive.Checked = Convert.ToBoolean(dtItem.Rows[0]["active"]) ? true : false;
            txtSortOrder.Text = dtItem.Rows[0]["sort_order"].ToString();
            txtReOrderLevel.Text = dtItem.Rows[0]["reorder_level"].ToString();
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

                //Item Category
                string strSQL = "SELECT id,category_name FROM tbl_Category WHERE active=1 ORDER BY category_name ";
                DataTable dtCategory = SecureDataAccess.GetDataTable(strSQL);
                DataRow dr = dtCategory.NewRow();
                dr["id"] = 0;
                dr["category_name"] = "Select";
                dtCategory.Rows.InsertAt(dr, 0);
                cmbCategory.DataSource = dtCategory;
                cmbCategory.ValueMember = "id";
                cmbCategory.DisplayMember = "category_name";
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
            if (txtItemCode.Text == string.Empty )
            {
                Messages.InformationMessage("Enter item code");
                txtItemCode.Focus();
            }
            else if (txtItemName.Text == string.Empty)
            {
                Messages.InformationMessage("Enter item name");
                txtItemName.Focus();
            }

            else if (txtSellingPrice.Text == string.Empty)
            {
                Messages.InformationMessage("Enter selling price");
                txtSellingPrice.Focus();
            }
            else if (cmbCategory.SelectedValue.ToString() =="0")
            {
                Messages.InformationMessage("Select category");
                cmbCategory.Focus();
            }
            else
            {
                if (txtSortOrder.Text == string.Empty)
                {
                    txtSortOrder.Text = "0";
                }
                if (txtDiscount.Text == string.Empty)
                {
                    txtDiscount.Text = "0";
                }
                if (txtCostPrice.Text == string.Empty)
                {
                    txtCostPrice.Text = "0";
                }
                if (txtDiscount.Text == string.Empty)
                {
                    txtDiscount.Text = "0";
                }
                if (txtReOrderLevel.Text == string.Empty)
                {
                    txtReOrderLevel.Text = "0";
                }
                try
                {
                    bool TaxApply = cbxTaxable.Checked ? true : false;
                    bool ShowInKitchen = cbxKitchenDisplay.Checked ? true : false;
                    bool PrintInKot = cbxPrintInKot.Checked ? true : false;
                    bool ShowInPos = cbxShowInPOS.Checked ? true : false;
                    bool StockItem = cbxStockItem.Checked ? true : false;
                    bool Active = cbxActive.Checked ? true : false;
           
                    if (lblItemCode.Text == "-")
                    {
                        string imageName = txtItemCode.Text + lblFileExtension.Text;

                        // Sécuriser les conversions avec TryParse
                        decimal costPrice = 0;
                        decimal.TryParse(txtCostPrice.Text, out costPrice);

                        decimal sellingPrice = 0;
                        decimal.TryParse(txtSellingPrice.Text, out sellingPrice);

                        decimal discount = 0;
                        decimal.TryParse(txtDiscount.Text, out discount);

                        decimal reorderLevel = 0;
                        decimal.TryParse(txtReOrderLevel.Text, out reorderLevel);

                        decimal openingStock = 0;
                        decimal.TryParse(txtOpeningStock.Text, out openingStock);

                        int sortOrder = 0;
                        int.TryParse(txtSortOrder.Text, out sortOrder);

                        string strSQLInsert = @"INSERT INTO tbl_Item (item_code, item_name, cost_price, selling_price,
                                              discount, category_id, image_name, tax_apply, show_kitchen, print_kot,
                                              show_pos, stock_item, reorder_level, stock_quantity, sort_order, active)
                                              VALUES (@itemCode, @itemName, @costPrice, @sellingPrice, @discount, @categoryId,
                                              @imageName, @taxApply, @showKitchen, @printKot, @showPos, @stockItem,
                                              @reorderLevel, @openingStock, @sortOrder, @active)";

                        System.Data.SqlClient.SqlParameter[] parameters = {
                            new System.Data.SqlClient.SqlParameter("@itemCode", System.Data.SqlDbType.NVarChar) { Value = txtItemCode.Text },
                            new System.Data.SqlClient.SqlParameter("@itemName", System.Data.SqlDbType.NVarChar) { Value = txtItemName.Text },
                            new System.Data.SqlClient.SqlParameter("@costPrice", System.Data.SqlDbType.Decimal) { Value = costPrice },
                            new System.Data.SqlClient.SqlParameter("@sellingPrice", System.Data.SqlDbType.Decimal) { Value = sellingPrice },
                            new System.Data.SqlClient.SqlParameter("@discount", System.Data.SqlDbType.Decimal) { Value = discount },
                            new System.Data.SqlClient.SqlParameter("@categoryId", System.Data.SqlDbType.Int) { Value = cmbCategory.SelectedValue },
                            new System.Data.SqlClient.SqlParameter("@imageName", System.Data.SqlDbType.NVarChar) { Value = imageName },
                            new System.Data.SqlClient.SqlParameter("@taxApply", System.Data.SqlDbType.Bit) { Value = TaxApply },
                            new System.Data.SqlClient.SqlParameter("@showKitchen", System.Data.SqlDbType.Bit) { Value = ShowInKitchen },
                            new System.Data.SqlClient.SqlParameter("@printKot", System.Data.SqlDbType.Bit) { Value = PrintInKot },
                            new System.Data.SqlClient.SqlParameter("@showPos", System.Data.SqlDbType.Bit) { Value = ShowInPos },
                            new System.Data.SqlClient.SqlParameter("@stockItem", System.Data.SqlDbType.Bit) { Value = StockItem },
                            new System.Data.SqlClient.SqlParameter("@reorderLevel", System.Data.SqlDbType.Decimal) { Value = reorderLevel },
                            new System.Data.SqlClient.SqlParameter("@openingStock", System.Data.SqlDbType.Decimal) { Value = openingStock },
                            new System.Data.SqlClient.SqlParameter("@sortOrder", System.Data.SqlDbType.Int) { Value = sortOrder },
                            new System.Data.SqlClient.SqlParameter("@active", System.Data.SqlDbType.Bit) { Value = Active }
                        };

                        SecureDataAccess.ExecuteNonQuery(strSQLInsert, parameters);

                        //Add to Purchase Table
                        SavePurchase("OB", DateTime.Now.ToString(), openingStock);
                     
                        string path = Application.StartupPath + @"\ItemImages\";
                        System.IO.File.Delete(path + @"\" + imageName);
                        if (!System.IO.Directory.Exists(path))
                        System.IO.Directory.CreateDirectory(Application.StartupPath + @"\ItemImages\");
                        string filename = path + @"\" + openFileDialog1.SafeFileName;
                        pbxItemImage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                        System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                        Clear();
                        LoadItemList();
                        //Messages.SavedMessage();
                    }
                    else  //Update
                    {

                        string strImageName;
                        if (lblFileExtension.Text == "item.png") //if not select image
                        {
                            strImageName = lblImageName.Text;
                        }
                        else  // select image
                        {
                            strImageName = lblItemCode.Text + lblFileExtension.Text;
                        }

                        // Sécuriser les conversions avec TryParse
                        decimal costPrice = 0;
                        decimal.TryParse(txtCostPrice.Text, out costPrice);

                        decimal sellingPrice = 0;
                        decimal.TryParse(txtSellingPrice.Text, out sellingPrice);

                        decimal discount = 0;
                        decimal.TryParse(txtDiscount.Text, out discount);

                        decimal reorderLevel = 0;
                        decimal.TryParse(txtReOrderLevel.Text, out reorderLevel);

                        int sortOrder = 0;
                        int.TryParse(txtSortOrder.Text, out sortOrder);

                        string strSQLUpdate = @"UPDATE tbl_Item SET
                                    item_code = @itemCode,
                                    item_name = @itemName,
                                    cost_price = @costPrice,
                                    selling_price = @sellingPrice,
                                    discount = @discount,
                                    category_id = @categoryId,
                                    image_name = @imageName,
                                    tax_apply = @taxApply,
                                    show_kitchen = @showKitchen,
                                    print_kot = @printKot,
                                    show_pos = @showPos,
                                    stock_item = @stockItem,
                                    reorder_level = @reorderLevel,
                                    sort_order = @sortOrder,
                                    active = @active
                                    WHERE item_code = @oldItemCode";

                        System.Data.SqlClient.SqlParameter[] parameters = {
                            new System.Data.SqlClient.SqlParameter("@itemCode", System.Data.SqlDbType.NVarChar) { Value = txtItemCode.Text },
                            new System.Data.SqlClient.SqlParameter("@itemName", System.Data.SqlDbType.NVarChar) { Value = txtItemName.Text },
                            new System.Data.SqlClient.SqlParameter("@costPrice", System.Data.SqlDbType.Decimal) { Value = costPrice },
                            new System.Data.SqlClient.SqlParameter("@sellingPrice", System.Data.SqlDbType.Decimal) { Value = sellingPrice },
                            new System.Data.SqlClient.SqlParameter("@discount", System.Data.SqlDbType.Decimal) { Value = discount },
                            new System.Data.SqlClient.SqlParameter("@categoryId", System.Data.SqlDbType.Int) { Value = cmbCategory.SelectedValue },
                            new System.Data.SqlClient.SqlParameter("@imageName", System.Data.SqlDbType.NVarChar) { Value = strImageName },
                            new System.Data.SqlClient.SqlParameter("@taxApply", System.Data.SqlDbType.Bit) { Value = TaxApply },
                            new System.Data.SqlClient.SqlParameter("@showKitchen", System.Data.SqlDbType.Bit) { Value = ShowInKitchen },
                            new System.Data.SqlClient.SqlParameter("@printKot", System.Data.SqlDbType.Bit) { Value = PrintInKot },
                            new System.Data.SqlClient.SqlParameter("@showPos", System.Data.SqlDbType.Bit) { Value = ShowInPos },
                            new System.Data.SqlClient.SqlParameter("@stockItem", System.Data.SqlDbType.Bit) { Value = StockItem },
                            new System.Data.SqlClient.SqlParameter("@reorderLevel", System.Data.SqlDbType.Decimal) { Value = reorderLevel },
                            new System.Data.SqlClient.SqlParameter("@sortOrder", System.Data.SqlDbType.Int) { Value = sortOrder },
                            new System.Data.SqlClient.SqlParameter("@active", System.Data.SqlDbType.Bit) { Value = Active },
                            new System.Data.SqlClient.SqlParameter("@oldItemCode", System.Data.SqlDbType.NVarChar) { Value = lblItemCode.Text }
                        };

                        SecureDataAccess.ExecuteNonQuery(strSQLUpdate, parameters);

                        //Update Item Image
                          if (lblFileExtension.Text != "item.png") // if select image
                          {
                              pbxItemImage.InitialImage.Dispose();
                              string path = Application.StartupPath + @"\ItemImages\";

                              System.GC.Collect();
                              System.GC.WaitForPendingFinalizers();
                              System.IO.File.Delete(path + @"\" + lblImageName.Text);

                              if (!System.IO.Directory.Exists(path))
                                  System.IO.Directory.CreateDirectory(Application.StartupPath + @"\ItemImages\");
                              string filename = path + @"\" + openFileDialog1.SafeFileName;
                              pbxItemImage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                              System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + strImageName);
                          }
                          Clear();
                          LoadItemList();
                          //Messages.UpdatedMessage();
                          //_frmMain.LoadItems("",0,20);
                    }
                }
                catch (Exception ex)
                {
                    Messages.ExceptionMessage(ex.Message);
                }
            }
        }

        public static Image FromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = Image.FromStream(ms);
            return img;
        }

        private void Clear()
        {
            lblItemCode.Text = "-";
            txtItemCode.Enabled = true;
            txtItemCode.Text = string.Empty;
            txtItemName.Text = string.Empty;
            txtCostPrice.Text = string.Empty;
            txtSellingPrice.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtSearchItem.Text = string.Empty;
            txtSortOrder.Text = string.Empty;
            txtReOrderLevel.Clear();
            cmbSearchCategory.Text = string.Empty;
            cmbCategory.SelectedValue = 0;
            cbxTaxable.Checked = false;
            cbxKitchenDisplay.Checked = false;
            cbxPrintInKot.Checked = false;
            cbxShowInPOS.Checked = true;
            cbxStockItem.Checked = false;
            cbxActive.Checked = true;
            txtOpeningStock.Enabled = true;
            lblImageName.Text = "-";
            pbxItemImage.Image = Properties.Resources.no_image;
            btnSave.BackgroundImage = Properties.Resources.save100x45;

            if (Settings.AutoItemNo)
            {
                txtItemCode.ReadOnly = true;
                int nextNo = Settings.LastItemAutoNo + 1;
                txtItemCode.Text = nextNo.ToString();
            }
            else
            {
                txtItemCode.ReadOnly = false;
                txtItemCode.Clear();
            }

            txtItemCode.Focus();
        }

      
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //  openFileDialog1.InitialDirectory = @"C:\";
            //  openFileDialog1.Title = "Browse Text Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = ".jpg";
            // openFileDialog1.Filter = "GIF files (*.gif)|*.gif| jpg files (*.jpg)|*.jpg| PNG files (*.png)|*.png| All files (*.*)|*.*";
            openFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg| PNG Files (*.png)|*.png";

            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            //openFileDialog1.ReadOnlyChecked = true;
            //openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbxItemImage.ImageLocation = openFileDialog1.FileName;
                lblFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
            }
        }

        
        #endregion

     
        private void txtSellingPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtSellingPrice.Text.ToString(), @"\.\d\d");

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

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtDiscount.Text.ToString(), @"\.\d\d");

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
      
       
        #region Purchase 

        public void SavePurchase(string strType, string strDate, decimal quantity)
        {
            string strItemId = txtItemCode.Text;

            // Sécuriser la conversion avec TryParse
            decimal price = 0;
            decimal.TryParse(txtSellingPrice.Text, out price);

            string strSQLInsert = @"INSERT INTO tbl_Purchase (purchase_date, ref_no, supplier_id, product_id, quantity, price, purchase_type)
                                  VALUES (@purchaseDate, @refNo, @supplierId, @productId, @quantity, @price, @purchaseType)";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@purchaseDate", System.Data.SqlDbType.NVarChar) { Value = strDate },
                new System.Data.SqlClient.SqlParameter("@refNo", System.Data.SqlDbType.NVarChar) { Value = "" },
                new System.Data.SqlClient.SqlParameter("@supplierId", System.Data.SqlDbType.Int) { Value = 0 },
                new System.Data.SqlClient.SqlParameter("@productId", System.Data.SqlDbType.NVarChar) { Value = strItemId },
                new System.Data.SqlClient.SqlParameter("@quantity", System.Data.SqlDbType.Decimal) { Value = quantity },
                new System.Data.SqlClient.SqlParameter("@price", System.Data.SqlDbType.Decimal) { Value = price },
                new System.Data.SqlClient.SqlParameter("@purchaseType", System.Data.SqlDbType.NVarChar) { Value = strType }
            };

            SecureDataAccess.ExecuteNonQuery(strSQLInsert, parameters);
        }

        #endregion

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = Messages.QuestionMessage("Do you want to Delete?");

            if (result == true)
            {

                if (lblItemCode.Text == "-")
                {
                    Messages.InformationMessage("The record could not be deleted.");
                }
                else
                {
                    try
                    {
                        string sql = "DELETE FROM tbl_Item WHERE item_code = @itemCode";
                        System.Data.SqlClient.SqlParameter[] parameters = {
                            new System.Data.SqlClient.SqlParameter("@itemCode", System.Data.SqlDbType.NVarChar) { Value = lblItemCode.Text }
                        };
                        SecureDataAccess.ExecuteNonQuery(sql, parameters);

                        pbxItemImage.InitialImage.Dispose();
                        string path = Application.StartupPath + @"\ItemImages\";
                        System.IO.File.Delete(path + @"\" + lblImageName.Text);
                        //Messages.InformationMessage("Successfully deleted");
                        Clear();
                        LoadItemList();
                    }
                    catch (Exception ex)
                    {
                        Messages.ExceptionMessage(ex.Message);
                    }
                }
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

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void lblItemCode_TextChanged(object sender, EventArgs e)
        {
            if (lblItemCode.Text != "-")
            {
                GetItemByCode();
                txtItemCode.Enabled = false;
                txtOpeningStock.Enabled = false;
                btnSave.BackgroundImage = cypos.Properties.Resources.update100x45;
                btnDelete.Visible = true;
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                pbxItemImage.Image = cypos.Properties.Resources.no_image;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        private void txtItemCode_Leave(object sender, EventArgs e)
        {
            try
            {
                string sqlitemcode = "SELECT item_code FROM tbl_Item WHERE item_code = @itemCode";
                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@itemCode", System.Data.SqlDbType.NVarChar) { Value = txtItemCode.Text }
                };
                DataTable dtitemcode = SecureDataAccess.GetDataTable(sqlitemcode, parameters);
                if (dtitemcode.Rows.Count > 0)
                {
                    this.ItemCode = txtItemCode.Text;
                    btnKbItemCode.Enabled = false;
                }
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

        private void txtCostPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtCostPrice.Text.ToString(), @"\.\d\d");

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

        private void txtSortOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtReOrderLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool IgnoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtReOrderLevel.Text.ToString(), @"\.\d\d");

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

        private void btnKbItemCode_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtItemCode);
            frmKeyboard.ShowDialog();
        }

        private void btnKbSortOrder_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtSortOrder);
            frmNumberboard.ShowDialog();
        }

        private void btnKbItemName_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtItemName);
            frmKeyboard.ShowDialog();
        }

        private void btnKbReOrder_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtReOrderLevel);
            frmNumberboard.ShowDialog();
        }

        private void btnKbOpStock_Click(object sender, EventArgs e)
        {
            frmNumberboard frmNumberboard = new frmNumberboard(txtOpeningStock);
            frmNumberboard.ShowDialog();
        }

        private void btnKbCost_Click(object sender, EventArgs e)
        {
            frmCurrencyboard frmCurrencyboard = new frmCurrencyboard(txtCostPrice);
            frmCurrencyboard.ShowDialog();
        }

        private void btnKbPrice_Click(object sender, EventArgs e)
        {
            frmCurrencyboard frmCurrencyboard = new frmCurrencyboard(txtSellingPrice);
            frmCurrencyboard.ShowDialog();
        }

        private void btnKbDiscount_Click(object sender, EventArgs e)
        {
            frmCurrencyboard frmCurrencyboard = new frmCurrencyboard(txtDiscount);
            frmCurrencyboard.ShowDialog();
        }

        // Arrondi automatique au format Franc CFA (sans décimales)
        private void txtSellingPrice_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSellingPrice.Text))
            {
                decimal rounded = Currency.Parse(txtSellingPrice.Text);
                txtSellingPrice.Text = Currency.FormatInput(rounded);
            }
        }

        private void txtCostPrice_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCostPrice.Text))
            {
                decimal rounded = Currency.Parse(txtCostPrice.Text);
                txtCostPrice.Text = Currency.FormatInput(rounded);
            }
        }
    }
}
