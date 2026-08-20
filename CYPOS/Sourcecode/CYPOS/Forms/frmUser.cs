using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace cypos
{
    public partial class frmUser : Form
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

        public frmUser()
        {
            InitializeComponent();             
        }

        // Get User ID from ManagerUser form
        public string Uid
        {
            set { lblUid.Text = value; }
            get { return lblUid.Text; }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        } 
        

        // Load User Info for Update
        public void GetUserById(string Uid)
        {
            string strSQL = "SELECT * FROM tbl_User WHERE id = @userId";

            System.Data.SqlClient.SqlParameter[] parameters = {
                new System.Data.SqlClient.SqlParameter("@userId", System.Data.SqlDbType.Int) { Value = int.Parse(Uid) }
            };

            DataTable dtUser = SecureDataAccess.GetDataTable(strSQL, parameters);

            //lblUid.Text = dtUser.Rows[0]["id"].ToString();
            txtUserFullName.Text = dtUser.Rows[0]["name"].ToString();
            txtAddress.Text = dtUser.Rows[0]["address"].ToString();
            txtEmailaddress.Text = dtUser.Rows[0]["email"].ToString();
            txtContact.Text = dtUser.Rows[0]["contact"].ToString();
            dtDOB.Value =DateTime.Parse(dtUser.Rows[0]["dob"].ToString());
            txtUsername.Text = dtUser.Rows[0]["user_name"].ToString();
            // SECURITY FIX: Do NOT display the hashed password - leave field empty for updates
            txtPassword.Text = string.Empty;
            lblImageName.Text =dtUser.Rows[0]["image_name"].ToString();
                        
            string path = Application.StartupPath + @"\Images\" + dtUser.Rows[0]["image_name"].ToString() + "";
            pbxUserImage.ImageLocation = path;
            pbxUserImage.InitialImage.Dispose();

            if (dtUser.Rows[0]["user_type"].ToString() == "Admin")
            {
                rdbAdmin.Checked = true;
            }
            else if (dtUser.Rows[0]["user_type"].ToString() == "Cashier")
            {
                rdbCashier.Checked = true;
            }
            else if (dtUser.Rows[0]["user_type"].ToString() == "Waiter")
            {
                rdbWaiter.Checked = true;
            }
        }
       
        private int GetNextUserId()
        {
            int NextId;

            string sql = "SELECT id FROM tbl_User ORDER BY id DESC";
            DataTable dt = SecureDataAccess.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                NextId = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString()) + 1;
            }
            else
            {
                NextId = 1;
            }
            return NextId;
        }


        private void frmUser_Load(object sender, EventArgs e)
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


        public void LoadUserList(string SearchText="")
        {
            floUserList.Controls.Clear();
            string strSQL=string.Empty;
            string img_directory = Application.StartupPath + @"\Images\";
            string[] files = Directory.GetFiles(img_directory, "*.jpg *.png"); // "*.png"

            try
            {
                DataTable dt;
                if (SearchText != string.Empty)
                {
                    strSQL = @"SELECT * FROM tbl_User WHERE name like @searchText + '%'
                              OR user_name LIKE @searchText + '%'
                              OR contact LIKE @searchText + '%'";

                    System.Data.SqlClient.SqlParameter[] parameters = {
                        new System.Data.SqlClient.SqlParameter("@searchText", System.Data.SqlDbType.NVarChar) { Value = SearchText }
                    };

                    dt = SecureDataAccess.GetDataTable(strSQL, parameters);
                }
                else
                {
                    strSQL = "SELECT * FROM tbl_User";
                    dt = SecureDataAccess.GetDataTable(strSQL);
                }

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button btnUser = new Button();
                    btnUser.Tag = dataReader["id"];
                    btnUser.Click += new EventHandler(btnUser_Click);
                    btnUser.Name = dataReader["name"].ToString() + "\n Contact: " + dataReader["contact"].ToString();

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(128, 128);

                    // SECURITY FIX: Check if image exists before trying to load it
                    string imagePath = img_directory + dataReader["image_name"].ToString();
                    if (File.Exists(imagePath))
                    {
                        try
                        {
                            il.Images.Add(Image.FromFile(imagePath));
                            btnUser.Image = il.Images[0];
                        }
                        catch
                        {
                            // Use default no-image if loading fails
                            btnUser.Image = cypos.Properties.Resources.no_image;
                        }
                    }
                    else
                    {
                        // Use default no-image if file doesn't exist
                        btnUser.Image = cypos.Properties.Resources.no_image;
                    }

                    btnUser.Margin = new Padding(2, 2, 2, 2);

                    btnUser.Size = new Size(148, 200);

                    btnUser.Text += "\n UId: " + dataReader["user_name"];
                    btnUser.Text += "\n Name: " + dataReader["name"].ToString();

                    btnUser.Font = new Font("Tahoma", 9, FontStyle.Regular, GraphicsUnit.Point);
                    btnUser.TextAlign = ContentAlignment.BottomCenter;
                    btnUser.TextImageRelation = TextImageRelation.ImageAboveText;
                    btnUser.FlatStyle = FlatStyle.Flat;
                    btnUser.FlatAppearance.BorderSize = 0;
                    floUserList.Controls.Add(btnUser);
                    currentImage++;
                }
                lblRows.Text = "Total " + dt.Rows.Count.ToString() + " Users Found";
            }
            catch (Exception ex)
            {
                Messages.ExceptionMessage(ex.Message);
            }
        }


        protected void btnUser_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string s;
            s = b.Tag.ToString();

            this.Uid = s;
        }


        private void Clear()
        {
            lblUid.Text = "-";
            txtUserFullName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmailaddress.Text = string.Empty;
            lblImageName.Text = string.Empty;
            dtDOB.Text = string.Empty;
            rdbAdmin.Checked = false;
            rdbCashier.Checked = false;
            rdbWaiter.Checked = false;
            pbxUserImage.Image = cypos.Properties.Resources.no_image;
            btnSave.BackgroundImage = cypos.Properties.Resources.save100x45;
            LoadUserList();
            txtUserFullName.Focus();
        }
        

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtUserFullName.Text == "" )
            {
                Messages.InformationMessage("Please enter user's full name");
                txtUserFullName.Focus();
            }
            else if (txtAddress.Text == "")
            {
                Messages.InformationMessage("Please enter address");
                txtAddress.Focus();
            }
            else if (txtContact.Text == ""  )
            {
                Messages.InformationMessage("Please enter contact nos.");
                txtContact.Focus();
            }
            else if (txtEmailaddress.Text == "")
            {
                Messages.InformationMessage("Please enter email address");
                txtEmailaddress.Focus();
            }
            else if (txtUsername.Text == "")
            {
                Messages.InformationMessage("Please enter user name");
                txtUsername.Focus();
            }
            else if (txtPassword.Text == "" && lblUid.Text == "-")
            {
                Messages.InformationMessage("Please enter password");
                txtPassword.Focus();
            }
            else if (txtPassword.Text != "" && !ValidatePassword(txtPassword.Text))
            {
                txtPassword.Focus();
            }
            else if (!InputValidator.IsValidUsername(txtUsername.Text))
            {
                Messages.InformationMessage("Username must be 3-50 characters (letters, numbers, underscore)");
                txtUsername.Focus();
            }
            else if (!rdbAdmin.Checked && !rdbCashier.Checked && !rdbWaiter.Checked)
            {
                Messages.InformationMessage("Please select user type");
            }
            else
            {
                try
                {                     
                    
                    string strUserType=string.Empty;
                    if (rdbAdmin.Checked)
                    {
                        strUserType = "Admin";
                    }
                    else if (rdbCashier.Checked)
                    {
                        strUserType = "Cashier";
                    }
                    else if (rdbWaiter.Checked)
                    {
                        strUserType = "Waiter";
                    }
                    if(lblUid.Text == "-")
                    {
                        // CREATE NEW USER with secure password hashing
                        string strImageName = txtUsername.Text + lblFileExtension.Text;

                        // Use SecureDataAccess with parameterized query and password hashing
                        string strSQLInsert = @"INSERT INTO tbl_User (name, address, contact, email, dob, user_name, password, user_type, image_name)
                                               VALUES (@name, @address, @contact, @email, @dob, @userName, @password, @userType, @imageName)";

                        // Hash the password before storing
                        string hashedPassword = PasswordHelper.HashPassword(txtPassword.Text);

                        System.Data.SqlClient.SqlParameter[] parameters = {
                            new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.NVarChar, 100) { Value = txtUserFullName.Text },
                            new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.NVarChar, 200) { Value = txtAddress.Text ?? (object)System.DBNull.Value },
                            new System.Data.SqlClient.SqlParameter("@contact", System.Data.SqlDbType.NVarChar, 20) { Value = txtContact.Text ?? (object)System.DBNull.Value },
                            new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar, 100) { Value = txtEmailaddress.Text ?? (object)System.DBNull.Value },
                            new System.Data.SqlClient.SqlParameter("@dob", System.Data.SqlDbType.Date) { Value = dtDOB.Value },
                            new System.Data.SqlClient.SqlParameter("@userName", System.Data.SqlDbType.NVarChar, 50) { Value = txtUsername.Text },
                            new System.Data.SqlClient.SqlParameter("@password", System.Data.SqlDbType.NVarChar, 256) { Value = hashedPassword },
                            new System.Data.SqlClient.SqlParameter("@userType", System.Data.SqlDbType.NVarChar, 20) { Value = strUserType },
                            new System.Data.SqlClient.SqlParameter("@imageName", System.Data.SqlDbType.NVarChar, 100) { Value = strImageName }
                        };

                        SecureDataAccess.ExecuteNonQuery(strSQLInsert, parameters);
                        AuditLog.LogUserAction("CREATE", "User", txtUsername.Text);

                        //Picture Upload
                        string strPath = Application.StartupPath + @"\Images\";
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        System.IO.File.Delete(strPath + @"\" + strImageName);

                        if (!System.IO.Directory.Exists(strPath))
                            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Images\");
                        string filename = strPath + @"\" + openFileDialog1.SafeFileName;
                        pbxUserImage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                        System.IO.File.Move(strPath + @"\" + openFileDialog1.SafeFileName, strPath + @"\" + strImageName);
                        Messages.SavedMessage();
                        Clear();
                    }
                    else // Update info
                    {
                        // UPDATE EXISTING USER with secure password hashing
                        string imageName;
                        if (lblFileExtension.Text == "user.png")
                        {
                            imageName = lblImageName.Text;  //Unchange pictures
                        }
                        else  //When change
                        {
                            imageName = lblImageName.Text;
                        }

                        // Check if password was changed
                        // Note: If the field is empty or unchanged, we should not update the password
                        string strSQLUpdate;
                        System.Data.SqlClient.SqlParameter[] parameters;

                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            // Password is being updated - hash it
                            string hashedPassword = PasswordHelper.HashPassword(txtPassword.Text);

                            strSQLUpdate = @"UPDATE tbl_User
                                            SET name = @name,
                                                address = @address,
                                                email = @email,
                                                contact = @contact,
                                                dob = @dob,
                                                user_name = @userName,
                                                password = @password,
                                                image_name = @imageName,
                                                user_type = @userType
                                            WHERE id = @userId";

                            parameters = new System.Data.SqlClient.SqlParameter[] {
                                new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.NVarChar, 100) { Value = txtUserFullName.Text },
                                new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.NVarChar, 200) { Value = txtAddress.Text ?? (object)System.DBNull.Value },
                                new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar, 100) { Value = txtEmailaddress.Text ?? (object)System.DBNull.Value },
                                new System.Data.SqlClient.SqlParameter("@contact", System.Data.SqlDbType.NVarChar, 20) { Value = txtContact.Text ?? (object)System.DBNull.Value },
                                new System.Data.SqlClient.SqlParameter("@dob", System.Data.SqlDbType.Date) { Value = dtDOB.Value },
                                new System.Data.SqlClient.SqlParameter("@userName", System.Data.SqlDbType.NVarChar, 50) { Value = txtUsername.Text },
                                new System.Data.SqlClient.SqlParameter("@password", System.Data.SqlDbType.NVarChar, 256) { Value = hashedPassword },
                                new System.Data.SqlClient.SqlParameter("@imageName", System.Data.SqlDbType.NVarChar, 100) { Value = imageName },
                                new System.Data.SqlClient.SqlParameter("@userType", System.Data.SqlDbType.NVarChar, 20) { Value = strUserType },
                                new System.Data.SqlClient.SqlParameter("@userId", System.Data.SqlDbType.Int) { Value = Convert.ToInt32(lblUid.Text) }
                            };
                        }
                        else
                        {
                            // Password not being updated - exclude from UPDATE
                            strSQLUpdate = @"UPDATE tbl_User
                                            SET name = @name,
                                                address = @address,
                                                email = @email,
                                                contact = @contact,
                                                dob = @dob,
                                                user_name = @userName,
                                                image_name = @imageName,
                                                user_type = @userType
                                            WHERE id = @userId";

                            parameters = new System.Data.SqlClient.SqlParameter[] {
                                new System.Data.SqlClient.SqlParameter("@name", System.Data.SqlDbType.NVarChar, 100) { Value = txtUserFullName.Text },
                                new System.Data.SqlClient.SqlParameter("@address", System.Data.SqlDbType.NVarChar, 200) { Value = txtAddress.Text ?? (object)System.DBNull.Value },
                                new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.NVarChar, 100) { Value = txtEmailaddress.Text ?? (object)System.DBNull.Value },
                                new System.Data.SqlClient.SqlParameter("@contact", System.Data.SqlDbType.NVarChar, 20) { Value = txtContact.Text ?? (object)System.DBNull.Value },
                                new System.Data.SqlClient.SqlParameter("@dob", System.Data.SqlDbType.Date) { Value = dtDOB.Value },
                                new System.Data.SqlClient.SqlParameter("@userName", System.Data.SqlDbType.NVarChar, 50) { Value = txtUsername.Text },
                                new System.Data.SqlClient.SqlParameter("@imageName", System.Data.SqlDbType.NVarChar, 100) { Value = imageName },
                                new System.Data.SqlClient.SqlParameter("@userType", System.Data.SqlDbType.NVarChar, 20) { Value = strUserType },
                                new System.Data.SqlClient.SqlParameter("@userId", System.Data.SqlDbType.Int) { Value = Convert.ToInt32(lblUid.Text) }
                            };
                        }

                        SecureDataAccess.ExecuteNonQuery(strSQLUpdate, parameters);
                        AuditLog.LogUserAction("UPDATE", "User", lblUid.Text);

                        //Update image
                        if (lblFileExtension.Text != "user.png")
                        {
                            pbxUserImage.InitialImage.Dispose();
                            string path = Application.StartupPath + @"\Images\";
                            System.IO.File.Delete(path + @"\" + lblImageName.Text);
                            if (!System.IO.Directory.Exists(path))
                                System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Images\");
                            string filename = path + @"\" + openFileDialog1.SafeFileName;
                            pbxUserImage.Image.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                            System.IO.File.Move(path + @"\" + openFileDialog1.SafeFileName, path + @"\" + imageName);
                        }

                        //Messages.UpdatedMessage();
                        Clear();
                    }
 
                }
                catch (Exception ex)
                {
                    Messages.ExceptionMessage(ex.Message);
                }
            }
        }

        // Reset  
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
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
                //lblImageName.Text = openFileDialog1.FileName;
                pbxUserImage.ImageLocation = openFileDialog1.FileName;
                lblFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
            }
        }

        private void txtEmailaddress_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            if (txtEmailaddress.Text.Length > 0 && txtEmailaddress.Text.Trim().Length != 0)
            {
                if (!rEmail.IsMatch(txtEmailaddress.Text.Trim()))
                {
                    lblEmailerrormsg.Visible = true;
                    lblEmailerrormsg.Text = "Invalid Email address";
                    txtEmailaddress.SelectAll();
                }
                else
                {
                    btnSave.Enabled = true;
                    lblEmailerrormsg.Visible = false;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = Messages.DeleteMessage();

            if (result ==true)
            {

                if (lblUid.Text == "-")
                {
                    Messages.InformationMessage("The record could not be deleted.");
                }
                else
                {
                    try
                    {
                        int userId = 0;
                        int.TryParse(lblUid.Text, out userId);

                        string sql = "DELETE FROM tbl_User WHERE (id = @userId)";

                        System.Data.SqlClient.SqlParameter[] parameters = {
                            new System.Data.SqlClient.SqlParameter("@userId", System.Data.SqlDbType.Int) { Value = userId }
                        };

                        SecureDataAccess.ExecuteNonQuery(sql, parameters);
                        AuditLog.LogUserAction("DELETE", "User", lblUid.Text);

                        pbxUserImage.InitialImage.Dispose();
                        string path = Application.StartupPath + @"\Images\";
                        System.IO.File.Delete(path + @"\" + lblImageName.Text);

                        Messages.DeletedMessage();
                        Clear();

                    }
                    catch (Exception ex)
                    {
                        Messages.ExceptionMessage(ex.Message);
                    }
                }
            }
        }

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            LoadUserList(txtSearchUser.Text);
        }

        private void lblUid_TextChanged(object sender, EventArgs e)
        {
            if (lblUid.Text != "-")
            {
                GetUserById(lblUid.Text);
                btnSave.BackgroundImage = cypos.Properties.Resources.update100x45;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                pbxUserImage.Image = cypos.Properties.Resources.no_image;
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

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MoveForm.ReleaseCapture();
                MoveForm.SendMessage(Handle, MoveForm.WM_NCLBUTTONDOWN, MoveForm.HT_CAPTION, 0);
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

        private void btnKbContactNo_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtContact);
            frmKeyboard.ShowDialog();
        }

        private void btnKbEmail_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtEmailaddress);
            frmKeyboard.ShowDialog();
        }

        private void btnKbUserName_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtUsername);
            frmKeyboard.ShowDialog();
        }

        private void btnKbPassword_Click(object sender, EventArgs e)
        {
            frmKeyboard frmKeyboard = new frmKeyboard(txtPassword);
            frmKeyboard.ShowDialog();
        }

        private bool ValidatePassword(string password)
        {
            string errorMessage;
            if (!InputValidator.IsValidPassword(password, out errorMessage))
            {
                Messages.InformationMessage(errorMessage);
                return false;
            }
            return true;
        }
    }
}
