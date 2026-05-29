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
    public partial class frmItemPopup : Form
    {
        private frmModifiers _frmModifiers;  

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

        public frmItemPopup(frmModifiers _frm)
        {
             InitializeComponent();
             _frmModifiers = _frm; 
        }

        public void LoadItemList()
        {
            try
            {
                //Item Category
                string strSQL = "SELECT id, category_name FROM tbl_Category WHERE active = 1 ORDER BY category_name";
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
                string strSQL = @"SELECT tbl_Item.*, tbl_Category.category_name
                                 FROM tbl_Item
                                 LEFT JOIN tbl_Category ON tbl_Item.category_id = tbl_Category.id
                                 WHERE item_name LIKE @searchValue + '%'
                                 OR item_code LIKE @searchValue + '%'
                                 OR category_name = @searchValue";

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
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 1;
                    b.FlatAppearance.BorderColor = Color.Gray;
                    b.BackColor = Color.LightYellow;
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
            Button btnItem = sender as Button;
            string strItemCode=btnItem.Tag.ToString();
            if (strItemCode != string.Empty)
            {
                _frmModifiers.SetItemCode(strItemCode);
                this.Close();
            }
        }

        private void frmItemPopup_Load(object sender, EventArgs e)
        {
            try
            {
                LoadItemList();
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

        private void btnKbSearch_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtSearchItem);
            frmKeyboard.ShowDialog();
        }
    }
}
