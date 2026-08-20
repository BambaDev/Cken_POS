using System;
using System.Data;
using System.Data.SqlClient;

namespace cypos
{
    public static class DashboardStats
    {
        public static decimal GetTodaySales()
        {
            string sql = @"SELECT ISNULL(SUM(payment_amount), 0)
                          FROM tbl_InvoiceHeader
                          WHERE CAST(log_date AS DATE) = CAST(GETDATE() AS DATE)";
            object result = SecureDataAccess.ExecuteScalar(sql);
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        public static int GetTodayOrderCount()
        {
            string sql = @"SELECT COUNT(*)
                          FROM tbl_InvoiceHeader
                          WHERE CAST(log_date AS DATE) = CAST(GETDATE() AS DATE)";
            object result = SecureDataAccess.ExecuteScalar(sql);
            return result != null ? Convert.ToInt32(result) : 0;
        }

        public static decimal GetTodayExpenses()
        {
            string sql = @"SELECT ISNULL(SUM(amount), 0)
                          FROM tbl_Expenses
                          WHERE CAST(expense_date AS DATE) = CAST(GETDATE() AS DATE)";
            object result = SecureDataAccess.ExecuteScalar(sql);
            return result != null ? Convert.ToDecimal(result) : 0;
        }

        public static DataTable GetTopSellingItems(int top = 5)
        {
            string sql = string.Format(
                @"SELECT TOP {0} item_name, SUM(qty) AS total_qty, SUM(total) AS total_amount
                  FROM tbl_InvoiceDetail d
                  INNER JOIN tbl_InvoiceHeader h ON d.invoice_id = h.invoice_id
                  WHERE CAST(h.log_date AS DATE) = CAST(GETDATE() AS DATE)
                  GROUP BY item_name
                  ORDER BY total_qty DESC", top);
            return SecureDataAccess.GetDataTable(sql);
        }

        public static DataTable GetSalesByPaymentType()
        {
            string sql = @"SELECT payment_type, COUNT(*) AS order_count, SUM(payment_amount) AS total_amount
                          FROM tbl_InvoiceHeader
                          WHERE CAST(log_date AS DATE) = CAST(GETDATE() AS DATE)
                          GROUP BY payment_type
                          ORDER BY total_amount DESC";
            return SecureDataAccess.GetDataTable(sql);
        }

        public static DataTable GetWeeklySales()
        {
            string sql = @"SELECT CAST(log_date AS DATE) AS sale_date,
                                  COUNT(*) AS order_count,
                                  SUM(payment_amount) AS total_amount
                          FROM tbl_InvoiceHeader
                          WHERE log_date >= DATEADD(DAY, -7, GETDATE())
                          GROUP BY CAST(log_date AS DATE)
                          ORDER BY sale_date";
            return SecureDataAccess.GetDataTable(sql);
        }

        public static decimal GetMonthSales()
        {
            string sql = @"SELECT ISNULL(SUM(payment_amount), 0)
                          FROM tbl_InvoiceHeader
                          WHERE MONTH(log_date) = MONTH(GETDATE())
                            AND YEAR(log_date) = YEAR(GETDATE())";
            object result = SecureDataAccess.ExecuteScalar(sql);
            return result != null ? Convert.ToDecimal(result) : 0;
        }
    }
}
