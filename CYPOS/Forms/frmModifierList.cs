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
    public partial class frmModifierList : Form
    {
        private frmMain _frmMain;

        string strItemCode;
        string strItemName;
        string strModifierIds;
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

        public frmModifierList(frmMain _frm)
        {
            InitializeComponent();
            _frmMain = _frm; 
        }

        public string ItemCode
        {
            set { strItemCode = value; }
            get { return strItemCode; }
        }

        public string ItemName
        {
            set { strItemName = value; }
            get { return strItemName; }
        }

        public string ModifierIds
        {
            set { strModifierIds = value; }
            get { return strModifierIds; }
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

        private void frmModifierList_Load(object sender, EventArgs e)
        {
            tbModifier.TabPages.Remove(tpItemModifier);
            tbModifier.TabPages.Remove(tpAllModifier);
            LoadItemModifier(strItemCode, strItemName);
            LoadAllModifier(strItemCode, strItemName);
        }

        private void LoadItemModifier(string strItemCode, string strItemName)
        {
            tbModifier.TabPages.Clear();
            try
            {
                string sql = "SELECT * FROM tbl_Modifier WHERE item_code = @itemCode";

                System.Data.SqlClient.SqlParameter[] parameters = {
                    new System.Data.SqlClient.SqlParameter("@itemCode", System.Data.SqlDbType.NVarChar) { Value = strItemCode }
                };

                DataTable dt = SecureDataAccess.GetDataTable(sql, parameters);
                if (dt.Rows.Count > 0)
                {
                    tbModifier.TabPages.Add(tpItemModifier);
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button btnModifier = new Button();

                    btnModifier.Click += new EventHandler(btnItemModifier_Click);

                    btnModifier.Margin = new Padding(3, 3, 3, 3);

                    btnModifier.Size = new Size(100, 100);
                    btnModifier.Image = (Image)(new Bitmap(cypos.Properties.Resources.modifier, new Size(32, 32)));

                    btnModifier.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
                    btnModifier.TextAlign = ContentAlignment.MiddleCenter;
                    btnModifier.TextImageRelation = TextImageRelation.ImageAboveText;

                    btnModifier.Tag = dataReader["id"] + "," + dataReader["item_code"] + "," + dataReader["price"] + "," + dataReader["price_method"];

                    btnModifier.Text = dataReader["name"].ToString();

                    string strPlusOrMinus = dataReader["price_method"].ToString();

                    if (strPlusOrMinus == "+")
                    {
                        btnModifier.Text += "\n Price: " + dataReader["price"];
                    }
                    else
                    {
                        btnModifier.Text += "\n Price: " + dataReader["price_method"] + dataReader["price"];
                    }

                    string strModifier = btnModifier.Tag.ToString();
                    string[] modStr = strModifier.Split(',');

                    int intModifierId = int.Parse(modStr[0].ToString());
                    string strCode = modStr[1].ToString();

                    string[] modArray = strModifierIds.Split(',');

                    for (int x = 1; x < modArray.Length; x++)
                    {
                        int intX = int.Parse(modArray[x].ToString());
                        if (intModifierId == intX)
                        {
                            btnModifier.BackgroundImage = cypos.Properties.Resources.modifier_button;
                        }
                    }

                    btnModifier.Padding = new Padding(3, 3, 3, 3);

                    floItemModifier.Controls.Add(btnModifier);
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        public void LoadAllModifier(string strItemCode, string strItemName)
        {
            try
            {
                string sql = "SELECT * FROM tbl_Modifier WHERE item_code = ''";
                DataTable dt = SecureDataAccess.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    tbModifier.TabPages.Add(tpAllModifier);
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button btnAllModifier = new Button();
                    btnAllModifier.Tag = dataReader["id"] + "," + strItemCode + "," + dataReader["price"] + "," + dataReader["price_method"];
                    btnAllModifier.Text = dataReader["name"].ToString();
                    btnAllModifier.Click += new EventHandler(btnAllModifier_Click);

                    btnAllModifier.Margin = new Padding(3, 3, 3, 3);

                    btnAllModifier.Size = new Size(100, 100);
                    btnAllModifier.Image = (Image)(new Bitmap(cypos.Properties.Resources.modifier, new Size(32, 32)));

                    btnAllModifier.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
                    btnAllModifier.TextAlign = ContentAlignment.MiddleCenter;
                    btnAllModifier.TextImageRelation = TextImageRelation.ImageAboveText;

                    btnAllModifier.Text = dataReader["name"].ToString();
                    string strPlusOrMinus = dataReader["price_method"].ToString();

                    if (strPlusOrMinus == "+")
                    {
                        btnAllModifier.Text += "\n Price: " + dataReader["price"];
                    }
                    else
                    {
                        btnAllModifier.Text += "\n Price: " + dataReader["price_method"] + dataReader["price"];
                    }
                    string strModifier = btnAllModifier.Tag.ToString();
                    string[] modStr = strModifier.Split(',');

                    int intModifierId = int.Parse(modStr[0].ToString());
                    string strCode = modStr[1].ToString();

                    string[] modArray = strModifierIds.Split(',');

                    for (int x = 1; x < modArray.Length; x++)
                    {
                        int intX = int.Parse(modArray[x].ToString());
                        if (intModifierId == intX)
                        {
                            btnAllModifier.BackgroundImage = cypos.Properties.Resources.modifier_button;
                        }
                    }

                    btnAllModifier.Padding = new Padding(3, 3, 3, 3);
                    floAllModifier.Controls.Add(btnAllModifier);
                }
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }

        protected void btnItemModifier_Click(object sender, EventArgs e)
        {
            Button btnClicked = sender as Button;

            string strModifier = btnClicked.Tag.ToString();
            string[] modStr = strModifier.Split(',');

            int intModifierId = int.Parse(modStr[0].ToString());
            string strItemCode = modStr[1].ToString();

            string strModName = btnClicked.Text.Split(new[] { '\r', '\n' }).FirstOrDefault();

            string strModifierName = strModName;
            decimal decModifierPrice = decimal.Parse(modStr[2].ToString());
            string strPlusOrMinus = modStr[3].ToString();

            // Default tax rate 
            double TaxRate = Convert.ToDouble(TaxValue.Tax1Rate);

            if (btnClicked.BackgroundImage == null)
            {
                _frmMain.AddRemoveModifiers(strItemCode, strModifierName, btnClicked.BackgroundImage, strPlusOrMinus, decModifierPrice, intModifierId);
                btnClicked.BackgroundImage = cypos.Properties.Resources.modifier_button;
            }
            else
            {
                _frmMain.AddRemoveModifiers(strItemCode, strModifierName, btnClicked.BackgroundImage, strPlusOrMinus, decModifierPrice, intModifierId);
                btnClicked.BackgroundImage = null;
            }
            this.Close();
            //Button btnClicked = sender as Button;

            //string strModifier = btnClicked.Tag.ToString();
            //string[] modStr = strModifier.Split(',');

            //int intModifierId = int.Parse(modStr[0].ToString());
            //string strItemCode = modStr[1].ToString();

            //string strModName = btnClicked.Text.Split(new[] { '\r', '\n' }).FirstOrDefault();

            //string strModifierName = strModName;
            //decimal decModifierPrice = decimal.Parse(modStr[2].ToString());
            //string strPlusOrMinus = modStr[3].ToString();

            //// Default tax rate 
            //double TaxRate = Convert.ToDouble(TaxValue.Tax1Rate);

            //int n = FindItemById(strItemCode);

            //if (n > -1)
            //{
            //    dgvSalesItemList.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //    if (btnClicked.BackgroundImage == null) //Add modifiers
            //    {
            //        dgvSalesItemList.Rows[n].Cells[1].Value = (dgvSalesItemList.Rows[n].Cells[1].Value.ToString() + Environment.NewLine + " > " + strModifierName.ToString());
            //        decimal decItemPrice = decimal.Parse(dgvSalesItemList.Rows[n].Cells[2].Value.ToString());
            //        if (strPlusOrMinus == "+")
            //        {
            //            dgvSalesItemList.Rows[n].Cells[2].Value = decItemPrice + decModifierPrice;
            //            decimal decAmount = Convert.ToDecimal(dgvSalesItemList.Rows[n].Cells[2].Value) * Convert.ToDecimal(dgvSalesItemList.Rows[n].Cells[3].Value);
            //            dgvSalesItemList.Rows[n].Cells[4].Value = decAmount.ToString();
            //        }
            //        else
            //        {
            //            dgvSalesItemList.Rows[n].Cells[2].Value = decItemPrice - Math.Abs(decModifierPrice);
            //            decimal decAmount = Convert.ToDecimal(dgvSalesItemList.Rows[n].Cells[2].Value) * Convert.ToDecimal(dgvSalesItemList.Rows[n].Cells[3].Value);
            //            dgvSalesItemList.Rows[n].Cells[4].Value = decAmount.ToString();
            //        }

            //        string strModId = dgvSalesItemList.Rows[n].Cells[10].Value.ToString();
            //        dgvSalesItemList.Rows[n].Cells[10].Value = "";
            //        dgvSalesItemList.Rows[n].Cells[10].Value = strModId + "," + intModifierId;

            //        dgvSalesItemList.AutoResizeRow(n, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
            //        DataGridViewCell NameCell = dgvSalesItemList[1, n];
            //        NameCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
            //        DataGridViewCell PriceCell = dgvSalesItemList[2, n];
            //        PriceCell.Style.Alignment = DataGridViewContentAlignment.TopRight;
            //        DataGridViewCell QtyCell = dgvSalesItemList[3, n];
            //        QtyCell.Style.Alignment = DataGridViewContentAlignment.TopCenter;
            //        DataGridViewCell AmountCell = dgvSalesItemList[4, n];
            //        AmountCell.Style.Alignment = DataGridViewContentAlignment.TopRight;

            //        btnClicked.BackgroundImage = cypos.Properties.Resources.modifier_button;
            //    }
            //    else //Remove Modifiers
            //    {
            //        string ItemCellValue = dgvSalesItemList.Rows[n].Cells[1].Value.ToString();
            //        //string strNewValue=ItemCellValue.Replace(" > " + btnClicked.Text,"");
            //        string strNewValue = ItemCellValue.Replace(" > " + btnClicked.Text.Split(new[] { '\r', '\n' }).FirstOrDefault(), "");


            //        string strValue = Regex.Replace(strNewValue, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);

            //        if (Regex.Matches(strValue, @"[\S]+").Count == 1)
            //        {
            //            dgvSalesItemList.Rows[n].Cells[1].Value = strValue.Trim().ToString();
            //            dgvSalesItemList.Rows[n].Height = 32;
            //            DataGridViewCell NameCell = dgvSalesItemList[1, n];
            //            NameCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //            DataGridViewCell PriceCell = dgvSalesItemList[2, n];
            //            PriceCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //            DataGridViewCell QtyCell = dgvSalesItemList[3, n];
            //            QtyCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //            DataGridViewCell AmountCell = dgvSalesItemList[4, n];
            //            AmountCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //        }
            //        else
            //        {
            //            dgvSalesItemList.Rows[n].Cells[1].Value = Regex.Replace(strValue, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
            //            dgvSalesItemList.AutoResizeRow(n, DataGridViewAutoSizeRowMode.AllCellsExceptHeader);
            //        }

            //        btnClicked.BackgroundImage = null;

            //        //Item Price +- Modifier

            //        decimal decItemPrice = decimal.Parse(dgvSalesItemList.Rows[n].Cells[2].Value.ToString());
            //        if (strPlusOrMinus == "+")
            //        {
            //            dgvSalesItemList.Rows[n].Cells[2].Value = decItemPrice - decModifierPrice;
            //            decimal decAmount = Convert.ToDecimal(dgvSalesItemList.Rows[n].Cells[2].Value) * Convert.ToDecimal(dgvSalesItemList.Rows[n].Cells[3].Value);
            //            dgvSalesItemList.Rows[n].Cells[4].Value = decAmount.ToString();
            //        }
            //        else
            //        {
            //            dgvSalesItemList.Rows[n].Cells[2].Value = decItemPrice + Math.Abs(decModifierPrice);
            //            decimal decAmount = Convert.ToDecimal(dgvSalesItemList.Rows[n].Cells[2].Value) * Convert.ToDecimal(dgvSalesItemList.Rows[n].Cells[3].Value);
            //            dgvSalesItemList.Rows[n].Cells[4].Value = decAmount.ToString();
            //        }

            //        string strRemoveModId = dgvSalesItemList.Rows[n].Cells[10].Value.ToString().Replace("," + intModifierId, string.Empty);
            //        dgvSalesItemList.Rows[n].Cells[10].Value = strRemoveModId.ToString();
            //    }
            //}
        }

        protected void btnAllModifier_Click(object sender, EventArgs e)
        {
            Button btnClicked = sender as Button;

            string strModifier = btnClicked.Tag.ToString();
            string[] modStr = strModifier.Split(',');

            int intModifierId = int.Parse(modStr[0].ToString());
            string strItemCode = modStr[1].ToString();

            string strModName = btnClicked.Text.Split(new[] { '\r', '\n' }).FirstOrDefault();

            string strModifierName = strModName;
            decimal decModifierPrice = decimal.Parse(modStr[2].ToString());
            string strPlusOrMinus = modStr[3].ToString();

            // Default tax rate 
            double TaxRate = Convert.ToDouble(TaxValue.Tax1Rate);
            if (btnClicked.BackgroundImage==null)
            {
                _frmMain.AddRemoveModifiers(strItemCode, strModifierName, btnClicked.BackgroundImage, strPlusOrMinus, decModifierPrice, intModifierId);
                 btnClicked.BackgroundImage = cypos.Properties.Resources.modifier_button;
            }
            else 
            {
                _frmMain.AddRemoveModifiers(strItemCode, strModifierName, btnClicked.BackgroundImage, strPlusOrMinus, decModifierPrice, intModifierId);
                btnClicked.BackgroundImage = null;
            }
            this.Close();
        }
    }
}
