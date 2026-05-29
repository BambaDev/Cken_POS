using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using Microsoft.Reporting.WinForms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Microsoft.PointOfService;

namespace cypos 
{
    public partial class frmMain : Form
    {
        ErrorLog objerror = new ErrorLog();
        int holdId;
        //Cash Drawers
        private PosExplorer myExplorer;
        private CashDrawer myCashDrawer;
        // Navigation
        private DataTable dtAllItems;

        #region Taskbar
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        [Flags]
        private enum SetWindowPosFlags : uint
        {
            SWP_ASYNCWINDOWPOS = 0x4000,
            SWP_DEFERERASE = 0x2000,
            SWP_DRAWFRAME = 0x0020,
            SWP_FRAMECHANGED = 0x0020,
            SWP_HIDEWINDOW = 0x0080,
            SWP_NOACTIVATE = 0x0010,
            SWP_NOCOPYBITS = 0x0100,
            SWP_NOMOVE = 0x0002,
            SWP_NOOWNERZORDER = 0x0200,
            SWP_NOREDRAW = 0x0008,
            SWP_NOREPOSITION = 0x0200,
            SWP_NOSENDCHANGING = 0x0400,
            SWP_NOSIZE = 0x0001,
            SWP_NOZORDER = 0x0004,
            SWP_SHOWWINDOW = 0x0040,
        }

        [DllImport("user32", EntryPoint = "FindWindowA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr parentHwnd, IntPtr childAfterHwnd, IntPtr className, string windowText);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetWindow(IntPtr hWnd, GetWindowCmd uCmd);

        private enum GetWindowCmd : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

        // The taskbar's window handle.
        private IntPtr TaskbarHWnd, StartButtonHWnd;
        #endregion

        // Helper method pour conversion sécurisée des labels formatés (N2)
        private double SafeParseLabel(string labelText)
        {
            double result = 0;
            double.TryParse(labelText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out result);
            return result;
        }

        public frmMain()
        {
            InitializeComponent();
            //Cash Drawers
            //myExplorer = new PosExplorer(this);
            //DeviceInfo device = myExplorer.GetDevice("CashDrawer", "WASPCD");
            //myCashDrawer = (CashDrawer)myExplorer.CreateInstance(device);  

            #region Hide Taskbar
            // Get the taskbar's and start button's window handles.
            TaskbarHWnd = FindWindow("Shell_traywnd", "");
            StartButtonHWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, (IntPtr)0xC017, null);

            // Hide the taskbar and start button.
            SetWindowPos(TaskbarHWnd, IntPtr.Zero, 0, 0, 0, 0,
                SetWindowPosFlags.SWP_HIDEWINDOW);
            SetWindowPos(StartButtonHWnd, IntPtr.Zero, 0, 0, 0, 0,
                SetWindowPosFlags.SWP_HIDEWINDOW);

            // Maximize.
            this.Bounds = Screen.PrimaryScreen.Bounds;
            #endregion
            lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            btnUser.Tag = UserInfo.UserName.ToString();
            btnUser.Text ="User" +Environment.NewLine + UserInfo.UserName;

            floItemList.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;

  
            //Grids Fonts
            dgvItemList.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            dgvItemList.RowHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            dgvItemList.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);

            btnModifier.Enabled = false;

            NextInvoiceNumber();
            NextKotNumber();
        }

        #region Databind
        //Default Form Load 
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                Clear();
                LoadCategories();
                   
                //Hide fields
                dgvItemList.Columns["clmItemCode"].Visible = false; 
                dgvItemList.Columns["clmDiscountAmount"].Visible = false; 
                dgvItemList.Columns["clmTax1Amount"].Visible = false; 
                dgvItemList.Columns["clmDiscountRate"].Visible = false; 
                dgvItemList.Columns["clmTaxApply"].Visible = false;
                dgvItemList.Columns["clmKitchenDisplay"].Visible = false; 

                dgvItemList.Columns["clmQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvItemList.Columns["clmTaxApply"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgvItemList.Columns["clmPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // Format FCFA manuel - pas de format automatique "N2"

                dgvItemList.Columns["clmAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // Format FCFA manuel - pas de format automatique "N2"
               
                //  Column width
                dgvItemList.Columns["clmItemName"].Width = 200;     
            }
            catch (Exception ex)
            {
                objerror.Write(ex.Message.ToString(), this.Name + " - frmMain_Load", Global.ERROR_WRITE_PATH);
            }
        }



        private void NextInvoiceNumber()
        {
            int inNextAutoNo;
            int inStartNo;
            int inLastAutoNo;
            string strNextAutoNo;
            string strNextInvoiceNo;

            inStartNo = Settings.StartingInvoiceNo;
            inLastAutoNo = Settings.LastInvoiceAutoNo;

            if (inLastAutoNo == 0)//First Use
            {
                inNextAutoNo = inStartNo;
            }
            else
            {
                inNextAutoNo = inLastAutoNo + 1;
            }
            if (Settings.ShowLeadingZeros)
            {
                strNextAutoNo = inNextAutoNo.ToString().PadLeft(Settings.LeadingZerosCount, '0');
            }
            else
            {
                strNextAutoNo = inNextAutoNo.ToString();
            }
            strNextInvoiceNo = Settings.InvoiceNoPrefix + strNextAutoNo ;
            lblInvoiceNo.Text = strNextInvoiceNo;
        }

        private void NextKotNumber()
        {
            int inNextAutoNo;
            int inStartNo;
            int inLastAutoNo;
            string strNextAutoNo;
            string strNextKotNo;

            inStartNo = Settings.StartingKotNo;
            inLastAutoNo = Settings.LastKotAutoNo;

            if (inLastAutoNo == 0)//First Use
            {
                inNextAutoNo = inStartNo;
            }
            else
            {
                inNextAutoNo = inLastAutoNo + 1;
            }
            if (Settings.KotLeadingZeros)
            {
                strNextAutoNo = inNextAutoNo.ToString().PadLeft(Settings.KotZerosCount, '0');
            }
            else
            {
                strNextAutoNo = inNextAutoNo.ToString();
            }
            strNextKotNo = Settings.KotNoPrefix + strNextAutoNo;
            lblKotNo.Text = strNextKotNo;
        }

        //Show Products image
        public void LoadItems(DataTable dtItems)
        {
            floItemList.Controls.Clear();
            string img_directory = Application.StartupPath + @"\ItemImages\";
            string[] files = Directory.GetFiles(img_directory, "*.png *.jpg");
            try
            {
                int currentImage = 0;
                for (int i = 0; i < dtItems.Rows.Count; i++)
                {
                    DataRow dataReader = dtItems.Rows[i];

                    Button btnItem = new Button();
                    btnItem.FlatStyle = FlatStyle.Popup;
                    btnItem.FlatAppearance.BorderColor = Color.Gray;
                    btnItem.BackgroundImage = Properties.Resources.item_button_bg;
                    btnItem.Tag = dataReader["item_code"];
                    btnItem.Click += new EventHandler(btnItem_Click);

                    string taxapply;
                    if (dataReader["tax_apply"].ToString() == "1")
                    {
                        taxapply = "YES";
                    }
                    else
                    {
                        taxapply = "NO";
                    }

                    string details = dataReader["item_code"] +
                     "\n Name: " + dataReader["item_name"].ToString() +
                     "\n Retail price: " + dataReader["selling_price"].ToString() +
                     "\n Discount: " + dataReader["discount"].ToString() +
                     "\n Category: " + dataReader["category_name"].ToString() +
                     "\n Tax Apply: " + taxapply;
                    btnItem.Name = details;                 

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(78, 80);

                    // Load image with error handling
                    string imagePath = img_directory + dataReader["image_name"].ToString();
                    if (File.Exists(imagePath))
                    {
                        il.Images.Add(Image.FromFile(imagePath));
                        btnItem.Image = il.Images[0];
                    }
                    else
                    {
                        // Use default image if file not found
                        il.Images.Add(Properties.Resources.no_image);
                        btnItem.Image = il.Images[0];
                    }
                    btnItem.Margin = new Padding(3, 3, 3, 3);
                    btnItem.Size = new Size(125, 125);

                    btnItem.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
                    btnItem.TextAlign = ContentAlignment.MiddleCenter;
                    btnItem.TextImageRelation = TextImageRelation.ImageAboveText;

                    btnItem.Text += dataReader["item_name"].ToString();
                    btnItem.Text += "\n Price: " + dataReader["selling_price"];
  
                    floItemList.Controls.Add(btnItem);
                    currentImage++;
                }
            }
            catch (Exception ex)
            {
                objerror.Write(ex.Message.ToString(), this.Name + " - LoadItems", Global.ERROR_WRITE_PATH);
            }
        }

        private DataTable GetItemList(string value)
        {
            // SÉCURISÉ : Utilise SqlParameter pour prévenir SQL Injection
            string strSQL = "SELECT * FROM vw_ItemDisplay WHERE (item_name LIKE @searchTerm) " +
            " OR (category_name like @categoryTerm) AND (show_pos = 1)";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@searchTerm", System.Data.SqlDbType.NVarChar, 100) { Value = "%" + value + "%" },
                new System.Data.SqlClient.SqlParameter("@categoryTerm", System.Data.SqlDbType.NVarChar, 100) { Value = value + "%" }
            };

            DataTable dtItems = SecureDataAccess.GetDataTable(strSQL, parameters);

            int iItemCount = (from DataRow dr in dtItems.Rows where (bool)dr["show_pos"] == true select dr).Count();
            int iPagesCount = Convert.ToInt32(Math.Ceiling(iItemCount * 1.0 / 20));
            int iCurrentPage = iItemCount % iPagesCount;

            if (iCurrentPage < 1)
            {
                iCurrentPage =1;
            }
            else
            {
                iCurrentPage -= 1;
            }


            if (dtItems.Rows.Count > 20)
            {
                lblCurrentPage.Text = iCurrentPage.ToString();
                lblTotalPages.Text = iPagesCount.ToString();
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
            }
            else
            {
                lblCurrentPage.Text = "1";
                lblTotalPages.Text = iPagesCount.ToString();
                btnPrevious.Enabled = false;
                btnNext.Enabled = false;
            }
            return dtItems;
        }
     
        protected void btnItem_Click(object sender, EventArgs e)
        {
            Button btnClicked = sender as Button;
            int orderType=int.Parse(lblOrderTypeId.Text);
            int tableId = int.Parse(lblTableId.Text);

            if (orderType == 0) // Order Type
            {
                Messages.InformationMessage("Select order type");
            }
            else if (Settings.AskTable && orderType == 1 && tableId == 0) // Dine In and Selected Table 0
            {
                Messages.InformationMessage("Select Table");
            }
            else
            {
                InsertItems(btnClicked);
            }     
        }


        // Check duplicate item 
        public int Finditem(string item)
        {
            int k = -1;
            if (dgvItemList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvItemList.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(item))
                    {
                        k = row.Index;
                        break;
                    }
                }
            }
            return k;
        }

        public int FindItemById(string strItemCode)
        {
            int k = -1;
            if (dgvItemList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvItemList.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(strItemCode))
                    {
                        k = row.Index;
                        break;
                    }
                }
            }
            return k;
        }
        #endregion


        #region Category Databind and click event  | Product filter by Category

        public void LoadCategories()
        {
            floCategory.Controls.Clear();
            string img_directory = Application.StartupPath + @"\ItemImages\";
            string[] files = Directory.GetFiles(img_directory, "*.png *.jpg");
            try
            {
                string strSQL = "SELECT DISTINCT tbl_Category.id, tbl_Category.category_name,tbl_Category.sort_order,"+
                                "tbl_Category.back_color,tbl_Category.fore_color, tbl_Category.active FROM tbl_Item " +
                                "INNER JOIN tbl_Category ON tbl_Item.category_id = tbl_Category.id";

                // Pas de paramètres dynamiques, mais migration vers SecureDataAccess pour cohérence
                DataTable dt = SecureDataAccess.GetDataTable(strSQL);

                int currentImage = 0;
                Button btnAllCategory = new Button();
                btnAllCategory.Text = "All Category";
                btnAllCategory.FlatStyle = FlatStyle.Flat;
                btnAllCategory.FlatAppearance.BorderColor = Color.Gray;
                btnAllCategory.Click += new EventHandler(btnAllCategory_Click);
                btnAllCategory.Margin = new Padding(3, 3, 3, 3);
                btnAllCategory.Size = new Size(122, 50);
                btnAllCategory.Text.PadRight(1);
                btnAllCategory.Font = new Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Point);
                btnAllCategory.TextAlign = ContentAlignment.MiddleCenter;
                btnAllCategory.TextImageRelation = TextImageRelation.Overlay;
                btnAllCategory.BackgroundImage = Properties.Resources.all_category;
                floCategory.Controls.Add(btnAllCategory);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button btnCategory = new Button();
                    btnCategory.FlatStyle = FlatStyle.Flat;
                    btnCategory.FlatAppearance.BorderColor = Color.Gray;

                    btnCategory.BackColor = Color.FromArgb(int.Parse(dataReader["back_color"].ToString()));
                    btnCategory.ForeColor = Color.FromArgb(int.Parse(dataReader["fore_color"].ToString()));

                    btnCategory.Tag = dataReader["id"];
                    btnCategory.Click += new EventHandler(btnCategory_Click);
                
                    btnCategory.Margin = new Padding(3, 3, 3, 3);

                    btnCategory.Size = new Size(122, 50);
                    btnCategory.Text.PadRight(1);

                    btnCategory.Text += dataReader["category_name"].ToString();

                    btnCategory.Font = new Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Point);
                    btnCategory.TextAlign = ContentAlignment.MiddleCenter;
                    btnCategory.TextImageRelation = TextImageRelation.Overlay;
                    floCategory.Controls.Add(btnCategory);
                    currentImage++;
                }
            }
            catch (Exception ex)
            {
                objerror.Write(ex.Message.ToString(), this.Name + " - LoadCategories", Global.ERROR_WRITE_PATH);
            }
        }

        protected void btnAllCategory_Click(object sender, EventArgs e)
        {
            Button btnAllCategory = sender as Button;

            dtAllItems = GetItemList("");

            if (dtAllItems.Rows.Count > 0)
            {
                int iItemCount = (from DataRow dr in dtAllItems.Rows where (bool)dr["show_pos"] == true select dr).Count();
                int iPagesCount = Convert.ToInt32(Math.Ceiling(iItemCount * 1.0 / 20));
                int iCurrentPage = iItemCount % 20;

                int iItemsPerPage = Settings.ItemsPerPage;

                DataTable dtNavItems = dtAllItems.AsEnumerable().OrderBy(r => r.Field<string>("item_name")).Skip(0).Take(iItemsPerPage).CopyToDataTable();

                LoadItems(dtNavItems);
                lblCategory.Text = "All Categories";
                btnPrevious.Enabled = false;
            }

        }

        protected void btnCategory_Click(object sender, EventArgs e)
        {
            Button btnCategory = sender as Button;

            dtAllItems = GetItemList(btnCategory.Text.ToString());

            int iItemsPerPage = Settings.ItemsPerPage;

            DataTable dtNavItems = dtAllItems.AsEnumerable().Skip(0).Take(iItemsPerPage).CopyToDataTable();
            LoadItems(dtNavItems);
            lblCategory.Text = btnCategory.Text;

            int iItemCount = (from DataRow dr in dtAllItems.Rows where (bool)dr["show_pos"] == true select dr).Count();
            int iPagesCount = Convert.ToInt32(Math.Ceiling(iItemCount * 1.0 / 20));

            lblCurrentPage.Text = "1";
            lblTotalPages.Text = iPagesCount.ToString();
            btnPrevious.Enabled = false;

        }
        #endregion

        private void InsertItems(Button btnClicked)
        {

            // Default tax rate 
            if (TaxValue.TaxType == "NoTax")
            {
                lblTax1Name.Text = String.Empty;
                lblTax1Rate.Text = "0";
                lblTax2Name.Text = String.Empty;
                lblTax2Rate.Text = "0";

                lblTotalTax1.Text = "0";
                lblTotalTax2.Text = "0";

                lblTotalTax1.Visible = false;
                lblTotalTax2.Visible = false;

                lblTax1Name.Visible = false;
                lblTax1Rate.Visible = false;
                lblTax2Name.Visible = false;
                lblTax2Rate.Visible = false;
            }
            else if (TaxValue.TaxType == "1LevelofTax")
            {
                lblTax1Name.Text = TaxValue.Tax1Name + " (%):";
                lblTax1Rate.Text = TaxValue.Tax1Rate;
                lblTax2Name.Text = String.Empty;
                lblTax2Rate.Text = "0";
                lblTotalTax2.Text = "0";
                lblTotalTax1.Visible = true;
                lblTotalTax2.Visible = false;
                lblTax1Name.Visible = true;
                lblTax1Rate.Visible = true;
                lblTax2Name.Visible = false;
                lblTax2Rate.Visible = false;
            }

            else if (TaxValue.TaxType == "2LevelofTax")
            {
                lblTax1Name.Text = TaxValue.Tax1Name + " (%):";
                lblTax1Rate.Text = TaxValue.Tax1Rate;
                lblTax2Name.Text = TaxValue.Tax2Name + " (%):";
                lblTax2Rate.Text = TaxValue.Tax2Rate;

                lblTotalTax1.Visible = true;
                lblTotalTax2.Visible = true;

                lblTax1Name.Visible = true;
                lblTax1Rate.Visible = true;
                lblTax2Name.Visible = true;
                lblTax2Rate.Visible = true;
            }

            // SÉCURISÉ : Utilise SqlParameter pour item_code et tax1Rate
            // Convertir tax1Rate en decimal pour SQL
            decimal tax1Rate = 0;
            decimal.TryParse(lblTax1Rate.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out tax1Rate);

            string strSQL = "SELECT item_code, item_name, selling_price, 1.00 AS qty, (selling_price * 1.00) * 1.00 as 'amount', " +
                    " (((selling_price * 1.00) * discount) / 100.00) as 'discount_amount', " +
                    " CASE " +
                    " WHEN tax_apply = 1 THEN (((selling_price * 1.00) - (((selling_price * 1.00) * discount) / 100.00)) * @tax1Rate) / 100.00 " +
                    " ELSE 0.00 " +
                    " END 'tax1_amount', " +
                    " CASE " +
                    " WHEN tax_apply = 1 THEN ((selling_price * 1.00) - (((selling_price * 1.00) * discount) / 100.00)) " +
                    " ELSE 0.00 " +
                    " END 'tax2_base', " +
                    " discount, tax_apply, show_kitchen, stock_item, stock_quantity, print_kot " +
                    " FROM tbl_Item WHERE item_code = @itemCode and active = 1";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@itemCode", System.Data.SqlDbType.NVarChar, 50) { Value = btnClicked.Tag.ToString() },
                new System.Data.SqlClient.SqlParameter("@tax1Rate", System.Data.SqlDbType.Decimal) { Value = tax1Rate }
            };

            DataTable dt = SecureDataAccess.GetDataTable(strSQL, parameters);

            string strItemCode = dt.Rows[0]["item_code"].ToString();
            string strItemName = dt.Rows[0]["item_name"].ToString();
            double dblSellingPrice = Convert.ToDouble(dt.Rows[0]["selling_price"].ToString());
            double dblQty = Convert.ToDouble(dt.Rows[0]["qty"].ToString());
            double dblAmount = Convert.ToDouble(dt.Rows[0]["amount"].ToString()) * dblQty;

            double dblDiscRate = Convert.ToDouble(dt.Rows[0]["discount"].ToString());
            double dblDiscAmount = Convert.ToDouble(dt.Rows[0]["discount_amount"].ToString());

            bool isTaxApply = Convert.ToBoolean(dt.Rows[0]["tax_apply"]);
            double dblTax1Amount = Convert.ToDouble(dt.Rows[0]["tax1_amount"].ToString());

            double Tax2Amount = 0;

            if (TaxValue.TaxType == "2LevelofTax")
            {
                if (TaxValue.CalMethod == 1)
                {
                    Tax2Amount = ((Convert.ToDouble(dt.Rows[0]["tax2_base"].ToString())) * Convert.ToDouble(lblTax2Rate.Text)) / 100;
                }
                else if (TaxValue.CalMethod == 2)
                {
                    Tax2Amount = ((Convert.ToDouble(dt.Rows[0]["tax2_base"].ToString()) + dblTax1Amount) * Convert.ToDouble(lblTax2Rate.Text)) / 100;
                }
            }

            bool isKitchenDisplay = Convert.ToBoolean(dt.Rows[0]["show_kitchen"]);
            bool isStockItem = Convert.ToBoolean(dt.Rows[0]["stock_item"]);
            double dblStockQty = Convert.ToDouble(dt.Rows[0]["stock_quantity"].ToString());
            bool isPrintInKot = Convert.ToBoolean(dt.Rows[0]["print_kot"]);

            int n = Finditem(strItemName);
            if (n == -1)  //If new item
            {
                if (isStockItem && dblStockQty == 0)
                {
                    Messages.InformationMessage("No stock available");
                }
                else
                {
                    dgvItemList.Rows.Add(strItemCode, strItemName, dblSellingPrice, dblQty, dblAmount, dblDiscRate, dblDiscAmount, isTaxApply, dblTax1Amount, Tax2Amount, isKitchenDisplay, isStockItem, dblStockQty, 0, 0, isPrintInKot,1);
                    btnModifier.Enabled = true;
                    Console.Beep();
                }
            }
            else  // if same item Quantity increase by 1 
            {                   
                if (isStockItem && Convert.ToDouble(dgvItemList.Rows[n].Cells["clmQty"].Value) >= dblStockQty)
                {
                    Messages.InformationMessage("Insufficient quantity. Order quantity is greater than stock quantity");
                }
                else
                {
                    double dblQtyInc = Convert.ToDouble(dgvItemList.Rows[n].Cells["clmQty"].Value);
                    dgvItemList.Rows[n].Cells["clmQty"].Value = (dblQtyInc + 1);  //dblQty Increase

                    double dblKotQty = Convert.ToDouble(dgvItemList.Rows[n].Cells["clmKotQty"].Value) + 1;
                    dgvItemList.Rows[n].Cells["clmKotQty"].Value = dblKotQty.ToString();

                    dgvItemList.Rows[n].Cells["clmAmount"].Value = Currency.Format(dblSellingPrice * (dblQtyInc + 1));   // Total price           

                    double dblQuantity = Convert.ToDouble(dgvItemList.Rows[n].Cells["clmQty"].Value);
                    double dblDiscountRate = Convert.ToDouble(dgvItemList.Rows[n].Cells["clmDiscountRate"].Value);

                    if (dblDiscRate != 0)  // if discount has
                    {
                        double DisamtInc = (((dblSellingPrice * dblQuantity) * dblDiscRate) / 100.00);      // Total Discount amount of this item
                        dgvItemList.Rows[n].Cells["clmDiscountAmount"].Value = DisamtInc;
                    }

                    if (isTaxApply != false) // If apply  tax 
                    {
                        double dblTaxOneAmount = ((((dblSellingPrice * dblQuantity) - (((dblSellingPrice * dblQuantity) * dblDiscRate) / 100.00)) * double.Parse(lblTax1Rate.Text)) / 100.00);
                        dgvItemList.Rows[n].Cells["clmTax1Amount"].Value = dblTaxOneAmount;

                        if (TaxValue.TaxType == "2LevelofTax") // Two Tax Enabled
                        {
                            if (TaxValue.CalMethod == 1)
                            {
                                double dblTaxTwoAmount1 = ((((dblSellingPrice * dblQuantity) - (((dblSellingPrice * dblQuantity) * dblDiscRate) / 100.00)) * double.Parse(lblTax2Rate.Text)) / 100.00);
                                dgvItemList.Rows[n].Cells["clmTax2Amount"].Value = dblTaxTwoAmount1;
                            }
                            else if (TaxValue.CalMethod == 2)
                            {
                                double dblTaxTwoAmount2 = (((((dblSellingPrice * dblQty) - (((dblSellingPrice * dblQty) * dblDiscRate) / 100.00)) + dblTaxOneAmount) * double.Parse(lblTax2Rate.Text)) / 100.00);
                                dgvItemList.Rows[n].Cells["clmTax2Amount"].Value = dblTaxTwoAmount2;
                            }
                        }
                    }
                }
            }
            DiscountCalculation();
            TaxCalculation();
            txtDiscountRate.Text = "0";
            btnNew.Enabled = true;
            btnQuickSale.Enabled = true;
            btnPayment.Enabled = true;
            btnDeleteRow.Enabled = true;
            btnChangePrice.Enabled = true;
        }

        public void RecallInvoice(string strHId)
        {
            Clear();
            //Fill Header
            // SÉCURISÉ : Utilise SqlParameter pour header id
            string strSQLHeader = "SELECT tbl_TempHeader.id, tbl_TempHeader.order_type, tbl_TempHeader.invoice_date, tbl_TempHeader.invoice_time," +
                                "tbl_TempHeader.table_id, tbl_Tables.table_name,tbl_TempHeader.no_of_guests, tbl_TempHeader.waiter_id,"+
                                "tbl_User.name AS waiter_name, tbl_TempHeader.customer_id, ISNULL(tbl_Customer.name,'Guest') AS customer,"+
                                "tbl_TempHeader.payment_type, tbl_TempHeader.payment_amount, tbl_TempHeader.paid_amount,"+
                                "tbl_TempHeader.change_amount, tbl_TempHeader.due_amount,tbl_TempHeader.discount_rate,"+
                                "tbl_TempHeader.discount_amount, tbl_TempHeader.tax1_name, tbl_TempHeader.tax1_rate,"+
                                "tbl_TempHeader.tax1_amount,tbl_TempHeader.tax2_name, tbl_TempHeader.tax2_rate,"+
                                "tbl_TempHeader.tax2_amount, tbl_TempHeader.sc_rate, tbl_TempHeader.sc_charge, tbl_TempHeader.note,"+
                                "tbl_TempHeader.user_name, tbl_TempHeader.log_date FROM tbl_TempHeader LEFT JOIN "+
                                "tbl_Tables ON tbl_TempHeader.table_id = tbl_Tables.id LEFT JOIN " +
                                "tbl_User ON tbl_TempHeader.waiter_id = tbl_User.id LEFT JOIN " +
                                "tbl_Customer ON tbl_TempHeader.customer_id = tbl_Customer.id WHERE tbl_TempHeader.id = @headerId";

            System.Data.SqlClient.SqlParameter[] parametersHeader = {
                new System.Data.SqlClient.SqlParameter("@headerId", System.Data.SqlDbType.Int) { Value = int.Parse(strHId) }
            };

            DataTable dtHeader = SecureDataAccess.GetDataTable(strSQLHeader, parametersHeader);
            holdId= int.Parse(dtHeader.Rows[0]["id"].ToString());
            string strOtId = dtHeader.Rows[0]["order_type"].ToString();

            if (strOtId == "0")//If Nothing Selected get the default Order Type
            {
                strOtId = Settings.DefaultOrderType.ToString();
            }

            if (strOtId == "1")
            {
                btnSelectedOT.Text = "Order Type" + Environment.NewLine + "Dine In";
            }
            else if (strOtId == "2")
            {
                btnSelectedOT.Text = "Order Type" + Environment.NewLine + "Take Away";
            }
            else if (strOtId == "3")
            {
                btnSelectedOT.Text = "Order Type" + Environment.NewLine + "Delivery Order";
            }
            else if (strOtId == "4")
            {
                btnSelectedOT.Text = "Order Type" + Environment.NewLine + "Pickup Order";
            }
            lblOrderTypeId.Text = strOtId.ToString();

            lblTableId.Text = dtHeader.Rows[0]["table_id"].ToString();
            lblNoOfGuests.Text = dtHeader.Rows[0]["no_of_guests"].ToString();
            btnSelectedTable.Text = "Table" + Environment.NewLine + dtHeader.Rows[0]["table_name"].ToString() + " (" + lblNoOfGuests.Text + ")";

            lblWaiterId.Text = dtHeader.Rows[0]["waiter_id"].ToString();
            btnWaiter.Text = "Waiter" + Environment.NewLine + dtHeader.Rows[0]["waiter_name"].ToString();

            lblCustomerId.Text = dtHeader.Rows[0]["customer_id"].ToString();
            btnSelectedCustomer.Text = "Customer" + Environment.NewLine + dtHeader.Rows[0]["customer"].ToString();

            // SÉCURISÉ : Utilise SqlParameter pour header_id et tax1Rate
            // Convertir tax1Rate en decimal pour SQL
            decimal tax1RateRecall = 0;
            decimal.TryParse(lblTax1Rate.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out tax1RateRecall);

            string strSQL = "SELECT item_code, item_name, selling_price, qty, (selling_price * qty) AS 'amount', " +
                            " (((selling_price * qty) * discount) / 100.00) as 'discount_amount', " +
                            " CASE " +
                            " WHEN tax_apply = 1 THEN (((selling_price * qty) - (((selling_price * qty) * discount) / 100.00)) * @tax1Rate) / 100.00 " +
                            " ELSE 0.00 " +
                            " END 'tax1_amount', " +
                            " CASE " +
                            " WHEN tax_apply = 1 THEN ((selling_price * qty) - (((selling_price * qty) * discount) / 100.00)) " +
                            " ELSE 0.00 " +
                            " END 'tax2_base', " +
                            " discount, discount_amount, tax_apply, show_kitchen, print_kot, kot_qty " +
                            " FROM tbl_TempDetail WHERE header_id = @headerId";

            System.Data.SqlClient.SqlParameter[] parametersDetail = {
                new System.Data.SqlClient.SqlParameter("@headerId", System.Data.SqlDbType.Int) { Value = holdId },
                new System.Data.SqlClient.SqlParameter("@tax1Rate", System.Data.SqlDbType.Decimal) { Value = tax1RateRecall }
            };

            DataTable dt = SecureDataAccess.GetDataTable(strSQL, parametersDetail);
            foreach (DataRow dr in dt.Rows)
            {
                string strItemCode = dr["item_code"].ToString(); 
                string strItemName = dr["item_name"].ToString();
                double dblSellingPrice = Convert.ToDouble(dr["selling_price"].ToString());
                double dblQty = Convert.ToDouble(dr["qty"].ToString());
                double dblAmount = Convert.ToDouble(dr["amount"].ToString());

                double dblDiscRate = Convert.ToDouble(dr["discount"].ToString());
                double dblDiscAmount = Convert.ToDouble(dr["discount_amount"].ToString());

                bool isTaxApply = Convert.ToBoolean(dr["tax_apply"]);
                double dblTax1Amount = Convert.ToDouble(dr["tax1_amount"].ToString());

                double Tax2Amount = 0;

                if (TaxValue.TaxType == "2LevelofTax")
                {
                    if (TaxValue.CalMethod == 1)
                    {
                        Tax2Amount = ((Convert.ToDouble(dr["tax2_base"].ToString())) * Convert.ToDouble(lblTax2Rate.Text)) / 100;
                    }
                    else if (TaxValue.CalMethod == 2)
                    {
                        Tax2Amount = ((Convert.ToDouble(dr["tax2_base"].ToString()) + dblTax1Amount) * Convert.ToDouble(lblTax2Rate.Text)) / 100;
                    }
                }

                bool isKitchenDisplay = Convert.ToBoolean(dr["show_kitchen"]);
                bool isPrintKot = Convert.ToBoolean(dr["print_kot"]);
                double dblKotQty = Convert.ToDouble(dr["kot_qty"].ToString());

                dgvItemList.Rows.Add(strItemCode, strItemName, dblSellingPrice, dblQty, dblAmount, dblDiscRate, dblDiscAmount, isTaxApply, dblTax1Amount, Tax2Amount, isKitchenDisplay, false, 0, 0, 0, isPrintKot,dblKotQty);
                btnModifier.Enabled = true;
            }


            // Default tax rate 
            if (TaxValue.TaxType == "NoTax")
            {
                lblTax1Name.Text = String.Empty;
                lblTax1Rate.Text = "0";
                lblTax2Name.Text = String.Empty;
                lblTax2Rate.Text = "0";

                lblTotalTax1.Text = "0";
                lblTotalTax2.Text = "0";

                lblTotalTax1.Visible = false;
                lblTotalTax2.Visible = false;

                lblTax1Name.Visible = false;
                lblTax1Rate.Visible = false;
                lblTax2Name.Visible = false;
                lblTax2Rate.Visible = false;
            }
            else if (TaxValue.TaxType == "1LevelofTax")
            {
                lblTax1Name.Text = TaxValue.Tax1Name + " (%):";
                lblTax1Rate.Text = TaxValue.Tax1Rate;
                lblTax2Name.Text = String.Empty;
                lblTax2Rate.Text = "0";
                lblTotalTax2.Text = "0";
                lblTotalTax1.Visible = true;
                lblTotalTax2.Visible = false;
                lblTax1Name.Visible = true;
                lblTax1Rate.Visible = true;
                lblTax2Name.Visible = false;
                lblTax2Rate.Visible = false;
            }

            else if (TaxValue.TaxType == "2LevelofTax")
            {
                lblTax1Name.Text = TaxValue.Tax1Name + " (%):";
                lblTax1Rate.Text = TaxValue.Tax1Rate;
                lblTax2Name.Text = TaxValue.Tax2Name + " (%):";
                lblTax2Rate.Text = TaxValue.Tax2Rate;

                lblTotalTax1.Visible = true;
                lblTotalTax2.Visible = true;

                lblTax1Name.Visible = true;
                lblTax1Rate.Visible = true;
                lblTax2Name.Visible = true;
                lblTax2Rate.Visible = true;
            }

            DiscountCalculation();
            TaxCalculation();
            btnQuickSale.Enabled = true;
            btnPayment.Enabled = true;
            btnDeleteRow.Enabled = true;
            btnChangePrice.Enabled = true;
        }

        public void DiscountCalculation()
        {
            double totalsum = 0.00;
            for (int i = 0; i < dgvItemList.Rows.Count; ++i)
            {
                totalsum += (double)Currency.Parse(dgvItemList.Rows[i].Cells["clmAmount"].Value.ToString());
            }
            lblTotal.Text = Currency.Format(totalsum);
            tssTotalItems.Text ="Total Item(s) : " + dgvItemList.RowCount.ToString();
            
            //Discount amount sum
            double total = Convert.ToDouble(totalsum.ToString());
            double DisCount = 0.00;
            for (int i = 0; i < dgvItemList.Rows.Count; ++i)
            {
                DisCount += Convert.ToDouble(dgvItemList.Rows[i].Cells["clmDiscountAmount"].Value);
            }           

            DisCount = Math.Round(DisCount, 2);
            double sum = total - DisCount;
            sum = Math.Round(sum, 2);
            lblSubtotal.Text = Currency.Format(sum);
            //Service Charge
            double dblScRate = Settings.ServiceChargeRate;
            double dblServiceCharge = 0;
            if (Settings.EnableServiceCharge)
            {
                dblServiceCharge = (sum / 100) * dblScRate;
            }

            // Conversion sécurisée des taxes depuis les labels formatés
            double tax1Value = 0;
            double tax2Value = 0;
            double.TryParse(lblTotalTax1.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out tax1Value);
            double.TryParse(lblTotalTax2.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out tax2Value);

            double payable = sum + tax1Value + tax2Value + dblServiceCharge;
            payable = Math.Round(payable,2);
            lblTotalPayable.Text = Currency.Format(payable);
            lblTotalDiscount.Text = Currency.Format(DisCount);
            lblOverallDiscount.Text = Currency.Format(DisCount);
        }

        public void TaxCalculation()
        {
            double Subtotal = 0;
            double.TryParse(lblSubtotal.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out Subtotal);            

            //Tax 1 amount
            double Tax1 = 0.00;
            for (int i = 0; i < dgvItemList.Rows.Count; ++i)
            {
                Tax1 += Convert.ToDouble(dgvItemList.Rows[i].Cells["clmTax1Amount"].Value);
            }

            Tax1 = Math.Round(Tax1, 2);
            lblTotalTax1.Text = Currency.Format(Tax1);

            //Tax 2 amount
            double Tax2 = 0.00;
            for (int i = 0; i < dgvItemList.Rows.Count; ++i)
            {
                Tax2 += Convert.ToDouble(dgvItemList.Rows[i].Cells["clmTax2Amount"].Value);
            }

            Tax2 = Math.Round(Tax2, 2);
            lblTotalTax2.Text = Currency.Format(Tax2);

            double dblScRate=Settings.ServiceChargeRate;
            double dblServiceCharge=0;
            if (Settings.EnableServiceCharge)
            {
                dblServiceCharge = (Subtotal / 100) * dblScRate;
            }
            double dblPayable = Subtotal + Tax1 + Tax2 + dblServiceCharge;
            dblPayable = Math.Round(dblPayable, 2);
            lblScAmount.Text = Currency.Format(dblServiceCharge);
            lblTotalPayable.Text = Currency.Format(dblPayable);
        }
        
        
        //Input Item Quantity
        private void dgvItemList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Increase Item Quantity with Edited cell
                if (e.ColumnIndex == dgvItemList.Columns["Qty"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in dgvItemList.SelectedRows)
                    {
                        // Total Price
                       // double totalPrice = Convert.ToDouble(row.Cells[2].Value) * Convert.ToDouble(row.Cells[1].Value);
                       // row.Cells[3].Value = totalPrice;
                        if (Convert.ToDouble(row.Cells[2].Value) > CheckStockQty(dgvItemList.Rows[e.RowIndex].Cells[0].Value.ToString()))
                        {
                            Messages.InformationMessage("Insufficient quantity. Order quantity is greater than stock quantity");
                            row.Cells[2].Value = CheckStockQty(dgvItemList.Rows[e.RowIndex].Cells[0].Value.ToString());

                            double qty = Convert.ToDouble(row.Cells[2].Value);
                            double Rprice = Convert.ToDouble(row.Cells[1].Value);
                            double discount_rate = Convert.ToDouble(row.Cells[7].Value);
                            double Taxrate = Convert.ToDouble(TaxValue.Tax1Rate);

                            //// show total price   Qty  * Rprice
                            double totalPrice = qty * Rprice;
                            row.Cells[3].Value = Currency.Format(totalPrice);

                            if (Convert.ToDouble(row.Cells[7].Value) != 0)  // IF discount is not zero then apply discount
                            {
                                double Disamt = (((Rprice * qty) * discount_rate) / 100.00);      // Total Discount amount of this item
                                row.Cells[5].Value = Disamt;
                            }

                            if (Convert.ToDouble(row.Cells[8].Value) != 0)  // IF tax is not zero then apply tax
                            {
                                double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * discount_rate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                                row.Cells[6].Value = Taxamt;
                            }
                        }
                        else
                        {
                            double qty = Convert.ToDouble(row.Cells[2].Value);
                            double Rprice = Convert.ToDouble(row.Cells[1].Value);
                            double discount_rate = Convert.ToDouble(row.Cells[7].Value);
                            double Taxrate = Convert.ToDouble(TaxValue.Tax1Rate);

                            //// show total price   Qty  * Rprice
                            double totalPrice = qty * Rprice;
                            row.Cells[3].Value = Currency.Format(totalPrice);

                            if (Convert.ToDouble(row.Cells[7].Value) != 0)  // IF discount is not zero then apply discount
                            {
                                double Disamt = (((Rprice * qty) * discount_rate) / 100.00);      // Total Discount amount of this item
                                row.Cells[5].Value = Disamt;
                            }

                            if (Convert.ToDouble(row.Cells[8].Value) != 0)  // IF tax is not zero then apply tax
                            {
                                double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * discount_rate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                                row.Cells[6].Value = Taxamt;
                            }
                        }

                        DiscountCalculation();
                        TaxCalculation();
                        txtDiscountRate.Text = "0";
                   
                    }
                }
            }
            catch (Exception ex)
            {
                objerror.Write(ex.Message.ToString(), this.Name + " - dgvItemList_CellEndEdit", Global.ERROR_WRITE_PATH);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                objerror.Write(ex.Message.ToString(), this.Name + " - btnNew_Click", Global.ERROR_WRITE_PATH);
            }
        }
        
        // Auto Invoice.No Shows 
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                NextInvoiceNumber();
                NextKotNumber();
            }
            catch (Exception ex)
            {
                objerror.Write(ex.Message.ToString(), this.Name + " - timer1_Tick", Global.ERROR_WRITE_PATH);
            }
        }

        private void btnDecreaseDiscount_Click(object sender, EventArgs e)
        {
            if (Currency.Parse(lblTotalPayable.Text)==0 || lblTotalPayable.Text == "")
            {
                 Messages.InformationMessage("Please select item(s)");
            }
            else
            {
                double Discountvalue = SafeParseLabel(txtDiscountRate.Text) - 1;
                txtDiscountRate.Text = Discountvalue.ToString();
                double subtotal = SafeParseLabel(lblTotal.Text) - SafeParseLabel(lblTotalDiscount.Text); // total - item discount  100 - 5 = 95
                double totaldiscount = (subtotal * Discountvalue) / 100;  //Counter discount  // 95 * 5 /100 = 4.75
                double disPlusOverallDiscount = totaldiscount + SafeParseLabel(lblTotalDiscount.Text); // 4.75 + 5 = 9.75
                disPlusOverallDiscount = Math.Round(disPlusOverallDiscount, 2);
                lblOverallDiscount.Text = disPlusOverallDiscount.ToString();  // Overall discount 9.75

                double subtotalafteroveralldiscount = subtotal - totaldiscount; // 95 - 4.75 = 90.25
                subtotalafteroveralldiscount = Math.Round(subtotalafteroveralldiscount, 2);
                lblSubtotal.Text = subtotalafteroveralldiscount.ToString();

                double payable = subtotalafteroveralldiscount + SafeParseLabel(lblTotalTax1.Text);
                payable = Math.Round(payable, 2);
                lblTotalPayable.Text = Currency.Format(payable);
            }
        }

        #region Save Invoice 
       
        public void SaveInvoice(decimal decPayAmount, decimal decPaidAmount, decimal decChangeAmount, decimal decDueAmount, string strInvoiceDate, string strInvoiceTime, string strPaymentType, string strNote,bool bReset=true)
        {
            string strTax1Name = TaxValue.Tax1Name;
            string strTax2Name = TaxValue.Tax2Name;

            string strOtId = lblOrderTypeId.Text;
            //string strOrderType = string.Empty;

            if (strOtId == "0")//If Nothing Selected get the default Order Type
            {
                strOtId = Settings.DefaultOrderType.ToString();
            }

            //if (strOtId == "1")
            //{
            //    strOrderType = "Dine In";
            //}
            //else if (strOtId == "2")
            //{
            //    strOrderType = "Take Away";
            //}
            //else if (strOtId == "3")
            //{
            //    strOrderType = "Delivery Order";
            //}
            //else if (strOtId == "4")
            //{
            //    strOrderType = "Pickup Order";
            //}
            // ===============================================================================
            // OPÉRATION CRITIQUE AVEC TRANSACTION SQL
            // Si une étape échoue, TOUT est rollback automatiquement
            // ===============================================================================
            try
            {
                int HeaderId = 0;

                SecureDataAccess.ExecuteTransaction((conn, transaction) =>
                {
                    // ÉTAPE 1 : INSERT Invoice Header
                    string strSQLHeader = @"INSERT INTO tbl_InvoiceHeader
                        (invoice_no, order_type, invoice_date, invoice_time, table_id, no_of_guests, waiter_id, customer_id,
                         payment_type, payment_amount, paid_amount, change_amount, due_amount, discount_rate, discount_amount,
                         tax1_name, tax1_rate, tax1_amount, tax2_name, tax2_rate, tax2_amount, sc_rate, sc_charge, note, user_name, log_date)
                        VALUES
                        (@invoiceNo, @orderType, @invoiceDate, @invoiceTime, @tableId, @noOfGuests, @waiterId, @customerId,
                         @paymentType, @paymentAmount, @paidAmount, @changeAmount, @dueAmount, @discountRate, @discountAmount,
                         @tax1Name, @tax1Rate, @tax1Amount, @tax2Name, @tax2Rate, @tax2Amount, @scRate, @scCharge, @note, @userName, @logDate);
                        SELECT CAST(SCOPE_IDENTITY() AS INT)";

                    using (System.Data.SqlClient.SqlCommand cmdHeader = new System.Data.SqlClient.SqlCommand(strSQLHeader, conn, transaction))
                    {
                        cmdHeader.Parameters.AddWithValue("@invoiceNo", lblInvoiceNo.Text);
                        cmdHeader.Parameters.AddWithValue("@orderType", strOtId);
                        cmdHeader.Parameters.AddWithValue("@invoiceDate", strInvoiceDate);
                        cmdHeader.Parameters.AddWithValue("@invoiceTime", strInvoiceTime);
                        cmdHeader.Parameters.AddWithValue("@tableId", int.Parse(lblTableId.Text));
                        cmdHeader.Parameters.AddWithValue("@noOfGuests", int.Parse(lblNoOfGuests.Text));
                        cmdHeader.Parameters.AddWithValue("@waiterId", int.Parse(lblWaiterId.Text));
                        cmdHeader.Parameters.AddWithValue("@customerId", int.Parse(lblCustomerId.Text));
                        cmdHeader.Parameters.AddWithValue("@paymentType", strPaymentType);
                        cmdHeader.Parameters.AddWithValue("@paymentAmount", decPayAmount);
                        cmdHeader.Parameters.AddWithValue("@paidAmount", decPaidAmount);
                        cmdHeader.Parameters.AddWithValue("@changeAmount", decChangeAmount);
                        cmdHeader.Parameters.AddWithValue("@dueAmount", decDueAmount);

                        // Sécuriser conversions decimal (labels peuvent être vides ou contenir texte)
                        decimal discountRate = 0;
                        decimal.TryParse(txtDiscountRate.Text, out discountRate);
                        cmdHeader.Parameters.AddWithValue("@discountRate", discountRate);

                        decimal discountAmount = 0;
                        decimal.TryParse(lblOverallDiscount.Text, out discountAmount);
                        cmdHeader.Parameters.AddWithValue("@discountAmount", discountAmount);

                        cmdHeader.Parameters.AddWithValue("@tax1Name", strTax1Name);

                        decimal tax1Rate = 0;
                        decimal.TryParse(lblTax1Rate.Text, out tax1Rate);
                        cmdHeader.Parameters.AddWithValue("@tax1Rate", tax1Rate);

                        decimal tax1Amount = 0;
                        decimal.TryParse(lblTotalTax1.Text, out tax1Amount);
                        cmdHeader.Parameters.AddWithValue("@tax1Amount", tax1Amount);

                        cmdHeader.Parameters.AddWithValue("@tax2Name", strTax2Name);

                        decimal tax2Rate = 0;
                        decimal.TryParse(lblTax2Rate.Text, out tax2Rate);
                        cmdHeader.Parameters.AddWithValue("@tax2Rate", tax2Rate);

                        decimal tax2Amount = 0;
                        decimal.TryParse(lblTotalTax2.Text, out tax2Amount);
                        cmdHeader.Parameters.AddWithValue("@tax2Amount", tax2Amount);

                        decimal scRate = 0;
                        decimal.TryParse(lblScRate.Text, out scRate);
                        cmdHeader.Parameters.AddWithValue("@scRate", scRate);

                        decimal scCharge = 0;
                        decimal.TryParse(lblScAmount.Text, out scCharge);
                        cmdHeader.Parameters.AddWithValue("@scCharge", scCharge);
                        cmdHeader.Parameters.AddWithValue("@note", strNote);
                        cmdHeader.Parameters.AddWithValue("@userName", UserInfo.UserName);
                        cmdHeader.Parameters.AddWithValue("@logDate", DateTime.Now);

                        HeaderId = (int)cmdHeader.ExecuteScalar();
                    }

                    // ÉTAPE 2 : INSERT Invoice Details + UPDATE Stock pour chaque ligne
                    int rows = dgvItemList.Rows.Count;
                    for (int i = 0; i < rows; i++)
                    {
                        string strItemCode = dgvItemList.Rows[i].Cells["clmItemCode"].Value.ToString();
                        string strItemName = dgvItemList.Rows[i].Cells["clmItemName"].Value.ToString();
                        double dblQty = Convert.ToDouble(dgvItemList.Rows[i].Cells["clmQty"].Value.ToString());
                        double dblPrice = (double)Currency.Parse(dgvItemList.Rows[i].Cells["clmPrice"].Value.ToString());
                        double dblTotal = (double)Currency.Parse(dgvItemList.Rows[i].Cells["clmAmount"].Value.ToString());
                        double dblDiscount = Convert.ToDouble(dgvItemList.Rows[i].Cells["clmDiscountRate"].Value.ToString());
                        double dblDiscountAmount = Convert.ToDouble(dgvItemList.Rows[i].Cells["clmDiscountAmount"].Value.ToString());
                        bool isTaxApply = Convert.ToBoolean(dgvItemList.Rows[i].Cells["clmTaxApply"].Value.ToString());
                        bool isKitchenDisplay = Convert.ToBoolean(dgvItemList.Rows[i].Cells["clmKitchenDisplay"].Value.ToString());

                        double dblNetAmount = dblTotal - dblDiscountAmount;

                        // INSERT Invoice Detail
                        string strSQLDetail = @"INSERT INTO tbl_InvoiceDetail
                            (header_id, invoice_date, invoice_time, item_code, item_name, qty, selling_price,
                             total, profit, discount, discount_amount, net_amount, tax_apply, show_kitchen, log_date)
                            VALUES
                            (@headerId, @invoiceDate, @invoiceTime, @itemCode, @itemName, @qty, @price,
                             @total, @profit, @discount, @discountAmount, @netAmount, @taxApply, @kitchenDisplay, @logDate)";

                        using (System.Data.SqlClient.SqlCommand cmdDetail = new System.Data.SqlClient.SqlCommand(strSQLDetail, conn, transaction))
                        {
                            cmdDetail.Parameters.AddWithValue("@headerId", HeaderId);
                            cmdDetail.Parameters.AddWithValue("@invoiceDate", strInvoiceDate);
                            cmdDetail.Parameters.AddWithValue("@invoiceTime", strInvoiceTime);
                            cmdDetail.Parameters.AddWithValue("@itemCode", strItemCode);
                            cmdDetail.Parameters.AddWithValue("@itemName", strItemName);
                            cmdDetail.Parameters.AddWithValue("@qty", dblQty);
                            cmdDetail.Parameters.AddWithValue("@price", dblPrice);
                            cmdDetail.Parameters.AddWithValue("@total", dblTotal);
                            cmdDetail.Parameters.AddWithValue("@profit", 0);
                            cmdDetail.Parameters.AddWithValue("@discount", dblDiscount);
                            cmdDetail.Parameters.AddWithValue("@discountAmount", dblDiscountAmount);
                            cmdDetail.Parameters.AddWithValue("@netAmount", dblNetAmount);
                            cmdDetail.Parameters.AddWithValue("@taxApply", isTaxApply);
                            cmdDetail.Parameters.AddWithValue("@kitchenDisplay", isKitchenDisplay);
                            cmdDetail.Parameters.AddWithValue("@logDate", DateTime.Now);

                            cmdDetail.ExecuteNonQuery();
                        }

                        // UPDATE Stock Quantity
                        if (lblInvoiceNo.Text != string.Empty)
                        {
                            // SELECT current stock
                            string strSQLSelect = "SELECT stock_quantity FROM tbl_Item WHERE item_code = @itemCode";
                            using (System.Data.SqlClient.SqlCommand cmdSelect = new System.Data.SqlClient.SqlCommand(strSQLSelect, conn, transaction))
                            {
                                cmdSelect.Parameters.AddWithValue("@itemCode", strItemCode);
                                object stockResult = cmdSelect.ExecuteScalar();

                                if (stockResult != null)
                                {
                                    double dblCurrentStock = Convert.ToDouble(stockResult);
                                    double dblNewStock = dblCurrentStock - dblQty;

                                    // UPDATE with new stock
                                    string strSQLStock = "UPDATE tbl_Item SET stock_quantity = @newStock WHERE item_code = @itemCode";
                                    using (System.Data.SqlClient.SqlCommand cmdStock = new System.Data.SqlClient.SqlCommand(strSQLStock, conn, transaction))
                                    {
                                        cmdStock.Parameters.AddWithValue("@newStock", dblNewStock);
                                        cmdStock.Parameters.AddWithValue("@itemCode", strItemCode);
                                        cmdStock.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }

                    // ÉTAPE 3 : DELETE Temporary Hold data (if exists)
                    if (holdId > 0)
                    {
                        string strSQLDelHeader = "DELETE FROM tbl_TempHeader WHERE id = @holdId";
                        using (System.Data.SqlClient.SqlCommand cmdDelHeader = new System.Data.SqlClient.SqlCommand(strSQLDelHeader, conn, transaction))
                        {
                            cmdDelHeader.Parameters.AddWithValue("@holdId", holdId);
                            cmdDelHeader.ExecuteNonQuery();
                        }

                        string strSQLDelDetail = "DELETE FROM tbl_TempDetail WHERE header_id = @holdId";
                        using (System.Data.SqlClient.SqlCommand cmdDelDetail = new System.Data.SqlClient.SqlCommand(strSQLDelDetail, conn, transaction))
                        {
                            cmdDelDetail.Parameters.AddWithValue("@holdId", holdId);
                            cmdDelDetail.ExecuteNonQuery();
                        }
                    }
                });

                // Transaction committed successfully
                if (bReset)
                {
                    Clear();
                }
            }
            catch (Exception ex)
            {
                // Transaction rollback automatique en cas d'erreur
                Messages.ExceptionMessage("Erreur lors de la création de la facture: " + ex.Message);
                objerror.Write(ex.Message, this.Name + " - SaveInvoice_Transaction", Global.ERROR_WRITE_PATH);
                throw; // Relancer l'exception pour que l'appelant sache qu'il y a eu une erreur
            }
        }

        #endregion

        #region Save KOT 

        public void SaveKot()
        {
            string strOtId = lblOrderTypeId.Text;

            if (strOtId == "0")//If Nothing Selected get the default Order Type
            {
                strOtId = Settings.DefaultOrderType.ToString();
            }

            // OPÉRATION KOT AVEC TRANSACTION SQL
            try
            {
                int HeaderId = 0;

                SecureDataAccess.ExecuteTransaction((conn, transaction) =>
                {
                    // INSERT KOT Header
                    string strSQLHeader = @"INSERT INTO tbl_KotHeader
                        (kot_no, order_type, kot_date, kot_time, table_id, no_of_guests, waiter_id, user_name, log_date)
                        VALUES
                        (@kotNo, @orderType, @kotDate, @kotTime, @tableId, @noOfGuests, @waiterId, @userName, @logDate);
                        SELECT CAST(SCOPE_IDENTITY() AS INT)";

                    using (System.Data.SqlClient.SqlCommand cmdHeader = new System.Data.SqlClient.SqlCommand(strSQLHeader, conn, transaction))
                    {
                        cmdHeader.Parameters.AddWithValue("@kotNo", lblKotNo.Text);
                        cmdHeader.Parameters.AddWithValue("@orderType", strOtId);
                        cmdHeader.Parameters.AddWithValue("@kotDate", DateTime.Now.ToString("dd/MM/yyyy"));
                        cmdHeader.Parameters.AddWithValue("@kotTime", DateTime.Now.ToString("hh:mm tt"));
                        cmdHeader.Parameters.AddWithValue("@tableId", lblTableId.Text);
                        cmdHeader.Parameters.AddWithValue("@noOfGuests", lblNoOfGuests.Text);
                        cmdHeader.Parameters.AddWithValue("@waiterId", lblWaiterId.Text);
                        cmdHeader.Parameters.AddWithValue("@userName", UserInfo.UserName);
                        cmdHeader.Parameters.AddWithValue("@logDate", DateTime.Now);

                        HeaderId = (int)cmdHeader.ExecuteScalar();
                    }

                    // INSERT KOT Details
                    int rows = dgvItemList.Rows.Count;
                    for (int i = 0; i < rows; i++)
                    {
                        string strItemCode = dgvItemList.Rows[i].Cells["clmItemCode"].Value.ToString();
                        string strItemName = dgvItemList.Rows[i].Cells["clmItemName"].Value.ToString();
                        double dblQty = Convert.ToDouble(dgvItemList.Rows[i].Cells["clmQty"].Value.ToString());
                        bool isKitchenDisplay = Convert.ToBoolean(dgvItemList.Rows[i].Cells["clmKitchenDisplay"].Value.ToString());
                        bool isPrintKot = Convert.ToBoolean(dgvItemList.Rows[i].Cells["clmPrintInKot"].Value.ToString());

                        dgvItemList.Rows[i].Cells["clmKotPrinted"].Value = true;

                        string strSQLDetail = @"INSERT INTO tbl_KotDetail
                            (header_id, item_code, item_name, qty, show_kitchen, print_kot, log_date)
                            VALUES
                            (@headerId, @itemCode, @itemName, @qty, @kitchenDisplay, @printKot, @logDate)";

                        using (System.Data.SqlClient.SqlCommand cmdDetail = new System.Data.SqlClient.SqlCommand(strSQLDetail, conn, transaction))
                        {
                            cmdDetail.Parameters.AddWithValue("@headerId", HeaderId);
                            cmdDetail.Parameters.AddWithValue("@itemCode", strItemCode);
                            cmdDetail.Parameters.AddWithValue("@itemName", strItemName);
                            cmdDetail.Parameters.AddWithValue("@qty", dblQty);
                            cmdDetail.Parameters.AddWithValue("@kitchenDisplay", isKitchenDisplay);
                            cmdDetail.Parameters.AddWithValue("@printKot", isPrintKot);
                            cmdDetail.Parameters.AddWithValue("@logDate", DateTime.Now);

                            cmdDetail.ExecuteNonQuery();
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage("Erreur lors de la création du KOT: " + ex.Message);
                objerror.Write(ex.Message, this.Name + " - SaveKot_Transaction", Global.ERROR_WRITE_PATH);
                throw;
            }
        }

        #endregion

        private void btnQuickSale_Click(object sender, EventArgs e)
        {
            if (Settings.PreviewBeforePrint)
            {
                if (Currency.Parse(lblTotalPayable.Text) == 0 || lblTotalPayable.Text == string.Empty)
                {
                    Messages.InformationMessage("Please enter item(s)");
                }
                else
                {
                    //Save Invoice
                    SaveInvoice(Convert.ToDecimal(lblTotalPayable.Text.ToString()), Convert.ToDecimal(lblTotalPayable.Text.ToString()), 0, 0, DateTime.Now.ToString("dd/MM/yyyy").ToString(), DateTime.Now.ToString("hh:mm tt"), "Cash", "Quick Sale", false);

                    timer1.Enabled = false;
                    //Open Print Invoice
                    frmPrintView frmPrintView = new frmPrintView(this);
                    frmPrintView.RefNo = lblInvoiceNo.Text;
                    frmPrintView.Report = "Invoice";
                    frmPrintView.ShowDialog();
                    timer1.Enabled = true;
                }
            }
            else
            {
                LocalReport report = new LocalReport();
                SaveInvoice(Currency.Parse(lblTotalPayable.Text), Currency.Parse(lblTotalPayable.Text), 0, 0, DateTime.Now.ToString("dd/MM/yyyy").ToString(), DateTime.Now.ToString("hh:mm tt"), "Cash", "Quick Sale",false);
                report.ReportEmbeddedResource = "cypos.Reports.rptReceipt.rdlc";

                report.EnableExternalImages = true;
                ReportParameter paramLogo = new ReportParameter();
                paramLogo.Name = "logo_path";
                paramLogo.Values.Add("file:///" + Application.StartupPath + @"\Images\" + Company.Logo);
                report.SetParameters(paramLogo);

                // SÉCURISÉ : Utilise SqlParameter pour invoice_no
                string strSQL = "SELECT tbl_InvoiceHeader.invoice_id,tbl_InvoiceHeader.order_type, tbl_InvoiceHeader.invoice_no, tbl_InvoiceHeader.invoice_date," +
                   "tbl_InvoiceHeader.invoice_time, tbl_InvoiceHeader.table_id,tbl_Tables.table_name," +
                   "tbl_TableLocation.location_name, tbl_InvoiceHeader.no_of_guests, tbl_InvoiceHeader.waiter_id," +
                   "tbl_User.name AS waiter_name,tbl_InvoiceHeader.customer_id," +
                   "CASE WHEN tbl_InvoiceHeader.customer_id = 0 THEN 'Cash' ELSE tbl_Customer.name END AS customer_name," +
                   "tbl_Customer.address AS customer_address, tbl_Customer.city AS customer_city," +
                   "tbl_Customer.phone AS customer_phone, tbl_Customer.email AS customer_email," +
                   "tbl_InvoiceHeader.payment_type, tbl_InvoiceHeader.payment_amount,tbl_InvoiceHeader.paid_amount, tbl_InvoiceHeader.change_amount," +
                   "tbl_InvoiceHeader.due_amount,tbl_InvoiceHeader.discount_rate, tbl_InvoiceHeader.discount_amount," +
                   "tbl_InvoiceHeader.tax1_name, tbl_InvoiceHeader.tax1_rate, tbl_InvoiceHeader.tax1_amount," +
                   "tbl_InvoiceHeader.tax2_name, tbl_InvoiceHeader.tax2_rate, tbl_InvoiceHeader.tax2_amount," +
                   "tbl_InvoiceHeader.sc_rate,tbl_InvoiceHeader.sc_charge,tbl_InvoiceHeader.note, tbl_InvoiceHeader.user_name," +
                   "tbl_InvoiceHeader.log_date,tbl_InvoiceDetail.detail_id, tbl_InvoiceDetail.item_code, tbl_InvoiceDetail.item_name," +
                   "tbl_InvoiceDetail.qty,tbl_InvoiceDetail.selling_price, tbl_InvoiceDetail.total," +
                   "tbl_InvoiceDetail.discount, tbl_InvoiceDetail.tax_apply, tbl_InvoiceDetail.show_kitchen," +
                   "tbl_Company.company_name, tbl_Company.company_address, tbl_Company.company_phone," +
                   "tbl_Company.email AS company_email, tbl_Company.web AS company_web, tbl_Company.tax_no," +
                   "tbl_Company.footer_message, tbl_Company.logo,tbl_Settings.ask_table, tbl_Settings.ask_guest_count," +
                   "tbl_Settings.ask_waiter, tbl_Settings.show_logo, tbl_Settings.enable_sc FROM tbl_InvoiceHeader LEFT JOIN " +
                   "tbl_InvoiceDetail ON tbl_InvoiceHeader.invoice_id = tbl_InvoiceDetail.header_id LEFT JOIN " +
                   "tbl_Tables ON tbl_InvoiceHeader.table_id = tbl_Tables.id LEFT JOIN " +
                   "tbl_TableLocation ON tbl_Tables.location_id = tbl_TableLocation.Id LEFT JOIN " +
                   "tbl_User ON tbl_InvoiceHeader.waiter_id = tbl_User.id LEFT JOIN " +
                   "tbl_Customer ON tbl_InvoiceHeader.customer_id = tbl_Customer.id " +
                   "CROSS JOIN tbl_Company " +
                   "CROSS JOIN tbl_Settings " +
                   "WHERE tbl_InvoiceHeader.invoice_no = @invoiceNo";

                System.Data.SqlClient.SqlParameter[] parametersInvoice = {
                    new System.Data.SqlClient.SqlParameter("@invoiceNo", System.Data.SqlDbType.NVarChar, 50) { Value = lblInvoiceNo.Text }
                };

                DataTable result = SecureDataAccess.GetDataTable(strSQL, parametersInvoice);

                ReportDataSource reportDSDetail = new ReportDataSource("dsReceipt", result);
                report.DataSources.Clear();
                report.DataSources.Add(reportDSDetail);
                report.Refresh();
                if (DirectPrint.Print(report, Settings.InvoicePrinter))
                {
                    Clear();
                }
                //if (Settings.ShowOtAfterBill)
                //{
                //    frmOrderType frmOrderType = new frmOrderType(this);
                //    frmOrderType.ShowDialog();
                //}
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            frmPayment frmPayment = new frmPayment(this);
            frmPayment.Payable = lblTotalPayable.Text;
            frmPayment.InvoiceNo = lblInvoiceNo.Text;
            frmPayment.ShowDialog();
            //if (Settings.ShowOtAfterBill)
            //{
            //    frmOrderType frmOrderType = new frmOrderType(this);
            //    frmOrderType.ShowDialog();
            //}
        }
 
        #region  Shortcut Keys
       
        ///ShortCut Keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Shift | Keys.C)) // Cash
            {
                btnQuickSale.PerformClick(); 
            }
            else if (keyData == (Keys.Control | Keys.Enter)) 
            {
                btnPayment.PerformClick();
            }
            else if (keyData == (Keys.Control | Keys.P)) // Ctrl+P   // From vs 8.6 
            {
                //btnCompleteSalesAndPrint.PerformClick();
            }
            else if (keyData == (Keys.Control | Keys.S)) // Ctrl+S  
            {
                //btnSaveOnly.PerformClick();
            }
            else if (keyData == (Keys.Shift | Keys.Delete)) // Shift + Del -> Suspen/clear all items
            {
                btnNew.PerformClick();
            }
            else if (keyData == (Keys.F4))  // Selected item delete
            {
                try
                {

                    foreach (DataGridViewRow row in dgvItemList.SelectedRows)
                    {
                        dgvItemList.Rows.RemoveAt(row.Index);
                    }
                    DiscountCalculation();
                    TaxCalculation();
                    txtDiscountRate.Text = "0";
                }
                catch
                {
                }
            }
            else if (keyData == (Keys.F6)) // Increase item Qty
            {
                try
                {
                    double Taxrate = Convert.ToDouble(TaxValue.Tax1Rate);

                    int n = dgvItemList.CurrentCell.RowIndex;

                    double Rprice = Convert.ToDouble(dgvItemList.Rows[n].Cells[1].Value);
                    double Taxapply = Convert.ToDouble(dgvItemList.Rows[n].Cells[8].Value);

                    int QtyInc = Convert.ToInt32(dgvItemList.Rows[n].Cells[2].Value);
                    dgvItemList.Rows[n].Cells[2].Value = (QtyInc + 1);  //Qty Increase
                    dgvItemList.Rows[n].Cells[3].Value = Currency.Format(Rprice * (QtyInc + 1));   // Total Amount
                    //  dgrvSalesItemList.Rows[n].Cells[4].Value = Itemid;                     



                    double qty = Convert.ToDouble(dgvItemList.Rows[n].Cells[2].Value);
                    double discount_rate = Convert.ToDouble(dgvItemList.Rows[n].Cells[7].Value);

                    if (discount_rate != 0)  // if discount has
                    {
                        double DisamtInc = (((Rprice * qty) * discount_rate) / 100.00);      // Total Discount amount of this item
                        dgvItemList.Rows[n].Cells[5].Value = DisamtInc;
                    }

                    if (Taxapply != 0)   // If apply  tax 
                    {
                        // Total Tax amount  of this item  (Rprice - disamount) * taxRate / 100
                        double TaxamtInc = ((((Rprice * qty) - (((Rprice * qty) * discount_rate) / 100.00)) * Taxrate) / 100.00);
                        dgvItemList.Rows[n].Cells[6].Value = TaxamtInc;
                    }
                    DiscountCalculation();
                    TaxCalculation();
                }
                catch
                {
                }
            }
            else if (keyData == (Keys.F7)) // Decrease item Qty
            {
                try
                {
                    int n = dgvItemList.CurrentCell.RowIndex;
                    if (Convert.ToDouble(dgvItemList.Rows[n].Cells[2].Value) > 1)
                    {
                        double Taxrate = Convert.ToDouble(TaxValue.Tax1Rate);

                        double Rprice = Convert.ToDouble(dgvItemList.Rows[n].Cells[1].Value);
                        double Taxapply = Convert.ToDouble(dgvItemList.Rows[n].Cells[8].Value);

                        int QtyInc = Convert.ToInt32(dgvItemList.Rows[n].Cells[2].Value);
                        dgvItemList.Rows[n].Cells[2].Value = (QtyInc - 1);  //Qty Increase
                        dgvItemList.Rows[n].Cells[3].Value = Currency.Format(Rprice * (QtyInc - 1));   // Amount price
                        //  dgrvSalesItemList.Rows[n].Cells[4].Value = Itemid;                     



                        double qty = Convert.ToDouble(dgvItemList.Rows[n].Cells[2].Value);
                        double discount_rate = Convert.ToDouble(dgvItemList.Rows[n].Cells[7].Value);

                        if (discount_rate != 0)  // if discount has
                        {
                            double DisamtInc = (((Rprice * qty) * discount_rate) / 100.00);      // Total Discount amount of this item
                            dgvItemList.Rows[n].Cells[5].Value = DisamtInc;
                        }

                        if (Taxapply != 0)   // If apply  tax 
                        {
                            // Total Tax amount  of this item  (Rprice - disamount) * taxRate / 100
                            double TaxamtInc = ((((Rprice * qty) - (((Rprice * qty) * discount_rate) / 100.00)) * Taxrate) / 100.00);
                            dgvItemList.Rows[n].Cells[6].Value = TaxamtInc;
                        }
                        DiscountCalculation();
                        TaxCalculation();
                    }

                }
                catch (Exception ex)
                {
                    objerror.Write(ex.Message.ToString(), this.Name + " - timer1_Tick", Global.ERROR_WRITE_PATH);
                }

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
             
        #region Text box Validatation 
        //Validation Overall Discount Rate
        private void txtDiscountRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtDiscountRate.Text.ToString(), @"\.\d\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch (Exception ex)
            {
                objerror.Write(ex.Message.ToString(), this.Name + " - txtDiscountRate_KeyPress", Global.ERROR_WRITE_PATH);
            }
        }
       
        #endregion

        public double CheckStockQty(string strItemCode)
        {
            // SÉCURISÉ : Utilise SqlParameter pour item_code
            string strSQL = "SELECT stock_quantity FROM tbl_Item WHERE stock_item = 1 AND item_code = @itemCode";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@itemCode", System.Data.SqlDbType.NVarChar, 50) { Value = strItemCode }
            };

            DataTable dt = SecureDataAccess.GetDataTable(strSQL, parameters);

            double totalstockQty = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
            return totalstockQty;
        }


        private void btnDown_Click(object sender, EventArgs e)
        {
            int change = floCategory.VerticalScroll.Value + floCategory.VerticalScroll.SmallChange * 30;
            floCategory.AutoScrollPosition = new Point(0, change);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int change = floCategory.VerticalScroll.Value - floCategory.VerticalScroll.SmallChange * 30;
            floCategory.AutoScrollPosition = new Point(0, change);
        }

        private void btnRowUp_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvItemList;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[1].OwningRow.Index;
                if (rowIndex == 0)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[1].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.ClearSelection();
                dgv.Rows[rowIndex - 1].Cells[colIndex].Selected = true;
            }
            catch (Exception ex)
            {
                objerror.Write(ex.Message.ToString(), this.Name + " - btnRowUp_Click", Global.ERROR_WRITE_PATH);
            }
        }

        private void btnRowDown_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvItemList;
            try
            {
                int totalRows = dgv.Rows.Count;
                // get index of the row for the selected cell
                int rowIndex = dgv.SelectedCells[1].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;
                // get index of the column for the selected cell
                int colIndex = dgv.SelectedCells[1].OwningColumn.Index;
                DataGridViewRow selectedRow = dgv.Rows[rowIndex];
                dgv.ClearSelection();
                dgv.Rows[rowIndex + 1].Cells[colIndex].Selected = true;
            }
            catch (Exception ex)
            {
                objerror.Write(ex.Message.ToString(), this.Name + " - btnRowDown_Click", Global.ERROR_WRITE_PATH);
            }
        }

        private void btnQtyPlus_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvItemList.SelectedRows)
            {
                if (Convert.ToBoolean(row.Cells["clmIsStockItem"].Value)==true && Convert.ToDouble(row.Cells["clmQty"].Value) >= CheckStockQty(dgvItemList.Rows[dgvItemList.CurrentCell.RowIndex].Cells["clmItemCode"].Value.ToString()))
                {
                    Messages.InformationMessage("Insufficient quantity. Order quantity is greater than stock quantity");
                    
                    row.Cells["clmQty"].Value = CheckStockQty(dgvItemList.Rows[dgvItemList.CurrentCell.RowIndex].Cells["clmItemCode"].Value.ToString());

                    double dblQtySum = Convert.ToDouble(row.Cells["clmQty"].Value);
                    row.Cells["clmQty"].Value = dblQtySum;

                    double dblQty = Convert.ToDouble(row.Cells["clmQty"].Value);
                    double dblPrice = (double)Currency.Parse(row.Cells["clmPrice"].Value.ToString());
                    double dblDiscountRate = Convert.ToDouble(row.Cells["clmDiscountRate"].Value);
                    double dblTax1Rate = Convert.ToDouble(TaxValue.Tax1Rate);
                    double dblTax2Rate = Convert.ToDouble(TaxValue.Tax2Rate);

                    row.Cells["clmKotQty"].Value =dblQtySum.ToString();
                    
                    // show total price   Qty  * price
                    double totalPrice = dblQty * dblPrice;
                    row.Cells["clmAmount"].Value = Currency.Format(totalPrice);

                    if (Convert.ToDouble(row.Cells["clmDiscountRate"].Value) != 0)
                    {
                        double dblDiscountAmount = (((dblPrice * dblQty) * dblDiscountRate) / 100.00);      // Total Discount amount of this item
                        row.Cells["clmDiscountAmount"].Value = dblDiscountAmount;
                    }

                    if (Convert.ToBoolean(row.Cells["clmTaxApply"].Value) != false)
                    {
                        double dblTax1Amount = ((((dblPrice * dblQty) - (((dblPrice * dblQty) * dblDiscountRate) / 100.00)) * dblTax1Rate) / 100.00); // Total Tax amount  of this item
                        row.Cells["clmTax1Amount"].Value = dblTax1Amount;

                        if (TaxValue.TaxType == "2LevelofTax")
                        {
                            double dblTax2Amount = ((((dblPrice * dblQty) - (((dblPrice * dblQty) * dblDiscountRate) / 100.00)) * dblTax2Rate) / 100.00); // Total Tax amount  of this item
                            row.Cells["clmTax2Amount"].Value = dblTax2Amount;
                        }
                    }
                }
                else
                {
                    //// Increase by 1
                    double dblQtySum = Convert.ToDouble(row.Cells["clmQty"].Value) + 1;
                    row.Cells["clmQty"].Value = dblQtySum.ToString();

                    double dblQty = Convert.ToDouble(row.Cells["clmQty"].Value);
                    double dblPrice = (double)Currency.Parse(row.Cells["clmPrice"].Value.ToString());
                    double dblDiscountRate = Convert.ToDouble(row.Cells["clmDiscountRate"].Value);
                    double dblTax1Rate = Convert.ToDouble(TaxValue.Tax1Rate);
                    double dblTax2Rate = Convert.ToDouble(TaxValue.Tax2Rate);

                    double dblKotQty = Convert.ToDouble(row.Cells["clmKotQty"].Value) + 1;
                    row.Cells["clmKotQty"].Value = dblKotQty.ToString();

                    // show total price   Qty  * Price
                    double dblTotalPrice = dblQty * dblPrice;
                    row.Cells["clmAmount"].Value = Currency.Format(dblTotalPrice);

                    if (Convert.ToDouble(row.Cells["clmDiscountRate"].Value) != 0)
                    {
                        double dblDiscountAmount = (((dblPrice * dblQty) * dblDiscountRate) / 100.00);      // Total Discount amount of this item
                        row.Cells["clmDiscountAmount"].Value = dblDiscountAmount;
                    }

                    if (Convert.ToBoolean(row.Cells["clmTaxApply"].Value) != false)
                    {
                        double dblTax1Amount = ((((dblPrice * dblQty) - (((dblPrice * dblQty) * dblDiscountRate) / 100.00)) * dblTax1Rate) / 100.00); // Total Tax amount  of this item
                        row.Cells["clmTax1Amount"].Value = dblTax1Amount;

                        if (TaxValue.TaxType == "2LevelofTax")
                        {
                            double dblTax2Amount = ((((dblPrice * dblQty) - (((dblPrice * dblQty) * dblDiscountRate) / 100.00)) * dblTax2Rate) / 100.00); // Total Tax amount  of this item
                            row.Cells["clmTax2Amount"].Value = dblTax2Amount;
                        }
                    }
                    btnQtyMinus.Enabled = true;
                }
                DiscountCalculation();
                TaxCalculation();
                txtDiscountRate.Text = "0";
                Console.Beep();
            }
        }

        private void btnQtyMinus_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvItemList.SelectedRows)
            {
                if (Convert.ToDouble(row.Cells["clmQty"].Value) > 1)
                {
                    //// Decrease by 1 
                    double dblQtySum = Convert.ToDouble(row.Cells["clmQty"].Value) - 1;
                    row.Cells["clmQty"].Value = dblQtySum;

                    double dblQty = Convert.ToDouble(row.Cells["clmQty"].Value);
                    double dblPrice = (double)Currency.Parse(row.Cells["clmPrice"].Value.ToString());
                    double dblDiscountRate = Convert.ToDouble(row.Cells["clmDiscountRate"].Value);
                    double dblTax1Rate = Convert.ToDouble(TaxValue.Tax1Rate);
                    double dblTax2Rate = Convert.ToDouble(TaxValue.Tax2Rate);

                    double dblKotQty = Convert.ToDouble(row.Cells["clmKotQty"].Value) - 1;
                    if (dblKotQty < 0)
                    {
                        row.Cells["clmKotQty"].Value = "0";
                    }
                    else
                    {
                        row.Cells["clmKotQty"].Value = int.Parse(dblKotQty.ToString());
                    }

                    //Show total price   Qty  * price
                    double dblTotalPrice = dblQty * dblPrice;
                    row.Cells["clmAmount"].Value = Currency.Format(dblTotalPrice);

                    if (Convert.ToDouble(row.Cells["clmDiscountAmount"].Value) != 0)
                    {
                        double dblDiscountAmount = (((dblPrice * dblQty) * dblDiscountRate) / 100.00);      // Total Discount amount of this item
                        row.Cells["clmDiscountAmount"].Value = dblDiscountAmount;
                    }

                    if (Convert.ToBoolean(row.Cells["clmTaxApply"].Value) != false)
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

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvItemList.SelectedRows)
            {
                //bool result = Messages.QuestionMessage("Do you want to delete this item?");
                //if (result ==true)
                //{
                if (!row.IsNewRow)
                    dgvItemList.Rows.Remove(row);
                    DiscountCalculation();
                    TaxCalculation();
                    txtDiscountRate.Text = "0";
                    Console.Beep();
                if (dgvItemList.RowCount ==0)
                {
                    btnDeleteRow.Enabled = false;
                    btnChangePrice.Enabled = false;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SetWindowPos(TaskbarHWnd, IntPtr.Zero, 0, 0, 0, 0,
            SetWindowPosFlags.SWP_SHOWWINDOW);
            SetWindowPos(StartButtonHWnd, IntPtr.Zero, 0, 0, 0, 0,
            SetWindowPosFlags.SWP_SHOWWINDOW);
            Environment.Exit(0);
        }


        private void DateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            }
            catch (Exception ex)
            {
                objerror.Write(ex.Message.ToString(), this.Name + " - DateTimer_Tick", Global.ERROR_WRITE_PATH);
            }
        }

        private void btnUserLogOff_Click(object sender, EventArgs e)
        {
            bool result = Messages.QuestionMessage("Do you want to Sign out?");
            if (result == true)
            {
                WorkRecords();
                frmLogin go = new frmLogin();
                go.Show();
                this.Close();
            }     
        }

        public void WorkRecords()
        {
            string strLogDate = DateTime.Now.ToString("yyyy-MM-dd");
            string strLogTime = DateTime.Now.ToString("HH:mm:ss");

            // SÉCURISÉ : Utilise SqlParameter pour le log utilisateur
            string strSQL = @"INSERT INTO tbl_UserLogs (user_name, log_type, log_date, log_time)
                            VALUES (@userName, 'OUT', @logDate, @logTime)";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@userName", System.Data.SqlDbType.NVarChar, 100) { Value = UserInfo.UserName },
                new System.Data.SqlClient.SqlParameter("@logDate", System.Data.SqlDbType.NVarChar, 20) { Value = strLogDate },
                new System.Data.SqlClient.SqlParameter("@logTime", System.Data.SqlDbType.NVarChar, 20) { Value = strLogTime }
            };

            SecureDataAccess.ExecuteNonQuery(strSQL, parameters);
        }

        private void btnCalculator_Click(object sender, EventArgs e)
        {
            try
            {
                Process pros = new Process();
                pros.StartInfo.FileName = "calc.exe";
                pros.Start();
                pros.WaitForInputIdle();
            }
            catch (Exception ex)
            {
                objerror.Write(ex.Message.ToString(), this.Name + " - btnCalculator_Click", Global.ERROR_WRITE_PATH);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmBackOffice frmSettings =new frmBackOffice(this);
            frmSettings.ShowDialog();
        }

      
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomerPopup frmCustomerPopup = new frmCustomerPopup(this);
            frmCustomerPopup.ShowDialog();
        }


        #region Common
        private bool RowIsVisible(DataGridViewRow row)
        {
            DataGridView dgv = row.DataGridView;
            int firstVisibleRowIndex = dgv.FirstDisplayedCell.RowIndex;
            int lastVisibleRowIndex = firstVisibleRowIndex + dgv.DisplayedRowCount(false) - 1;
            //return row.Index >= firstVisibleRowIndex && row.Index <= lastVisibleRowIndex;
            return row.Index >= lastVisibleRowIndex;
        }

        #endregion


        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                pnlLeft.Enabled = true;
                pnlBottom.Enabled = true;

            }
        }



        List<int> split(int num, int splitBy)
        {
            List<int> r = new List<int>();
            int v = Convert.ToInt32(num / splitBy);
            r.AddRange(Enumerable.Repeat(splitBy, v).ToArray());
            var remaining = num % splitBy;
            if (remaining != 0)
                r.Add(remaining);
            return r;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dtAllItems.Rows.Count > 0)
            {
                int iItemCount = (from DataRow dr in dtAllItems.Rows where (bool)dr["show_pos"] == true select dr).Count();
                int iPagesCount = Convert.ToInt32(Math.Ceiling(iItemCount * 1.0 / 20));

                int iCurrentPage = int.Parse(lblCurrentPage.Text.ToString());

                var result = split(iItemCount, 20);

                int iStart = result[(iCurrentPage - 1)] * iCurrentPage;
                int iItemsPerPage = Settings.ItemsPerPage;

                DataTable dtPage = dtAllItems.AsEnumerable().OrderBy(r => r.Field<string>("item_name")).Skip(iStart).Take(iItemsPerPage).CopyToDataTable();
                LoadItems(dtPage);

                iCurrentPage += 1;

                lblCurrentPage.Text = iCurrentPage.ToString();
                lblTotalPages.Text = iPagesCount.ToString();

                if (iCurrentPage == iPagesCount)//End of Page
                {
                    btnNext.Enabled = false;
                    btnPrevious.Enabled = true;
                }
                else if (iCurrentPage > 1)
                {
                    btnPrevious.Enabled = true;
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int iStart = 0;
            if (dtAllItems.Rows.Count > 0)
            {
                int iItemCount = (from DataRow dr in dtAllItems.Rows where (bool)dr["show_pos"] == true select dr).Count();
                int iPagesCount = Convert.ToInt32(Math.Ceiling(iItemCount * 1.0 / 20));

                int iCurrentPage = int.Parse(lblCurrentPage.Text.ToString());

                var result = split(iItemCount, 20);

                int iItemsPerPage = Settings.ItemsPerPage;
                if (iCurrentPage == 2)
                {
                    iStart = 0;
                }
                else
                {
                    iStart = result[(iCurrentPage - 2)];
                }

                DataTable dtPage = dtAllItems.AsEnumerable().OrderBy(r => r.Field<string>("item_name")).Skip(iStart).Take(iItemsPerPage).CopyToDataTable();
                LoadItems(dtPage);

                iCurrentPage -= 1;
                lblCurrentPage.Text = iCurrentPage.ToString();
                lblTotalPages.Text = iPagesCount.ToString();

                if (iCurrentPage == 1)
                {
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = true;
                }
                else
                {
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = true;
                }
            }
        }

        private void dgvItemList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int iRowCount = dgvItemList.RowCount;
            if (iRowCount == 1)
            {
                int iQty = int.Parse(dgvItemList.Rows[e.RowIndex].Cells["clmQty"].Value.ToString());

                if (iQty == 1)
                {
                    btnQtyPlus.Enabled = true;
                    btnQtyMinus.Enabled = false;
                }
                else
                {
                    btnQtyPlus.Enabled = true;
                    btnQtyMinus.Enabled = true;
                }
                btnRowUp.Enabled = false;
                btnRowDown.Enabled = false;
            }
            else if (iRowCount > 1)
            {
                int iQty = int.Parse(dgvItemList.Rows[e.RowIndex].Cells["clmQty"].Value.ToString());

                if (iQty == 1)
                {
                    btnQtyPlus.Enabled = true;
                    btnQtyMinus.Enabled = false;
                }
                else
                {
                    btnQtyPlus.Enabled = true;
                    btnQtyMinus.Enabled = true;
                }
                if (e.RowIndex == 1)
                {
                    btnRowUp.Enabled = false;
                    btnRowDown.Enabled = true;
                }
                else
                {
                    btnRowUp.Enabled = true;
                    btnRowDown.Enabled = true;
                }
            }
            else
            {
                btnQtyPlus.Enabled = false;
                btnQtyMinus.Enabled = false;
                btnRowUp.Enabled = false;
                btnRowDown.Enabled = false;
            }
        }

        private void dgvItemList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItemList.RowCount > 0)
            {
                decimal decQty = decimal.Parse(dgvItemList.Rows[e.RowIndex].Cells["clmQty"].Value.ToString());
                if (decQty == 1)
                {
                    btnQtyMinus.Enabled = false;
                }
                else
                {
                    btnQtyMinus.Enabled = true;
                }
            }
        }

        #region Hold & Recall

        private void btnHold_Click(object sender, EventArgs e)
        {
            // Sécuriser la conversion avec TryParse pour éviter FormatException
            decimal totalPayable = 0;
            decimal.TryParse(lblTotalPayable.Text, out totalPayable);

            if (totalPayable == 0 || lblTotalPayable.Text == string.Empty)
            {
                Messages.InformationMessage("Please enter item(s)");
            }
            else
            {
                //Save Invoice
                HoldInvoice(totalPayable, totalPayable, 0, 0, DateTime.Now.ToString("dd/MM/yyyy").ToString(), DateTime.Now.ToString("hh:mm tt"), string.Empty, "Hold");

                foreach (DataGridViewRow row in dgvItemList.Rows)
                if (Convert.ToDouble(row.Cells["clmKotQty"].Value) > 0)
                {
                    if (Settings.PrintKotAfterHold)
                    {
                        PrintKot();
                    }
                }
                Clear();
            }
        }

        public void PrintKot()
        {
            if (Settings.ViewKotB4Print)
            {
                frmPrintView frmPrintView = new frmPrintView(this);
                frmPrintView.RefNo = holdId.ToString();
                frmPrintView.Report = "Kot";
                frmPrintView.ShowDialog();
            }
            else
            {
                LocalReport report = new LocalReport();
                report.ReportEmbeddedResource = "cypos.Reports.rptKot.rdlc";

                report.EnableExternalImages = true;

                // SÉCURISÉ : Utilise SqlParameter pour holdId dans PrintKot
                string strSQL = "SELECT tbl_TempHeader.order_type, tbl_TempHeader.invoice_date, tbl_TempHeader.invoice_time,"+
                                "tbl_TempHeader.kot_no, tbl_TempHeader.table_id,tbl_Tables.table_name, tbl_TableLocation.location_name,"+
                                "tbl_TempHeader.no_of_guests, tbl_TempHeader.waiter_id, tbl_User.name, tbl_TempHeader.note,"+
                                "tbl_TempHeader.user_name, tbl_TempDetail.item_code, tbl_TempDetail.item_name, tbl_TempDetail.kot_qty AS qty,"+
                                "tbl_TempDetail.show_kitchen, tbl_TempDetail.print_kot,tbl_Company.company_name " +
                                "FROM tbl_TempHeader INNER JOIN " +
                                "tbl_TempDetail ON tbl_TempHeader.id = tbl_TempDetail.header_id LEFT JOIN " +
                                "tbl_Tables ON tbl_TempHeader.table_id = tbl_Tables.id LEFT JOIN " +
                                "tbl_TableLocation ON tbl_Tables.location_id = tbl_TableLocation.Id LEFT OUTER JOIN " +
                                "tbl_User ON tbl_TempHeader.waiter_id = tbl_User.id "+
                                "CROSS JOIN tbl_Company "+
                                "WHERE tbl_TempHeader.id = @holdId AND tbl_TempDetail.print_kot = 1 AND kot_qty > 0";

                System.Data.SqlClient.SqlParameter[] parametersKot = {
                    new System.Data.SqlClient.SqlParameter("@holdId", System.Data.SqlDbType.Int) { Value = holdId }
                };

                DataTable result = SecureDataAccess.GetDataTable(strSQL, parametersKot);

                if (result.Rows.Count > 0)
                {
                    ReportDataSource reportDSDetail = new ReportDataSource("dsKot", result);
                    report.DataSources.Clear();
                    report.DataSources.Add(reportDSDetail);
                    report.Refresh();

                    if (DirectPrint.Print(report, Settings.KotPrinter))
                    {
                        UpdateKotPrintedItems();
                        Clear();
                    }
                }
            }
        }

        public void UpdateKotPrintedItems()
        {
            string strSQLUpdate = string.Empty;

            int rows = dgvItemList.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                string strItemCode = dgvItemList.Rows[i].Cells["clmItemCode"].Value.ToString();
                double dblQty =Convert.ToDouble(dgvItemList.Rows[i].Cells["clmQty"].Value.ToString());
                double dblKotQty = Convert.ToDouble(dgvItemList.Rows[i].Cells["clmKotQty"].Value.ToString());

                // SÉCURISÉ : Utilise SqlParameter pour UPDATE kot_qty
                strSQLUpdate = "UPDATE tbl_TempDetail SET kot_qty = 0 WHERE item_code = @itemCode AND header_id = @holdId";

                System.Data.SqlClient.SqlParameter[] parametersUpdate = {
                    new System.Data.SqlClient.SqlParameter("@itemCode", System.Data.SqlDbType.NVarChar, 50) { Value = strItemCode },
                    new System.Data.SqlClient.SqlParameter("@holdId", System.Data.SqlDbType.Int) { Value = holdId }
                };

                SecureDataAccess.ExecuteNonQuery(strSQLUpdate, parametersUpdate);
            }
        }

        public void HoldInvoice(decimal decPayAmount, decimal decPaidAmount, decimal decChangeAmount, decimal decDueAmount, string strInvoiceDate, string strInvoiceTime, string strPaymentType, string strNote)
        {
            string strTax1Name = TaxValue.Tax1Name;
            string strTax2Name = TaxValue.Tax2Name;

            string strOtId = lblOrderTypeId.Text;
            //string strOrderType = string.Empty;

            if (strOtId == "0")//If Nothing Selected get the default Order Type
            {
                strOtId = Settings.DefaultOrderType.ToString();
            }

            //if (strOtId == "1")
            //{
            //    strOrderType = "Dine In";
            //}
            //else if (strOtId == "2")
            //{
            //    strOrderType = "Take Away";
            //}
            //else if (strOtId == "3")
            //{
            //    strOrderType = "Delivery Order";
            //}
            //else if (strOtId == "4")
            //{
            //    strOrderType = "Pickup Order";
            //}

            // OPÉRATION HOLD AVEC TRANSACTION SQL
            // Si une étape échoue, TOUT est rollback (évite perte de données)
            try
            {
                int HeaderId = 0;

                SecureDataAccess.ExecuteTransaction((conn, transaction) =>
                {
                    // ÉTAPE 1 : DELETE existing temp data (if any)
                    if (holdId > 0)
                    {
                        string strSQLTHeader = "DELETE FROM tbl_TempHeader WHERE id = @holdId";
                        using (System.Data.SqlClient.SqlCommand cmdDelHeader = new System.Data.SqlClient.SqlCommand(strSQLTHeader, conn, transaction))
                        {
                            cmdDelHeader.Parameters.AddWithValue("@holdId", holdId);
                            cmdDelHeader.ExecuteNonQuery();
                        }

                        string strSQLTDetail = "DELETE FROM tbl_TempDetail WHERE header_id = @holdId";
                        using (System.Data.SqlClient.SqlCommand cmdDelDetail = new System.Data.SqlClient.SqlCommand(strSQLTDetail, conn, transaction))
                        {
                            cmdDelDetail.Parameters.AddWithValue("@holdId", holdId);
                            cmdDelDetail.ExecuteNonQuery();
                        }
                    }

                    // ÉTAPE 2 : INSERT Temp Header
                    string strSQLHeader = @"INSERT INTO tbl_TempHeader
                        (order_type, invoice_date, invoice_time, kot_no, table_id, no_of_guests, waiter_id, customer_id,
                         payment_type, payment_amount, paid_amount, change_amount, due_amount, discount_rate, discount_amount,
                         tax1_name, tax1_rate, tax1_amount, tax2_name, tax2_rate, tax2_amount, sc_rate, sc_charge, note, user_name, log_date)
                        VALUES
                        (@orderType, @invoiceDate, @invoiceTime, @kotNo, @tableId, @noOfGuests, @waiterId, @customerId,
                         @paymentType, @paymentAmount, @paidAmount, @changeAmount, @dueAmount, @discountRate, @discountAmount,
                         @tax1Name, @tax1Rate, @tax1Amount, @tax2Name, @tax2Rate, @tax2Amount, @scRate, @scCharge, @note, @userName, @logDate);
                        SELECT CAST(SCOPE_IDENTITY() AS INT)";

                    using (System.Data.SqlClient.SqlCommand cmdHeader = new System.Data.SqlClient.SqlCommand(strSQLHeader, conn, transaction))
                    {
                        cmdHeader.Parameters.AddWithValue("@orderType", strOtId);
                        cmdHeader.Parameters.AddWithValue("@invoiceDate", strInvoiceDate);
                        cmdHeader.Parameters.AddWithValue("@invoiceTime", strInvoiceTime);
                        cmdHeader.Parameters.AddWithValue("@kotNo", lblKotNo.Text);
                        cmdHeader.Parameters.AddWithValue("@tableId", lblTableId.Text);
                        cmdHeader.Parameters.AddWithValue("@noOfGuests", lblNoOfGuests.Text);
                        cmdHeader.Parameters.AddWithValue("@waiterId", lblWaiterId.Text);
                        cmdHeader.Parameters.AddWithValue("@customerId", lblCustomerId.Text);
                        cmdHeader.Parameters.AddWithValue("@paymentType", strPaymentType);
                        cmdHeader.Parameters.AddWithValue("@paymentAmount", decPayAmount);
                        cmdHeader.Parameters.AddWithValue("@paidAmount", decPaidAmount);
                        cmdHeader.Parameters.AddWithValue("@changeAmount", decChangeAmount);
                        cmdHeader.Parameters.AddWithValue("@dueAmount", decDueAmount);

                        // Sécuriser conversions decimal (labels peuvent être vides ou contenir texte)
                        decimal discountRate = 0;
                        decimal.TryParse(txtDiscountRate.Text, out discountRate);
                        cmdHeader.Parameters.AddWithValue("@discountRate", discountRate);

                        decimal discountAmount = 0;
                        decimal.TryParse(lblOverallDiscount.Text, out discountAmount);
                        cmdHeader.Parameters.AddWithValue("@discountAmount", discountAmount);

                        cmdHeader.Parameters.AddWithValue("@tax1Name", strTax1Name);

                        decimal tax1Rate = 0;
                        decimal.TryParse(lblTax1Rate.Text, out tax1Rate);
                        cmdHeader.Parameters.AddWithValue("@tax1Rate", tax1Rate);

                        decimal tax1Amount = 0;
                        decimal.TryParse(lblTotalTax1.Text, out tax1Amount);
                        cmdHeader.Parameters.AddWithValue("@tax1Amount", tax1Amount);

                        cmdHeader.Parameters.AddWithValue("@tax2Name", strTax2Name);

                        decimal tax2Rate = 0;
                        decimal.TryParse(lblTax2Rate.Text, out tax2Rate);
                        cmdHeader.Parameters.AddWithValue("@tax2Rate", tax2Rate);

                        decimal tax2Amount = 0;
                        decimal.TryParse(lblTotalTax2.Text, out tax2Amount);
                        cmdHeader.Parameters.AddWithValue("@tax2Amount", tax2Amount);

                        decimal scRate = 0;
                        decimal.TryParse(lblScRate.Text, out scRate);
                        cmdHeader.Parameters.AddWithValue("@scRate", scRate);

                        decimal scCharge = 0;
                        decimal.TryParse(lblScAmount.Text, out scCharge);
                        cmdHeader.Parameters.AddWithValue("@scCharge", scCharge);
                        cmdHeader.Parameters.AddWithValue("@note", strNote);
                        cmdHeader.Parameters.AddWithValue("@userName", UserInfo.UserName);
                        cmdHeader.Parameters.AddWithValue("@logDate", DateTime.Now);

                        HeaderId = (int)cmdHeader.ExecuteScalar();
                    }

                    // ÉTAPE 3 : INSERT Temp Details
                    int rows = dgvItemList.Rows.Count;
                    for (int i = 0; i < rows; i++)
                    {
                        string strItemCode = dgvItemList.Rows[i].Cells["clmItemCode"].Value.ToString();
                        string strItemName = dgvItemList.Rows[i].Cells["clmItemName"].Value.ToString();
                        double dblQty = Convert.ToDouble(dgvItemList.Rows[i].Cells["clmQty"].Value.ToString());
                        double dblPrice = (double)Currency.Parse(dgvItemList.Rows[i].Cells["clmPrice"].Value.ToString());
                        double dblTotal = (double)Currency.Parse(dgvItemList.Rows[i].Cells["clmAmount"].Value.ToString());
                        double dblDiscount = Convert.ToDouble(dgvItemList.Rows[i].Cells["clmDiscountRate"].Value.ToString());
                        bool isTaxApply = Convert.ToBoolean(dgvItemList.Rows[i].Cells["clmTaxApply"].Value.ToString());
                        bool isKitchenDisplay = Convert.ToBoolean(dgvItemList.Rows[i].Cells["clmKitchenDisplay"].Value.ToString());
                        bool isPrintKot = Convert.ToBoolean(dgvItemList.Rows[i].Cells["clmPrintInKot"].Value.ToString());
                        double dblKotQty = Convert.ToDouble(dgvItemList.Rows[i].Cells["clmKotQty"].Value.ToString());

                        string strSQLDetail = @"INSERT INTO tbl_TempDetail
                            (header_id, item_code, item_name, qty, selling_price, total, profit, discount, tax_apply, show_kitchen, print_kot, kot_qty, log_date)
                            VALUES
                            (@headerId, @itemCode, @itemName, @qty, @price, @total, @profit, @discount, @taxApply, @kitchenDisplay, @printKot, @kotQty, @logDate)";

                        using (System.Data.SqlClient.SqlCommand cmdDetail = new System.Data.SqlClient.SqlCommand(strSQLDetail, conn, transaction))
                        {
                            cmdDetail.Parameters.AddWithValue("@headerId", HeaderId);
                            cmdDetail.Parameters.AddWithValue("@itemCode", strItemCode);
                            cmdDetail.Parameters.AddWithValue("@itemName", strItemName);
                            cmdDetail.Parameters.AddWithValue("@qty", dblQty);
                            cmdDetail.Parameters.AddWithValue("@price", dblPrice);
                            cmdDetail.Parameters.AddWithValue("@total", dblTotal);
                            cmdDetail.Parameters.AddWithValue("@profit", 0);
                            cmdDetail.Parameters.AddWithValue("@discount", dblDiscount);
                            cmdDetail.Parameters.AddWithValue("@taxApply", isTaxApply);
                            cmdDetail.Parameters.AddWithValue("@kitchenDisplay", isKitchenDisplay);
                            cmdDetail.Parameters.AddWithValue("@printKot", isPrintKot);
                            cmdDetail.Parameters.AddWithValue("@kotQty", dblKotQty);
                            cmdDetail.Parameters.AddWithValue("@logDate", DateTime.Now);

                            cmdDetail.ExecuteNonQuery();
                        }
                    }
                });

                // Transaction committed successfully
                holdId = HeaderId;
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage("Erreur lors de la sauvegarde Hold: " + ex.Message);
                objerror.Write(ex.Message, this.Name + " - HoldInvoice_Transaction", Global.ERROR_WRITE_PATH);
                throw;
            }
        }

        #endregion

        private void btnRecall_Click(object sender, EventArgs e)
        {
            frmRecallInvoices frmRecallInvoices = new frmRecallInvoices(this);
            frmRecallInvoices.ShowDialog();
        }

        #region Order Type
        private void btnOrderType_Click(object sender, EventArgs e)
        {
            frmOrderType frmOrderType = new frmOrderType(this);
            frmOrderType.ShowDialog();
        }

        public void SetOrderType(int typeId,string strType)
        {
            if (strType != string.Empty)
            {
                lblOrderTypeId.Text = typeId.ToString();
                btnSelectedOT.Text ="Order Type" + Environment.NewLine + strType;
                if (typeId == 1)
                {
                    pnlTableNo.Visible = true;
                    pnlWaiter.Visible = true;
                }
                else
                {
                    pnlTableNo.Visible = false;
                    pnlWaiter.Visible = false;
                    lblTableId.Text = "0";
                    lblNoOfGuests.Text = "0";
                    lblWaiterId.Text = "0";
                    btnSelectedTable.Text = "Order Type";
                    btnWaiter.Text = "Waiter";
                }
            }
        }

        #endregion

        #region Tables
        private void btnTable_Click(object sender, EventArgs e)
        {
            frmTableView frmTables = new frmTableView(this);
            frmTables.ShowDialog();
        }

        public void SetTable(int itableId, string strTableNo, int guestCount, int iWaiterId, string strWaiter)
        {
            if (itableId > 0)
            {
                if (Settings.AskTable && !Settings.AskGuestCount)
                {
                    lblNoOfGuests.Text = "0";
                    btnSelectedTable.Text ="Table" + Environment.NewLine + strTableNo;
                }
                else if (Settings.AskTable && Settings.AskGuestCount)
                {
                    lblNoOfGuests.Text = guestCount.ToString();
                    lblTableId.Text = itableId.ToString();
                    btnSelectedTable.Text = "Table" + Environment.NewLine + strTableNo + " (" + guestCount + ")";
                }

                if (Settings.AskWaiter)
                {
                    pnlWaiter.Visible = true;
                    lblWaiterId.Text = iWaiterId.ToString();
                    btnWaiter.Text = "Waiter" + Environment.NewLine + strWaiter;
                }
                else
                {
                    pnlWaiter.Visible = false;
                }

            }
        }

        #endregion

        private void btnUser_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserProfile frmUserProfile = new frmUserProfile(btnUser.Tag.ToString());
                frmUserProfile.ShowDialog();
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        public void UpdatePrice(double dblPrice)
        {
            foreach (DataGridViewRow row in dgvItemList.SelectedRows)
            {
                double dblDiscRate = double.Parse(dgvItemList.Rows[row.Index].Cells["clmDiscountRate"].Value.ToString());
                double dblQty = double.Parse(dgvItemList.Rows[row.Index].Cells["clmQty"].Value.ToString());
                double dblAmount = dblQty * dblPrice;
                dgvItemList.Rows[row.Index].Cells["clmPrice"].Value = Currency.Format(dblPrice);
                dgvItemList.Rows[row.Index].Cells["clmAmount"].Value = Currency.Format(dblAmount);

                bool isTaxApply = Convert.ToBoolean(dgvItemList.Rows[row.Index].Cells["clmTaxApply"].Value);
                
                if (isTaxApply != false) // If apply  tax 
                {
                    double dblTaxOneAmount = ((((dblPrice * dblQty) - (((dblPrice * dblQty) * dblDiscRate) / 100.00)) * double.Parse(lblTax1Rate.Text)) / 100.00);
                    dgvItemList.Rows[row.Index].Cells["clmTax1Amount"].Value = dblTaxOneAmount;

                    if (TaxValue.TaxType == "2LevelofTax") // Two Tax Enabled
                    {
                        if (TaxValue.CalMethod == 1)
                        {
                            double dblTaxTwoAmount1 = ((((dblPrice * dblQty) - (((dblPrice * dblQty) * dblDiscRate) / 100.00)) * double.Parse(lblTax2Rate.Text)) / 100.00);
                            dgvItemList.Rows[row.Index].Cells["clmTax2Amount"].Value = dblTaxTwoAmount1;
                        }
                        else if (TaxValue.CalMethod == 2)
                        {
                            double dblTaxTwoAmount2 = (((((dblPrice * dblQty) - (((dblPrice * dblQty) * dblDiscRate) / 100.00)) + dblTaxOneAmount) * double.Parse(lblTax2Rate.Text)) / 100.00);
                            dgvItemList.Rows[row.Index].Cells["clmTax2Amount"].Value = dblTaxTwoAmount2;
                        }
                    }
                }

                DiscountCalculation();
                TaxCalculation();
            }     
        }

        public void Clear()
        {
            holdId = 0;
            dgvItemList.Rows.Clear();
            lblTotalPayable.Text = "0.00";
            lblTotal.Text = "0.00";
            lblTotalDiscount.Text = "0.00";
            txtDiscountRate.Text = Settings.DefaultDiscount.ToString();
            lblSubtotal.Text = "0.00";
            lblTax1Rate.Text = TaxValue.Tax1Rate.ToString();
            lblTax2Rate.Text = TaxValue.Tax2Rate.ToString();
            lblTotalTax1.Text = "0.00";
            lblTotalTax2.Text = "0.00";
            lblScAmount.Text = "0.00";
            lblOverallDiscount.Text = "0.00";
            txtDiscountRate.Text = Settings.DefaultDiscount.ToString();
            tssTotalItems.Text = "Total Item(s) : 0 ";

            btnModifier.Enabled = false;
            btnQtyPlus.Enabled = false;
            btnQtyMinus.Enabled = false;

            btnRowUp.Enabled = false;
            btnRowDown.Enabled = false;

            btnDeleteRow.Enabled = false;
            btnChangePrice.Enabled = false;

            int defaultOt = Settings.DefaultOrderType;
            lblOrderTypeId.Text = Settings.DefaultOrderType.ToString();
            if (defaultOt == 1)
            {
                btnSelectedOT.Text = "Order Type" + Environment.NewLine + "Dine In";
            }
            else if (defaultOt == 2)
            {
                btnSelectedOT.Text = "Order Type" + Environment.NewLine + "Take Away";
            }
            else if (defaultOt == 3)
            {
                btnSelectedOT.Text = "Order Type" + Environment.NewLine + "Delivery Order";
            }
            else if (defaultOt == 4)
            {
                btnSelectedOT.Text = "Order Type" + Environment.NewLine + "Pickup Order";
            }

            if (Settings.AskTable)
            {
                btnTable.Enabled = true;
                lblTableId.Text = "0";
                btnSelectedTable.Text = "Table";
                pnlTableNo.Visible = true;
            }
            else
            {
                btnTable.Enabled = false;
                pnlTableNo.Visible = false;
            }


            if (Settings.AskTable && Settings.AskWaiter)
            {
                lblWaiterId.Text = "0";
                btnWaiter.Text = "Waiter";
                pnlWaiter.Visible = true;
            }
            else
            {
                pnlWaiter.Visible = false;
            }

            if (TaxValue.TaxType == "NoTax")
            {
                lblTax1Name.Text = String.Empty;
                lblTax1Rate.Text = "0";
                lblTax2Name.Text = String.Empty;
                lblTax2Rate.Text = "0";

                lblTax1Name.Visible = false;
                lblTax1Rate.Visible = false;
                lblTax2Name.Visible = false;
                lblTax2Rate.Visible = false;
                lblTotalTax1.Visible = false;
                lblTotalTax2.Visible = false;
            }
            else if (TaxValue.TaxType == "1LevelofTax")
            {
                lblTax1Name.Text = TaxValue.Tax1Name + " (%):";
                lblTax1Rate.Text = TaxValue.Tax1Rate;
                lblTax2Name.Text = String.Empty;
                lblTax2Rate.Text = "0";
                lblTax1Name.Visible = true;
                lblTax1Rate.Visible = true;
                lblTax2Name.Visible = false;
                lblTax2Rate.Visible = false;

                lblTotalTax1.Visible = true;
                lblTotalTax2.Visible = false;
            }

            else if (TaxValue.TaxType == "2LevelofTax")
            {
                lblTax1Name.Text = TaxValue.Tax1Name + " (%):";
                lblTax1Rate.Text = TaxValue.Tax1Rate;
                lblTax2Name.Text = TaxValue.Tax2Name + " (%):";
                lblTax2Rate.Text = TaxValue.Tax2Rate;
                lblTax1Name.Visible = true;
                lblTax1Rate.Visible = true;
                lblTax2Name.Visible = true;
                lblTax2Rate.Visible = true;
                lblTotalTax1.Visible = true;
                lblTotalTax2.Visible = true;
            }

            if (Settings.EnableServiceCharge)
            {
                lblServiceCharge.Visible = true;
                lblScAmount.Visible = true;
                lblScRate.Text = Settings.ServiceChargeRate.ToString();
                lblServiceCharge.Text = "Service Charge (" + Settings.ServiceChargeRate.ToString() + "%)";
            }
            else
            {
                lblScRate.Text = "0";
                lblScAmount.Text = "0";
                lblServiceCharge.Visible = false;
                lblScAmount.Visible = false;
            }

            lblCustomerId.Text = "0";
            btnSelectedCustomer.Text = "Customer" + Environment.NewLine + "Guest";
            btnAllCategory_Click(null, null);//Load All Categories
            btnQuickSale.Enabled = false;
            btnPayment.Enabled = false;
        }

        #region Modifiers
        private void btnModifier_Click(object sender, EventArgs e)
        {
            frmModifierList frmModifierList = new frmModifierList(this);
            DataGridViewSelectedRowCollection rows = dgvItemList.SelectedRows;
            DataGridViewCell ItemCodeCell = dgvItemList.SelectedCells[0] as DataGridViewCell;
            DataGridViewCell ItemNameCell = dgvItemList.SelectedCells[1] as DataGridViewCell;
            DataGridViewCell ModifierIdCell = dgvItemList.SelectedCells[13] as DataGridViewCell;

            string strItemCode = ItemCodeCell.Value.ToString();
            string strItemName = ItemNameCell.Value.ToString();
            string strModifierIds =ModifierIdCell.Value.ToString(); 
            
            frmModifierList.ItemCode = strItemCode;
            frmModifierList.ItemName= strItemName;
            frmModifierList.ModifierIds = strModifierIds;
            frmModifierList.ShowDialog();
        }

        public void AddRemoveModifiers(string strItemCode,string strModifierName,Image imgBackground, string strPlusOrMinus, decimal decModifierPrice, int iModifierId)
        {
            int n = FindItemById(strItemCode);

            if (n > -1)
            {
                dgvItemList.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                if (imgBackground== null) //Add modifiers
                {
                    dgvItemList.Rows[n].Cells[1].Value = (dgvItemList.Rows[n].Cells[1].Value.ToString() + Environment.NewLine + " - " + strModifierName.ToString());
                    decimal decItemPrice = decimal.Parse(dgvItemList.Rows[n].Cells[2].Value.ToString());
                    if (strPlusOrMinus == "+")
                    {
                        dgvItemList.Rows[n].Cells[2].Value = decItemPrice + decModifierPrice;
                        decimal decAmount = Convert.ToDecimal(dgvItemList.Rows[n].Cells[2].Value) * Convert.ToDecimal(dgvItemList.Rows[n].Cells[3].Value);
                        dgvItemList.Rows[n].Cells[4].Value = decAmount.ToString();
                    }
                    else
                    {
                        dgvItemList.Rows[n].Cells[2].Value = decItemPrice - Math.Abs(decModifierPrice);
                        decimal decAmount = Convert.ToDecimal(dgvItemList.Rows[n].Cells[2].Value) * Convert.ToDecimal(dgvItemList.Rows[n].Cells[3].Value);
                        dgvItemList.Rows[n].Cells[4].Value = decAmount.ToString();
                    }

                    string strModId = dgvItemList.Rows[n].Cells[13].Value.ToString();
                    dgvItemList.Rows[n].Cells[13].Value = "";
                    dgvItemList.Rows[n].Cells[13].Value = strModId + "," + iModifierId;

                    dgvItemList.AutoResizeRow(n, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
                    DataGridViewCell NameCell = dgvItemList[1, n];
                    NameCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                    DataGridViewCell PriceCell = dgvItemList[2, n];
                    PriceCell.Style.Alignment = DataGridViewContentAlignment.TopRight;
                    DataGridViewCell QtyCell = dgvItemList[3, n];
                    QtyCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
                    DataGridViewCell AmountCell = dgvItemList[4, n];
                    AmountCell.Style.Alignment = DataGridViewContentAlignment.TopRight;
                }
                else //Remove Modifiers
                {
                    string ItemCellValue = dgvItemList.Rows[n].Cells[1].Value.ToString();
                    string strNewValue = ItemCellValue.Replace(" - " + strModifierName.Split(new[] { '\r', '\n' }).FirstOrDefault(), "");

                    string strValue = Regex.Replace(strNewValue, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);

                    int linesCount = strValue.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Length;

                    if (linesCount == 1)
                    {
                        dgvItemList.Rows[n].Cells[1].Value = strValue.Trim().ToString();
                        dgvItemList.Rows[n].Height = 32;
                        DataGridViewCell NameCell = dgvItemList[1, n];
                        NameCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        DataGridViewCell PriceCell = dgvItemList[2, n];
                        PriceCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        DataGridViewCell QtyCell = dgvItemList[3, n];
                        QtyCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        DataGridViewCell AmountCell = dgvItemList[4, n];
                        AmountCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    else
                    {
                        dgvItemList.Rows[n].Cells[1].Value = Regex.Replace(strValue, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
                        dgvItemList.AutoResizeRow(n, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
                    }

                    decimal decItemPrice = decimal.Parse(dgvItemList.Rows[n].Cells[2].Value.ToString());
                    if (strPlusOrMinus == "+")
                    {
                        dgvItemList.Rows[n].Cells[2].Value = decItemPrice - decModifierPrice;
                        decimal decAmount = Convert.ToDecimal(dgvItemList.Rows[n].Cells[2].Value) * Convert.ToDecimal(dgvItemList.Rows[n].Cells[3].Value);
                        dgvItemList.Rows[n].Cells[4].Value = decAmount.ToString();
                    }
                    else
                    {
                        dgvItemList.Rows[n].Cells[2].Value = decItemPrice + Math.Abs(decModifierPrice);
                        decimal decAmount = Convert.ToDecimal(dgvItemList.Rows[n].Cells[2].Value) * Convert.ToDecimal(dgvItemList.Rows[n].Cells[3].Value);
                        dgvItemList.Rows[n].Cells[4].Value = decAmount.ToString();
                    }

                    string strRemoveModId = dgvItemList.Rows[n].Cells[13].Value.ToString().Replace("," + iModifierId, string.Empty);
                    dgvItemList.Rows[n].Cells[13].Value = strRemoveModId.ToString();
                }
            }
        }

        #endregion

        public void SetCustomer(int customerId, string strCustomer)
        {
            if (customerId > 0)
            {
                lblCustomerId.Text = customerId.ToString();
                btnSelectedCustomer.Text = "Customer" + Environment.NewLine + strCustomer;
            }
        }

        private void btnChangePrice_Click(object sender, EventArgs e)
        {
            frmChangePrice frmChangePrice = new frmChangePrice(this);
            foreach (DataGridViewRow row in dgvItemList.SelectedRows)
            {
                frmChangePrice.Price = dgvItemList.Rows[row.Index].Cells["clmPrice"].Value.ToString();
            }          
            frmChangePrice.ShowDialog();
        }

        private void btnOpenDrawer_Click(object sender, EventArgs e)
        {
            myCashDrawer.OpenDrawer();
        }


        private void btnPrintLastInvoice_Click(object sender, EventArgs e)
        {
            string strInvoiceNo = Settings.LastInvoiceNo;
            if (strInvoiceNo == "")
            {
                Messages.InformationMessage("No invoices found!");
            }
            else
            {
                if (Settings.PreviewBeforePrint)
                {
                    frmPrintView frmPrintView = new frmPrintView(this);
                    frmPrintView.RefNo = strInvoiceNo;
                    frmPrintView.Report = "Invoice";
                    frmPrintView.ShowDialog();
                }
                else
                {
                    LocalReport report = new LocalReport();
                    report.ReportEmbeddedResource = "cypos.Reports.rptReceipt.rdlc";

                    report.EnableExternalImages = true;
                    report.DisplayName = "Receipt-" + strInvoiceNo;
                    ReportParameter paramLogo = new ReportParameter();
                    paramLogo.Name = "logo_path";
                    paramLogo.Values.Add("file:///" + Application.StartupPath + @"\Images\" + Company.Logo);
                    report.SetParameters(paramLogo);


                    // SÉCURISÉ : Utilise SqlParameter pour invoice_no dans Preview
                    string strSQL = "SELECT tbl_InvoiceHeader.invoice_id,tbl_InvoiceHeader.order_type, tbl_InvoiceHeader.invoice_no, tbl_InvoiceHeader.invoice_date," +
                       "tbl_InvoiceHeader.invoice_time, tbl_InvoiceHeader.table_id,tbl_Tables.table_name," +
                       "tbl_TableLocation.location_name, tbl_InvoiceHeader.no_of_guests, tbl_InvoiceHeader.waiter_id," +
                       "tbl_User.name AS waiter_name,tbl_InvoiceHeader.customer_id," +
                       "CASE WHEN tbl_InvoiceHeader.customer_id = 0 THEN 'Cash' ELSE tbl_Customer.name END AS customer_name," +
                       "tbl_Customer.address AS customer_address, tbl_Customer.city AS customer_city," +
                       "tbl_Customer.phone AS customer_phone, tbl_Customer.email AS customer_email," +
                       "tbl_InvoiceHeader.payment_type, tbl_InvoiceHeader.payment_amount,tbl_InvoiceHeader.paid_amount, tbl_InvoiceHeader.change_amount," +
                       "tbl_InvoiceHeader.due_amount,tbl_InvoiceHeader.discount_rate, tbl_InvoiceHeader.discount_amount," +
                       "tbl_InvoiceHeader.tax1_name, tbl_InvoiceHeader.tax1_rate, tbl_InvoiceHeader.tax1_amount," +
                       "tbl_InvoiceHeader.tax2_name, tbl_InvoiceHeader.tax2_rate, tbl_InvoiceHeader.tax2_amount," +
                       "tbl_InvoiceHeader.sc_rate,tbl_InvoiceHeader.sc_charge,tbl_InvoiceHeader.note, tbl_InvoiceHeader.user_name," +
                       "tbl_InvoiceHeader.log_date,tbl_InvoiceDetail.detail_id, tbl_InvoiceDetail.item_code, tbl_InvoiceDetail.item_name," +
                       "tbl_InvoiceDetail.qty,tbl_InvoiceDetail.selling_price, tbl_InvoiceDetail.total," +
                       "tbl_InvoiceDetail.discount, tbl_InvoiceDetail.tax_apply, tbl_InvoiceDetail.show_kitchen," +
                       "tbl_Company.company_name, tbl_Company.company_address, tbl_Company.company_phone," +
                       "tbl_Company.email AS company_email, tbl_Company.web AS company_web, tbl_Company.tax_no," +
                       "tbl_Company.footer_message, tbl_Company.logo,tbl_Settings.ask_table, tbl_Settings.ask_guest_count," +
                       "tbl_Settings.ask_waiter, tbl_Settings.show_logo, tbl_Settings.enable_sc FROM tbl_InvoiceHeader LEFT JOIN " +
                       "tbl_InvoiceDetail ON tbl_InvoiceHeader.invoice_id = tbl_InvoiceDetail.header_id LEFT JOIN " +
                       "tbl_Tables ON tbl_InvoiceHeader.table_id = tbl_Tables.id LEFT JOIN " +
                       "tbl_TableLocation ON tbl_Tables.location_id = tbl_TableLocation.Id LEFT JOIN " +
                       "tbl_User ON tbl_InvoiceHeader.waiter_id = tbl_User.id LEFT JOIN " +
                       "tbl_Customer ON tbl_InvoiceHeader.customer_id = tbl_Customer.id " +
                       "CROSS JOIN tbl_Company " +
                       "CROSS JOIN tbl_Settings " +
                       "WHERE tbl_InvoiceHeader.invoice_no = @invoiceNo";

                    System.Data.SqlClient.SqlParameter[] parametersPreview = {
                        new System.Data.SqlClient.SqlParameter("@invoiceNo", System.Data.SqlDbType.NVarChar, 50) { Value = strInvoiceNo }
                    };

                    DataTable result = SecureDataAccess.GetDataTable(strSQL, parametersPreview);

                    ReportDataSource reportDSDetail = new ReportDataSource("dsReceipt", result);
                    report.DataSources.Clear();
                    report.DataSources.Add(reportDSDetail);
                    report.Refresh();
                    if (DirectPrint.Print(report, Settings.InvoicePrinter))
                    {
                        Clear();
                    }
                }
            }
        }

        private void txtDiscountRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemList.Rows.Count > 0)
                {
                    double dblDiscountRate = SafeParseLabel(txtDiscountRate.Text);
                    txtDiscountRate.Text = dblDiscountRate.ToString();
                    double dblBeforeSubTotal = SafeParseLabel(lblTotal.Text) - SafeParseLabel(lblTotalDiscount.Text);
                    double dblTotalDiscount = (dblBeforeSubTotal * dblDiscountRate) / 100;

                    double dblDisPlusOverallDiscount = dblTotalDiscount + SafeParseLabel(lblTotalDiscount.Text);
                    dblDisPlusOverallDiscount = Math.Round(dblDisPlusOverallDiscount, 2);
                    lblOverallDiscount.Text = dblDisPlusOverallDiscount.ToString();

                    double dblAfterSubTotal = dblBeforeSubTotal - dblTotalDiscount;
                    dblAfterSubTotal = Math.Round(dblAfterSubTotal, 2);
                    lblSubtotal.Text = dblAfterSubTotal.ToString();

                    //Service Charge
                    double dblScRate = Settings.ServiceChargeRate;
                    double dblServiceCharge = 0;
                    if (Settings.EnableServiceCharge)
                    {
                        dblServiceCharge = (dblAfterSubTotal / 100) * dblScRate;
                    }
                    lblScAmount.Text = Currency.Format(dblServiceCharge);
                    double dblPayable = dblAfterSubTotal + SafeParseLabel(lblTotalTax1.Text) + SafeParseLabel(lblTotalTax2.Text) + dblServiceCharge;
                    dblPayable = Math.Round(dblPayable, 2);
                    lblTotalPayable.Text = Currency.Format(dblPayable);
                }
            }
            catch
            {
                txtDiscountRate.Text = "0";
            }
        }

        private void btnSelectedOT_Click(object sender, EventArgs e)
        {
            frmRecallInvoices frmRecallInvoices = new frmRecallInvoices(this);
            frmRecallInvoices.LoadOrderList(int.Parse(lblOrderTypeId.Text));
            frmRecallInvoices.ShowDialog();
        }
    }
}
