using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cypos
{
    /// <summary>
    /// Secure data access layer using parameterized queries to prevent SQL injection.
    /// This class replaces the legacy DataAccess.cs for all new and migrated forms.
    /// </summary>
    public static class SecureDataAccess
    {
        #region Connection String

        private static readonly string ConnectionString = GetConnectionString();

        private static readonly ErrorLog errorLog = new ErrorLog();
        private static readonly string ErrorLogPath = AppDomain.CurrentDomain.BaseDirectory + "Errors\\";

        private static string GetConnectionString()
        {
            var cs = ConfigurationManager.ConnectionStrings["cypos.Properties.Settings.CYPOSConnectionString"];
            if (cs != null && !string.IsNullOrEmpty(cs.ConnectionString))
                return cs.ConnectionString;
            return "Data Source=.\\SQLEXPRESS;Initial Catalog=CYPOS;Integrated Security=True;";
        }

        #endregion

        #region Generic Methods with SqlParameter

        /// <summary>
        /// Executes a non-query SQL command (INSERT, UPDATE, DELETE) with optional parameters.
        /// </summary>
        /// <param name="sql">SQL command to execute</param>
        /// <param name="parameters">Optional array of SQL parameters</param>
        /// <returns>Number of rows affected</returns>
        /// <example>
        /// <code>
        /// SqlParameter[] parameters = {
        ///     new SqlParameter("@username", SqlDbType.NVarChar) { Value = "admin" },
        ///     new SqlParameter("@password", SqlDbType.NVarChar) { Value = hashedPassword }
        /// };
        /// int rows = SecureDataAccess.ExecuteNonQuery(sql, parameters);
        /// </code>
        /// </example>
        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                errorLog.Write(ex.Message, "SecureDataAccess.ExecuteNonQuery", ErrorLogPath);
                throw; // Re-throw to let caller handle
            }
        }

        /// <summary>
        /// Executes a SQL query and returns a DataTable with optional parameters.
        /// </summary>
        /// <param name="sql">SQL SELECT query</param>
        /// <param name="parameters">Optional array of SQL parameters</param>
        /// <returns>DataTable containing query results</returns>
        /// <example>
        /// <code>
        /// SqlParameter[] parameters = {
        ///     new SqlParameter("@customerId", SqlDbType.Int) { Value = 123 }
        /// };
        /// DataTable dt = SecureDataAccess.GetDataTable("SELECT * FROM tbl_Customer WHERE customer_id = @customerId", parameters);
        /// </code>
        /// </example>
        public static DataTable GetDataTable(string sql, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                errorLog.Write(ex.Message, "SecureDataAccess.GetDataTable", ErrorLogPath);
                throw;
            }
        }

        /// <summary>
        /// Executes a SQL query and returns a DataSet with optional parameters.
        /// </summary>
        /// <param name="sql">SQL SELECT query</param>
        /// <param name="parameters">Optional array of SQL parameters</param>
        /// <returns>DataSet containing query results</returns>
        public static DataSet GetDataSet(string sql, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        return ds;
                    }
                }
            }
            catch (Exception ex)
            {
                errorLog.Write(ex.Message, "SecureDataAccess.GetDataSet", ErrorLogPath);
                throw;
            }
        }

        /// <summary>
        /// Executes a SQL query and returns a single scalar value with optional parameters.
        /// </summary>
        /// <param name="sql">SQL query returning a single value</param>
        /// <param name="parameters">Optional array of SQL parameters</param>
        /// <returns>The first column of the first row as an object</returns>
        /// <example>
        /// <code>
        /// SqlParameter[] parameters = {
        ///     new SqlParameter("@username", SqlDbType.NVarChar) { Value = "admin" }
        /// };
        /// int count = Convert.ToInt32(SecureDataAccess.ExecuteScalar("SELECT COUNT(*) FROM tbl_User WHERE user_name = @username", parameters));
        /// </code>
        /// </example>
        public static object ExecuteScalar(string sql, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                errorLog.Write(ex.Message, "SecureDataAccess.ExecuteScalar", ErrorLogPath);
                throw;
            }
        }

        #endregion

        #region Transaction Support

        /// <summary>
        /// Executes multiple SQL operations within a transaction.
        /// All operations succeed together or all are rolled back.
        /// </summary>
        /// <param name="operations">Delegate containing operations to execute within transaction</param>
        /// <example>
        /// <code>
        /// SecureDataAccess.ExecuteTransaction((conn, transaction) =>
        /// {
        ///     using (SqlCommand cmd1 = new SqlCommand("INSERT INTO tbl_Invoice ...", conn, transaction))
        ///     {
        ///         cmd1.Parameters.AddWithValue("@total", 100.50);
        ///         cmd1.ExecuteNonQuery();
        ///     }
        ///
        ///     using (SqlCommand cmd2 = new SqlCommand("INSERT INTO tbl_Payment ...", conn, transaction))
        ///     {
        ///         cmd2.Parameters.AddWithValue("@amount", 100.50);
        ///         cmd2.ExecuteNonQuery();
        ///     }
        /// });
        /// </code>
        /// </example>
        public static void ExecuteTransaction(Action<SqlConnection, SqlTransaction> operations)
        {
            if (operations == null)
                throw new ArgumentNullException("operations");

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        operations(conn, transaction);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            transaction.Rollback();
                            errorLog.Write("Transaction rolled back: " + ex.Message,
                                         "SecureDataAccess.ExecuteTransaction", ErrorLogPath);
                        }
                        catch (Exception rollbackEx)
                        {
                            errorLog.Write("Rollback failed: " + rollbackEx.Message,
                                         "SecureDataAccess.ExecuteTransaction.Rollback", ErrorLogPath);
                        }
                        throw;
                    }
                }
            }
        }

        #endregion

        #region Login Code Migration

        public static void EnsureLoginCodeColumn()
        {
            try
            {
                string addCol = @"IF NOT EXISTS (SELECT 1 FROM sys.columns
                    WHERE object_id = OBJECT_ID('tbl_User') AND name = 'login_code')
                    ALTER TABLE tbl_User ADD login_code NVARCHAR(4) NULL";
                ExecuteNonQuery(addCol);

                string updateCodes = @"UPDATE tbl_User SET login_code =
                    RIGHT('00' + CAST(id AS VARCHAR),
                        CASE WHEN id < 10 THEN 2
                             WHEN id < 100 THEN 2
                             WHEN id < 1000 THEN 3
                             ELSE 4 END)
                    WHERE login_code IS NULL";
                ExecuteNonQuery(updateCodes);

                string addIndex = @"IF NOT EXISTS (SELECT 1 FROM sys.indexes
                    WHERE name = 'IX_tbl_User_login_code' AND object_id = OBJECT_ID('tbl_User'))
                    CREATE UNIQUE INDEX IX_tbl_User_login_code ON tbl_User(login_code)
                    WHERE login_code IS NOT NULL";
                ExecuteNonQuery(addIndex);
            }
            catch (Exception ex)
            {
                errorLog.Write(ex.Message, "SecureDataAccess.EnsureLoginCodeColumn", ErrorLogPath);
            }
        }

        #endregion

        #region Specialized Methods for Critical Operations

        public static bool AuthenticateUser(string loginCode, string password, out string userType, out string userName)
        {
            userType = null;
            userName = null;

            try
            {
                string sql = @"SELECT user_name, user_type, password
                              FROM tbl_User
                              WHERE login_code = @loginCode";

                SqlParameter[] parameters = {
                    new SqlParameter("@loginCode", SqlDbType.NVarChar, 4) { Value = loginCode }
                };

                DataTable dt = GetDataTable(sql, parameters);

                if (dt.Rows.Count == 0)
                {
                    return false;
                }

                string storedHash = dt.Rows[0]["password"].ToString();
                userType = dt.Rows[0]["user_type"].ToString();
                userName = dt.Rows[0]["user_name"].ToString();

                bool isValid = PasswordHelper.VerifyPassword(password, storedHash);

                if (isValid && PasswordHelper.NeedsUpgrade(storedHash))
                {
                    try
                    {
                        string newHash = PasswordHelper.HashPassword(password);
                        string updateSql = "UPDATE tbl_User SET password = @newHash WHERE login_code = @loginCode";
                        SqlParameter[] updateParams = {
                            new SqlParameter("@newHash", SqlDbType.NVarChar, 200) { Value = newHash },
                            new SqlParameter("@loginCode", SqlDbType.NVarChar, 4) { Value = loginCode }
                        };
                        ExecuteNonQuery(updateSql, updateParams);
                    }
                    catch (Exception ex)
                    {
                        errorLog.Write(ex.Message, "SecureDataAccess.AuthenticateUser.UpgradeHash", ErrorLogPath);
                    }
                }

                return isValid;
            }
            catch (Exception ex)
            {
                errorLog.Write(ex.Message, "SecureDataAccess.AuthenticateUser", ErrorLogPath);
                return false;
            }
        }

        public static bool AuthenticateUser(string loginCode, string password, out string userType)
        {
            string userName;
            return AuthenticateUser(loginCode, password, out userType, out userName);
        }

        /// <summary>
        /// Checks if a record exists in a table based on field and value.
        /// </summary>
        /// <param name="tableName">Name of the table</param>
        /// <param name="fieldName">Name of the field to check</param>
        /// <param name="fieldValue">Value to check for</param>
        /// <returns>True if record exists, false otherwise</returns>
        public static bool RecordExists(string tableName, string fieldName, string fieldValue)
        {
            try
            {
                // Note: Table and field names cannot be parameterized, so we validate them
                if (string.IsNullOrWhiteSpace(tableName) || string.IsNullOrWhiteSpace(fieldName))
                    throw new ArgumentException("Table name and field name cannot be empty");

                // Basic validation to prevent SQL injection through table/field names
                if (tableName.Contains(" ") || tableName.Contains(";") || tableName.Contains("--") ||
                    fieldName.Contains(" ") || fieldName.Contains(";") || fieldName.Contains("--"))
                {
                    throw new ArgumentException("Invalid table or field name");
                }

                string sql = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = @fieldValue", tableName, fieldName);

                SqlParameter[] parameters = {
                    new SqlParameter("@fieldValue", SqlDbType.NVarChar) { Value = fieldValue }
                };

                int count = Convert.ToInt32(ExecuteScalar(sql, parameters));
                return count > 0;
            }
            catch (Exception ex)
            {
                errorLog.Write(ex.Message, "SecureDataAccess.RecordExists", ErrorLogPath);
                throw;
            }
        }

        #endregion

        #region User Management Methods

        public static bool LoginCodeExists(string loginCode, int excludeUserId)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM tbl_User WHERE login_code = @code AND id != @excludeId";
                SqlParameter[] parameters = {
                    new SqlParameter("@code", SqlDbType.NVarChar, 4) { Value = loginCode },
                    new SqlParameter("@excludeId", SqlDbType.Int) { Value = excludeUserId }
                };
                int count = Convert.ToInt32(ExecuteScalar(sql, parameters));
                return count > 0;
            }
            catch (Exception ex)
            {
                errorLog.Write(ex.Message, "SecureDataAccess.LoginCodeExists", ErrorLogPath);
                throw;
            }
        }

        public static int CreateUser(string username, string password, string userType,
                                    string fullName, string contact, DateTime dob, string imageName)
        {
            return CreateUser(username, password, userType, fullName, contact, dob, imageName, null);
        }

        public static int CreateUser(string username, string password, string userType,
                                    string fullName, string contact, DateTime dob, string imageName, string loginCode)
        {
            try
            {
                string hashedPassword = PasswordHelper.HashPassword(password);

                string sql = @"INSERT INTO tbl_User
                              (user_name, password, user_type, name, contact, dob, image_name, login_code)
                              VALUES
                              (@username, @password, @userType, @fullName, @contact, @dob, @imageName, @loginCode)";

                SqlParameter[] parameters = {
                    new SqlParameter("@username", SqlDbType.NVarChar) { Value = username },
                    new SqlParameter("@password", SqlDbType.NVarChar) { Value = hashedPassword },
                    new SqlParameter("@userType", SqlDbType.NVarChar) { Value = userType },
                    new SqlParameter("@fullName", SqlDbType.NVarChar) { Value = fullName },
                    new SqlParameter("@contact", SqlDbType.NVarChar) { Value = contact ?? (object)DBNull.Value },
                    new SqlParameter("@dob", SqlDbType.DateTime) { Value = dob },
                    new SqlParameter("@imageName", SqlDbType.NVarChar) { Value = imageName ?? (object)DBNull.Value },
                    new SqlParameter("@loginCode", SqlDbType.NVarChar, 4) { Value = loginCode ?? (object)DBNull.Value }
                };

                return ExecuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                errorLog.Write(ex.Message, "SecureDataAccess.CreateUser", ErrorLogPath);
                throw;
            }
        }

        public static int UpdateUser(int userId, string username, string password, string userType,
                                    string fullName, string contact, DateTime dob, string imageName)
        {
            return UpdateUser(userId, username, password, userType, fullName, contact, dob, imageName, null);
        }

        public static int UpdateUser(int userId, string username, string password, string userType,
                                    string fullName, string contact, DateTime dob, string imageName, string loginCode)
        {
            try
            {
                string sql;
                SqlParameter[] parameters;

                if (!string.IsNullOrEmpty(password))
                {
                    string hashedPassword = PasswordHelper.HashPassword(password);

                    sql = @"UPDATE tbl_User
                           SET user_name = @username,
                               password = @password,
                               user_type = @userType,
                               name = @fullName,
                               contact = @contact,
                               dob = @dob,
                               image_name = @imageName,
                               login_code = @loginCode
                           WHERE id = @userId";

                    parameters = new SqlParameter[] {
                        new SqlParameter("@userId", SqlDbType.BigInt) { Value = userId },
                        new SqlParameter("@username", SqlDbType.NVarChar) { Value = username },
                        new SqlParameter("@password", SqlDbType.NVarChar) { Value = hashedPassword },
                        new SqlParameter("@userType", SqlDbType.NVarChar) { Value = userType },
                        new SqlParameter("@fullName", SqlDbType.NVarChar) { Value = fullName },
                        new SqlParameter("@contact", SqlDbType.NVarChar) { Value = contact ?? (object)DBNull.Value },
                        new SqlParameter("@dob", SqlDbType.DateTime) { Value = dob },
                        new SqlParameter("@imageName", SqlDbType.NVarChar) { Value = imageName ?? (object)DBNull.Value },
                        new SqlParameter("@loginCode", SqlDbType.NVarChar, 4) { Value = loginCode ?? (object)DBNull.Value }
                    };
                }
                else
                {
                    sql = @"UPDATE tbl_User
                           SET user_name = @username,
                               user_type = @userType,
                               name = @fullName,
                               contact = @contact,
                               dob = @dob,
                               image_name = @imageName,
                               login_code = @loginCode
                           WHERE id = @userId";

                    parameters = new SqlParameter[] {
                        new SqlParameter("@userId", SqlDbType.BigInt) { Value = userId },
                        new SqlParameter("@username", SqlDbType.NVarChar) { Value = username },
                        new SqlParameter("@userType", SqlDbType.NVarChar) { Value = userType },
                        new SqlParameter("@fullName", SqlDbType.NVarChar) { Value = fullName },
                        new SqlParameter("@contact", SqlDbType.NVarChar) { Value = contact ?? (object)DBNull.Value },
                        new SqlParameter("@dob", SqlDbType.DateTime) { Value = dob },
                        new SqlParameter("@imageName", SqlDbType.NVarChar) { Value = imageName ?? (object)DBNull.Value },
                        new SqlParameter("@loginCode", SqlDbType.NVarChar, 4) { Value = loginCode ?? (object)DBNull.Value }
                    };
                }

                return ExecuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                errorLog.Write(ex.Message, "SecureDataAccess.UpdateUser", ErrorLogPath);
                throw;
            }
        }

        #endregion
    }
}
