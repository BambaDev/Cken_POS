using System;
using System.Data;
using System.Data.SqlClient;

namespace cypos
{
    /// <summary>
    /// Secure data access layer using parameterized queries to prevent SQL injection.
    /// This class replaces the legacy DataAccess.cs for all new and migrated forms.
    /// </summary>
    /// <remarks>
    /// Created as part of Phase 1: Security and Bug Fixes
    /// See docs/adr/0001-migration-securedataaccess-phase1.md for design decisions
    /// </remarks>
    public static class SecureDataAccess
    {
        #region Connection String

        private static readonly string ConnectionString =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=CYPOS;Integrated Security=True;";

        private static readonly ErrorLog errorLog = new ErrorLog();
        private static readonly string ErrorLogPath = AppDomain.CurrentDomain.BaseDirectory + "Errors\\";

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

        #region Specialized Methods for Critical Operations

        /// <summary>
        /// Authenticates a user with username and password.
        /// Uses password hashing for secure authentication.
        /// </summary>
        /// <param name="username">Username to authenticate</param>
        /// <param name="password">Plain text password to verify</param>
        /// <param name="userType">Output parameter containing user type (Admin, Cashier, Waiter)</param>
        /// <returns>True if authentication successful, false otherwise</returns>
        public static bool AuthenticateUser(string username, string password, out string userType)
        {
            userType = null;

            try
            {
                string sql = @"SELECT user_type, password
                              FROM tbl_User
                              WHERE user_name = @username";

                SqlParameter[] parameters = {
                    new SqlParameter("@username", SqlDbType.NVarChar, 50) { Value = username }
                };

                DataTable dt = GetDataTable(sql, parameters);

                if (dt.Rows.Count == 0)
                {
                    return false;
                }

                string storedHash = dt.Rows[0]["password"].ToString();
                userType = dt.Rows[0]["user_type"].ToString();

                bool isValid = PasswordHelper.VerifyPassword(password, storedHash);

                if (isValid && PasswordHelper.NeedsUpgrade(storedHash))
                {
                    try
                    {
                        string newHash = PasswordHelper.HashPassword(password);
                        string updateSql = "UPDATE tbl_User SET password = @newHash WHERE user_name = @username";
                        SqlParameter[] updateParams = {
                            new SqlParameter("@newHash", SqlDbType.NVarChar, 200) { Value = newHash },
                            new SqlParameter("@username", SqlDbType.NVarChar, 50) { Value = username }
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

        /// <summary>
        /// Creates a new user with hashed password.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Plain text password (will be hashed)</param>
        /// <param name="userType">User type (Admin, Cashier, Waiter)</param>
        /// <param name="fullName">Full name</param>
        /// <param name="contact">Contact number</param>
        /// <param name="dob">Date of birth</param>
        /// <param name="imageName">Image filename</param>
        /// <returns>Number of rows affected</returns>
        public static int CreateUser(string username, string password, string userType,
                                    string fullName, string contact, DateTime dob, string imageName)
        {
            try
            {
                string hashedPassword = PasswordHelper.HashPassword(password);

                string sql = @"INSERT INTO tbl_User
                              (user_name, password, user_type, name, contact, dob, image_name)
                              VALUES
                              (@username, @password, @userType, @fullName, @contact, @dob, @imageName)";

                SqlParameter[] parameters = {
                    new SqlParameter("@username", SqlDbType.NVarChar) { Value = username },
                    new SqlParameter("@password", SqlDbType.NVarChar) { Value = hashedPassword },
                    new SqlParameter("@userType", SqlDbType.NVarChar) { Value = userType },
                    new SqlParameter("@fullName", SqlDbType.NVarChar) { Value = fullName },
                    new SqlParameter("@contact", SqlDbType.NVarChar) { Value = contact ?? (object)DBNull.Value },
                    new SqlParameter("@dob", SqlDbType.DateTime) { Value = dob },
                    new SqlParameter("@imageName", SqlDbType.NVarChar) { Value = imageName ?? (object)DBNull.Value }
                };

                return ExecuteNonQuery(sql, parameters);
            }
            catch (Exception ex)
            {
                errorLog.Write(ex.Message, "SecureDataAccess.CreateUser", ErrorLogPath);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing user. If password is provided, it will be hashed.
        /// </summary>
        /// <param name="userId">User ID to update</param>
        /// <param name="username">New username</param>
        /// <param name="password">New password (plain text, will be hashed) - null to keep existing</param>
        /// <param name="userType">New user type</param>
        /// <param name="fullName">New full name</param>
        /// <param name="contact">New contact</param>
        /// <param name="dob">New date of birth</param>
        /// <param name="imageName">New image filename</param>
        /// <returns>Number of rows affected</returns>
        public static int UpdateUser(int userId, string username, string password, string userType,
                                    string fullName, string contact, DateTime dob, string imageName)
        {
            try
            {
                string sql;
                SqlParameter[] parameters;

                if (!string.IsNullOrEmpty(password))
                {
                    // Update with new password
                    string hashedPassword = PasswordHelper.HashPassword(password);

                    sql = @"UPDATE tbl_User
                           SET user_name = @username,
                               password = @password,
                               user_type = @userType,
                               name = @fullName,
                               contact = @contact,
                               dob = @dob,
                               image_name = @imageName
                           WHERE id = @userId";

                    parameters = new SqlParameter[] {
                        new SqlParameter("@userId", SqlDbType.BigInt) { Value = userId },
                        new SqlParameter("@username", SqlDbType.NVarChar) { Value = username },
                        new SqlParameter("@password", SqlDbType.NVarChar) { Value = hashedPassword },
                        new SqlParameter("@userType", SqlDbType.NVarChar) { Value = userType },
                        new SqlParameter("@fullName", SqlDbType.NVarChar) { Value = fullName },
                        new SqlParameter("@contact", SqlDbType.NVarChar) { Value = contact ?? (object)DBNull.Value },
                        new SqlParameter("@dob", SqlDbType.DateTime) { Value = dob },
                        new SqlParameter("@imageName", SqlDbType.NVarChar) { Value = imageName ?? (object)DBNull.Value }
                    };
                }
                else
                {
                    // Update without changing password
                    sql = @"UPDATE tbl_User
                           SET user_name = @username,
                               user_type = @userType,
                               name = @fullName,
                               contact = @contact,
                               dob = @dob,
                               image_name = @imageName
                           WHERE id = @userId";

                    parameters = new SqlParameter[] {
                        new SqlParameter("@userId", SqlDbType.BigInt) { Value = userId },
                        new SqlParameter("@username", SqlDbType.NVarChar) { Value = username },
                        new SqlParameter("@userType", SqlDbType.NVarChar) { Value = userType },
                        new SqlParameter("@fullName", SqlDbType.NVarChar) { Value = fullName },
                        new SqlParameter("@contact", SqlDbType.NVarChar) { Value = contact ?? (object)DBNull.Value },
                        new SqlParameter("@dob", SqlDbType.DateTime) { Value = dob },
                        new SqlParameter("@imageName", SqlDbType.NVarChar) { Value = imageName ?? (object)DBNull.Value }
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
