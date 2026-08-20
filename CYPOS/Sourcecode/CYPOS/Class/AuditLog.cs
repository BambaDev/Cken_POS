using System;
using System.Data;
using System.Data.SqlClient;

namespace cypos
{
    public static class AuditLog
    {
        public static void Log(string action, string detail = null)
        {
            try
            {
                string sql = @"INSERT INTO tbl_AuditLog (user_name, action, detail, log_date, log_time)
                              VALUES (@userName, @action, @detail, @logDate, @logTime)";

                SqlParameter[] parameters = {
                    new SqlParameter("@userName", SqlDbType.NVarChar, 50) { Value = UserInfo.UserName ?? "SYSTEM" },
                    new SqlParameter("@action", SqlDbType.NVarChar, 50) { Value = action },
                    new SqlParameter("@detail", SqlDbType.NVarChar, 500) { Value = (object)detail ?? DBNull.Value },
                    new SqlParameter("@logDate", SqlDbType.Date) { Value = DateTime.Now.ToString("yyyy-MM-dd") },
                    new SqlParameter("@logTime", SqlDbType.Time) { Value = DateTime.Now.ToString("HH:mm:ss") }
                };

                SecureDataAccess.ExecuteNonQuery(sql, parameters);
            }
            catch
            {
                // Audit logging must never crash the application
            }
        }

        public static void LogLogin(string username, bool success)
        {
            try
            {
                string sql = @"INSERT INTO tbl_AuditLog (user_name, action, detail, log_date, log_time)
                              VALUES (@userName, @action, @detail, @logDate, @logTime)";

                SqlParameter[] parameters = {
                    new SqlParameter("@userName", SqlDbType.NVarChar, 50) { Value = username },
                    new SqlParameter("@action", SqlDbType.NVarChar, 50) { Value = success ? "LOGIN_SUCCESS" : "LOGIN_FAILED" },
                    new SqlParameter("@detail", SqlDbType.NVarChar, 500) { Value = Environment.MachineName },
                    new SqlParameter("@logDate", SqlDbType.Date) { Value = DateTime.Now.ToString("yyyy-MM-dd") },
                    new SqlParameter("@logTime", SqlDbType.Time) { Value = DateTime.Now.ToString("HH:mm:ss") }
                };

                SecureDataAccess.ExecuteNonQuery(sql, parameters);
            }
            catch
            {
            }
        }

        public static void LogUserAction(string action, string entityType, string entityId)
        {
            Log(action, string.Format("{0} ID={1}", entityType, entityId));
        }
    }
}
