using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace cypos
{
    public partial class frmUserProfile : Form
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


        public frmUserProfile(string UName)
        {
            InitializeComponent();
            lblUserName.Text = UName;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //Load Method
        public void GetUser()
        {
            string strSQL = "SELECT * FROM tbl_User WHERE user_name = @userName";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@userName", System.Data.SqlDbType.NVarChar) { Value = lblUserName.Text }
            };

            DataTable dtUser = SecureDataAccess.GetDataTable(strSQL, parameters);

            txtuid.Text     = dtUser.Rows[0].ItemArray[0].ToString();
            txtUserFullName.Text = dtUser.Rows[0].ItemArray[1].ToString();
            txtAddress.Text = dtUser.Rows[0].ItemArray[2].ToString();
            txtContact.Text = dtUser.Rows[0].ItemArray[3].ToString();
            txtEmail.Text = dtUser.Rows[0].ItemArray[4].ToString();
            dtDob.Value = Convert.ToDateTime(dtUser.Rows[0].ItemArray[5].ToString());
            txtUserName.Text = dtUser.Rows[0].ItemArray[6].ToString();
            txtPassword.Text = dtUser.Rows[0].ItemArray[7].ToString();
            rdbUserRole.Text = dtUser.Rows[0].ItemArray[8].ToString();
            lblImageName.Text = dtUser.Rows[0].ItemArray[9].ToString();

            string strPath = Application.StartupPath + @"\Images\" + dtUser.Rows[0].ItemArray[9].ToString() + "";
            PicUserPhoto.ImageLocation = strPath;            
        }

        //Load event | user info 
        private void UserProfile_Load(object sender, EventArgs e)
        {
            GetUser();
        }

        //Browse Picture Dialog
        private void btnChangePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = @"C:\";
            //openFileDialog1.Title = "Browse Text Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "jpg";
            openFileDialog1.Filter = "GIF Files (*.gif)|*.gif| JPG Files (*.jpg)|*.jpg| PNG Files (*.png)|*.png| All files (*.*)|*.*";

            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

           // openFileDialog1.ReadOnlyChecked = true;
           // openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // textBox1.Text = openFileDialog1.FileName;
                PicUserPhoto.ImageLocation = openFileDialog1.FileName;
                lblFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
            }
        }

        //Update user info
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtUserFullName.Text == "")
            {
                Messages.InformationMessage("Enter full name");
                txtUserFullName.Focus();
            }
            else if (txtAddress.Text == "")
            {
                Messages.InformationMessage("Enter address");
                txtAddress.Focus();
            }
            else if (txtEmail.Text == "")
            {
                Messages.InformationMessage("Enter email address");
                txtEmail.Focus();
            }
            else if (txtContact.Text == "")
            {
                Messages.InformationMessage("Enter contact number");
                txtContact.Focus();
            }
            else if (txtUserName.Text == "")
            {
                Messages.InformationMessage("Enter username");
                txtUserName.Focus();
            }
            else if (txtPassword.Text == "")
            {
                Messages.InformationMessage("Enter password");
                txtPassword.Focus();
            }
            else
            {
                try
                {
                    string imageName;
                    if (lblFileExtension.Text == "user.png")
                    {
                        imageName = lblImageName.Text; 
                    }
                    else
                    {
                        imageName = txtuid.Text + lblFileExtension.Text; 
                    }
                    
                    string hashedPassword = PasswordHelper.HashPassword(txtPassword.Text);

                    string strSQLUpdate = @"UPDATE tbl_User
                                           SET name = @name,
                                               address = @address,
                                               email = @email,
                                               contact = @contact,
                                               dob = @dob,
                                               user_name = @userName,
                                               password = @password,
                                               image_name = @imageName
                                           WHERE user_name = @currentUserName";

                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.NVarChar) { Value = txtUserFullName.Text },
                        new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.NVarChar) { Value = txtAddress.Text },
                        new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar) { Value = txtEmail.Text },
                        new System.Data.SqlClient.SqlParameter("@contact", System.Data.SqlDbType.NVarChar) { Value = txtContact.Text },
                        new System.Data.SqlClient.SqlParameter("@dob", System.Data.SqlDbType.Date) { Value = dtDob.Value },
                        new System.Data.SqlClient.SqlParameter("@userName", System.Data.SqlDbType.NVarChar) { Value = txtUserName.Text },
                        new System.Data.SqlClient.SqlParameter("@password", System.Data.SqlDbType.NVarChar) { Value = hashedPassword },
                        new System.Data.SqlClient.SqlParameter("@imageName", System.Data.SqlDbType.NVarChar) { Value = imageName },
                        new System.Data.SqlClient.SqlParameter("@currentUserName", System.Data.SqlDbType.NVarChar) { Value = lblUserName.Text }
                    };

                    SecureDataAccess.ExecuteNonQuery(strSQLUpdate, parameters);
                    //Messages.UpdatedMessage();

                    //Update Image
                    string strPath = Application.StartupPath + @"\Images\";
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    System.IO.File.Delete(strPath + @"\" + lblImageName.Text);

                    if (!System.IO.Directory.Exists(strPath))
                        System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Images\");
                    string filename = strPath + @"\" + openFileDialog1.SafeFileName;
                    PicUserPhoto.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.IO.File.Move(strPath + @"\" + openFileDialog1.SafeFileName, strPath + @"\" + imageName);
                    this.Close();
                }
                catch (Exception ex)
                {
                    Messages.ExceptionMessage(ex.Message);
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

        private void btnKbName_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtUserFullName);
            frmKeyboard.ShowDialog();
        }

        private void btnKbAddress_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtAddress);
            frmKeyboard.ShowDialog();
        }

        private void btnKbEmail_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtEmail);
            frmKeyboard.ShowDialog();
        }

        private void btnKbContact_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtContact);
            frmKeyboard.ShowDialog();
        }

    }
}
