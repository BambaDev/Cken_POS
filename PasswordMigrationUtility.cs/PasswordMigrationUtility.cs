/*******************************************************************************
 * CYPOS - Password Migration Utility
 *
 * Purpose: Hash all plain text passwords in the database
 * Usage: Run this AFTER migration_phase1.sql and BEFORE deploying new code
 *
 * IMPORTANT:
 * - Compile this as a console application
 * - Run on a backup/test database first
 * - Verify all passwords are hashed before proceeding to production
 *
 * Compilation:
 *   csc /out:PasswordMigrationUtility.exe PasswordMigrationUtility.cs /r:System.Data.dll
 *
 * Or add to CYPOS solution as a separate console project
 ******************************************************************************/

using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace CYPOS.Migration
{
    class PasswordMigrationUtility
    {
        private static string ConnectionString =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=CYPOS;Integrated Security=True;";

        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("CYPOS Password Migration Utility");
            Console.WriteLine("========================================");
            Console.WriteLine();

            try
            {
                // Step 1: Connect to database
                Console.WriteLine("Connecting to database...");
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    Console.WriteLine("Connected successfully.");
                    Console.WriteLine();

                    // Step 2: Get all users with plain text passwords
                    Console.WriteLine("Retrieving users with plain text passwords...");
                    string selectSql = @"SELECT id, user_name, password
                                        FROM tbl_User
                                        WHERE LEN(password) < 64";

                    DataTable usersToMigrate = new DataTable();
                    using (SqlCommand selectCmd = new SqlCommand(selectSql, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(selectCmd))
                    {
                        adapter.Fill(usersToMigrate);
                    }

                    int totalUsers = usersToMigrate.Rows.Count;
                    Console.WriteLine(string.Format("Found {0} user(s) with plain text passwords.", totalUsers));
                    Console.WriteLine();

                    if (totalUsers == 0)
                    {
                        Console.WriteLine("No users need migration. All passwords are already hashed.");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    // Step 3: Display users to be migrated
                    Console.WriteLine("Users to be migrated:");
                    Console.WriteLine("--------------------------------------------------");
                    foreach (DataRow row in usersToMigrate.Rows)
                    {
                        Console.WriteLine(string.Format("  - {0} (ID: {1})", row["user_name"], row["id"]));
                    }
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine();

                    // Step 4: Confirmation
                    Console.WriteLine("WARNING: This will hash all plain text passwords.");
                    Console.WriteLine("After hashing, passwords cannot be recovered.");
                    Console.WriteLine("Make sure you have a backup before proceeding.");
                    Console.WriteLine();
                    Console.Write("Do you want to proceed? (yes/no): ");
                    string confirmation = Console.ReadLine();

                    if (confirmation == null || confirmation.ToLower() != "yes")
                    {
                        Console.WriteLine("Migration cancelled by user.");
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        return;
                    }

                    Console.WriteLine();

                    // Step 5: Hash and update passwords
                    Console.WriteLine("Hashing passwords...");
                    Console.WriteLine();

                    int successCount = 0;
                    int failCount = 0;

                    string updateSql = @"UPDATE tbl_User
                                        SET password = @hashedPassword
                                        WHERE id = @userId";

                    foreach (DataRow row in usersToMigrate.Rows)
                    {
                        int userId = Convert.ToInt32(row["id"]);
                        string userName = row["user_name"].ToString();
                        string plainPassword = row["password"].ToString();

                        try
                        {
                            // Hash the password using SHA256 (same as PasswordHelper.cs)
                            string hashedPassword = HashPassword(plainPassword);

                            // Update in database
                            using (SqlCommand updateCmd = new SqlCommand(updateSql, conn))
                            {
                                updateCmd.Parameters.Add("@hashedPassword", SqlDbType.VarChar, 256).Value = hashedPassword;
                                updateCmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
                                updateCmd.ExecuteNonQuery();
                            }

                            Console.WriteLine(string.Format("  ✓ {0} - Password hashed successfully", userName));
                            successCount++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(string.Format("  ✗ {0} - Failed: {1}", userName, ex.Message));
                            failCount++;
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("========================================");
                    Console.WriteLine("Migration Summary");
                    Console.WriteLine("========================================");
                    Console.WriteLine(string.Format("Total users processed: {0}", totalUsers));
                    Console.WriteLine(string.Format("Successfully migrated: {0}", successCount));
                    Console.WriteLine(string.Format("Failed: {0}", failCount));
                    Console.WriteLine();

                    // Step 6: Validation
                    Console.WriteLine("Validating migration...");
                    string validationSql = @"SELECT
                                               COUNT(*) AS TotalUsers,
                                               COUNT(CASE WHEN LEN(password) = 64 THEN 1 END) AS HashedUsers,
                                               COUNT(CASE WHEN LEN(password) < 64 THEN 1 END) AS PlainTextUsers
                                            FROM tbl_User";

                    using (SqlCommand validationCmd = new SqlCommand(validationSql, conn))
                    using (SqlDataReader reader = validationCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int total = reader.GetInt32(0);
                            int hashed = reader.GetInt32(1);
                            int plainText = reader.GetInt32(2);

                            Console.WriteLine(string.Format("Total users: {0}", total));
                            Console.WriteLine(string.Format("Hashed passwords (64 chars): {0}", hashed));
                            Console.WriteLine(string.Format("Plain text passwords (< 64 chars): {0}", plainText));
                            Console.WriteLine();

                            if (plainText > 0)
                            {
                                Console.WriteLine("WARNING: Some passwords are still in plain text!");
                                Console.WriteLine("Run this utility again to migrate remaining passwords.");
                            }
                            else if (hashed == total)
                            {
                                Console.WriteLine("SUCCESS: All passwords have been hashed!");
                                Console.WriteLine();
                                Console.WriteLine("Next steps:");
                                Console.WriteLine("1. Test login with known credentials (e.g., admin/admin)");
                                Console.WriteLine("2. Deploy new application code with SecureDataAccess");
                                Console.WriteLine("3. Monitor error logs after deployment");
                            }
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.WriteLine("CRITICAL ERROR");
                Console.WriteLine("========================================");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                Console.WriteLine("Stack trace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                Console.WriteLine("Migration failed. Database may be in inconsistent state.");
                Console.WriteLine("Consider running rollback_phase1.sql if necessary.");
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Hash password using SHA256 (matches PasswordHelper.cs implementation)
        /// </summary>
        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
