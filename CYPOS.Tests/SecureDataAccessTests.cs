using System;
using System.Data;
using System.Data.SqlClient;
using NUnit.Framework;
using CYPOS;

namespace CYPOS.Tests
{
    /// <summary>
    /// Tests unitaires pour la classe SecureDataAccess
    /// Note: Ces tests nécessitent une base de données SQL Server locale
    /// </summary>
    [TestFixture]
    public class SecureDataAccessTests
    {
        private const string TEST_TABLE = "tbl_TestData";

        #region Setup / Teardown

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            // Créer une table de test si elle n'existe pas
            try
            {
                string createTableSQL = string.Format(
                    @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = '{0}')
                    BEGIN
                        CREATE TABLE {0} (
                            id INT IDENTITY(1,1) PRIMARY KEY,
                            test_name NVARCHAR(100),
                            test_value NVARCHAR(100),
                            created_date DATETIME DEFAULT GETDATE()
                        )
                    END",
                    TEST_TABLE
                );
                SecureDataAccess.ExecuteNonQuery(createTableSQL);
            }
            catch (Exception ex)
            {
                Assert.Inconclusive("Impossible de créer la table de test: " + ex.Message);
            }
        }

        [SetUp]
        public void TestSetup()
        {
            // Nettoyer la table avant chaque test
            try
            {
                string cleanSQL = string.Format("DELETE FROM {0}", TEST_TABLE);
                SecureDataAccess.ExecuteNonQuery(cleanSQL);
            }
            catch
            {
                // Ignorer les erreurs de nettoyage
            }
        }

        [TestFixtureTearDown]
        public void TestFixtureTeardown()
        {
            // Supprimer la table de test à la fin
            try
            {
                string dropTableSQL = string.Format("DROP TABLE {0}", TEST_TABLE);
                SecureDataAccess.ExecuteNonQuery(dropTableSQL);
            }
            catch
            {
                // Ignorer les erreurs de suppression
            }
        }

        #endregion

        #region Tests ExecuteNonQuery

        [Test]
        [Description("Vérifie qu'ExecuteNonQuery insère correctement avec des paramètres")]
        public void ExecuteNonQuery_WithParameters_InsertsData()
        {
            // Arrange
            string sql = string.Format(
                "INSERT INTO {0} (test_name, test_value) VALUES (@name, @value)",
                TEST_TABLE
            );
            SqlParameter[] parameters = {
                new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = "Test1" },
                new SqlParameter("@value", SqlDbType.NVarChar, 100) { Value = "Value1" }
            };

            // Act
            int rowsAffected = SecureDataAccess.ExecuteNonQuery(sql, parameters);

            // Assert
            Assert.AreEqual(1, rowsAffected, "ExecuteNonQuery doit retourner 1 ligne affectée");
        }

        [Test]
        [Description("Vérifie qu'ExecuteNonQuery protège contre SQL Injection")]
        public void ExecuteNonQuery_SqlInjectionAttempt_DoesNotExecuteMaliciousCode()
        {
            // Arrange - Tentative d'injection SQL
            string maliciousValue = "'; DROP TABLE tbl_User; --";
            string sql = string.Format(
                "INSERT INTO {0} (test_name, test_value) VALUES (@name, @value)",
                TEST_TABLE
            );
            SqlParameter[] parameters = {
                new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = "Injection Test" },
                new SqlParameter("@value", SqlDbType.NVarChar, 100) { Value = maliciousValue }
            };

            // Act
            int rowsAffected = SecureDataAccess.ExecuteNonQuery(sql, parameters);

            // Assert
            Assert.AreEqual(1, rowsAffected, "La valeur malicieuse doit être insérée comme texte simple");

            // Vérifier que la table tbl_User existe toujours
            bool tableExists = SecureDataAccess.RecordExists(
                "SELECT 1 FROM sys.tables WHERE name = 'tbl_User'"
            );
            Assert.IsTrue(tableExists, "La table tbl_User ne doit pas avoir été supprimée");
        }

        [Test]
        [Description("Vérifie qu'ExecuteNonQuery supporte les apostrophes")]
        public void ExecuteNonQuery_WithApostrophe_InsertsCorrectly()
        {
            // Arrange
            string sql = string.Format(
                "INSERT INTO {0} (test_name, test_value) VALUES (@name, @value)",
                TEST_TABLE
            );
            SqlParameter[] parameters = {
                new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = "O'Brien" },
                new SqlParameter("@value", SqlDbType.NVarChar, 100) { Value = "L'Auberge" }
            };

            // Act
            int rowsAffected = SecureDataAccess.ExecuteNonQuery(sql, parameters);

            // Assert
            Assert.AreEqual(1, rowsAffected);
        }

        #endregion

        #region Tests GetDataTable

        [Test]
        [Description("Vérifie que GetDataTable retourne les données correctement")]
        public void GetDataTable_WithData_ReturnsDataTable()
        {
            // Arrange - Insérer des données de test
            string insertSQL = string.Format(
                "INSERT INTO {0} (test_name, test_value) VALUES (@name, @value)",
                TEST_TABLE
            );
            SqlParameter[] insertParams = {
                new SqlParameter("@name", SqlDbType.NVarChar, 100) { Value = "Test1" },
                new SqlParameter("@value", SqlDbType.NVarChar, 100) { Value = "Value1" }
            };
            SecureDataAccess.ExecuteNonQuery(insertSQL, insertParams);

            // Act
            string selectSQL = string.Format("SELECT * FROM {0}", TEST_TABLE);
            DataTable dt = SecureDataAccess.GetDataTable(selectSQL);

            // Assert
            Assert.IsNotNull(dt, "GetDataTable ne doit pas retourner null");
            Assert.AreEqual(1, dt.Rows.Count, "La table doit contenir 1 ligne");
            Assert.AreEqual("Test1", dt.Rows[0]["test_name"].ToString());
            Assert.AreEqual("Value1", dt.Rows[0]["test_value"].ToString());
        }

        [Test]
        [Description("Vérifie que GetDataTable retourne une table vide si aucune donnée")]
        public void GetDataTable_NoData_ReturnsEmptyDataTable()
        {
            // Act
            string selectSQL = string.Format("SELECT * FROM {0}", TEST_TABLE);
            DataTable dt = SecureDataAccess.GetDataTable(selectSQL);

            // Assert
            Assert.IsNotNull(dt, "GetDataTable ne doit pas retourner null");
            Assert.AreEqual(0, dt.Rows.Count, "La table doit être vide");
        }

        [Test]
        [Description("Vérifie que GetDataTable fonctionne avec des paramètres")]
        public void GetDataTable_WithParameters_ReturnsFilteredData()
        {
            // Arrange - Insérer plusieurs données
            string insertSQL = string.Format(
                "INSERT INTO {0} (test_name, test_value) VALUES (@name, @value)",
                TEST_TABLE
            );
            SecureDataAccess.ExecuteNonQuery(insertSQL, new[] {
                new SqlParameter("@name", "Test1"),
                new SqlParameter("@value", "Value1")
            });
            SecureDataAccess.ExecuteNonQuery(insertSQL, new[] {
                new SqlParameter("@name", "Test2"),
                new SqlParameter("@value", "Value2")
            });

            // Act
            string selectSQL = string.Format("SELECT * FROM {0} WHERE test_name = @name", TEST_TABLE);
            SqlParameter[] parameters = {
                new SqlParameter("@name", "Test1")
            };
            DataTable dt = SecureDataAccess.GetDataTable(selectSQL, parameters);

            // Assert
            Assert.AreEqual(1, dt.Rows.Count, "Seule 1 ligne doit correspondre au filtre");
            Assert.AreEqual("Test1", dt.Rows[0]["test_name"].ToString());
        }

        #endregion

        #region Tests ExecuteScalar

        [Test]
        [Description("Vérifie qu'ExecuteScalar retourne la valeur correcte")]
        public void ExecuteScalar_WithData_ReturnsValue()
        {
            // Arrange - Insérer une donnée
            string insertSQL = string.Format(
                "INSERT INTO {0} (test_name, test_value) VALUES (@name, @value)",
                TEST_TABLE
            );
            SqlParameter[] insertParams = {
                new SqlParameter("@name", "Test1"),
                new SqlParameter("@value", "Value1")
            };
            SecureDataAccess.ExecuteNonQuery(insertSQL, insertParams);

            // Act
            string selectSQL = string.Format("SELECT COUNT(*) FROM {0}", TEST_TABLE);
            object result = SecureDataAccess.ExecuteScalar(selectSQL);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, Convert.ToInt32(result));
        }

        [Test]
        [Description("Vérifie qu'ExecuteScalar retourne null si aucune donnée")]
        public void ExecuteScalar_NoData_ReturnsNull()
        {
            // Act
            string selectSQL = string.Format(
                "SELECT test_name FROM {0} WHERE test_name = @name",
                TEST_TABLE
            );
            SqlParameter[] parameters = {
                new SqlParameter("@name", "NonExistent")
            };
            object result = SecureDataAccess.ExecuteScalar(selectSQL, parameters);

            // Assert
            Assert.IsNull(result, "ExecuteScalar doit retourner null si aucune donnée");
        }

        #endregion

        #region Tests RecordExists

        [Test]
        [Description("Vérifie que RecordExists retourne true si l'enregistrement existe")]
        public void RecordExists_RecordExists_ReturnsTrue()
        {
            // Arrange - Insérer une donnée
            string insertSQL = string.Format(
                "INSERT INTO {0} (test_name, test_value) VALUES (@name, @value)",
                TEST_TABLE
            );
            SecureDataAccess.ExecuteNonQuery(insertSQL, new[] {
                new SqlParameter("@name", "Test1"),
                new SqlParameter("@value", "Value1")
            });

            // Act
            string checkSQL = string.Format(
                "SELECT 1 FROM {0} WHERE test_name = @name",
                TEST_TABLE
            );
            SqlParameter[] parameters = {
                new SqlParameter("@name", "Test1")
            };
            bool exists = SecureDataAccess.RecordExists(checkSQL, parameters);

            // Assert
            Assert.IsTrue(exists, "RecordExists doit retourner true");
        }

        [Test]
        [Description("Vérifie que RecordExists retourne false si l'enregistrement n'existe pas")]
        public void RecordExists_RecordDoesNotExist_ReturnsFalse()
        {
            // Act
            string checkSQL = string.Format(
                "SELECT 1 FROM {0} WHERE test_name = @name",
                TEST_TABLE
            );
            SqlParameter[] parameters = {
                new SqlParameter("@name", "NonExistent")
            };
            bool exists = SecureDataAccess.RecordExists(checkSQL, parameters);

            // Assert
            Assert.IsFalse(exists, "RecordExists doit retourner false");
        }

        #endregion

        #region Tests AuthenticateUser

        [Test]
        [Description("Vérifie qu'AuthenticateUser retourne true pour un utilisateur valide")]
        public void AuthenticateUser_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            string username = "admin";
            string password = "admin";

            // Act
            string userType;
            bool authenticated = SecureDataAccess.AuthenticateUser(username, password, out userType);

            // Assert
            Assert.IsTrue(authenticated, "L'authentification doit réussir pour admin/admin");
            Assert.IsNotNull(userType, "Le type d'utilisateur doit être retourné");
        }

        [Test]
        [Description("Vérifie qu'AuthenticateUser retourne false pour un mot de passe invalide")]
        public void AuthenticateUser_InvalidPassword_ReturnsFalse()
        {
            // Arrange
            string username = "admin";
            string invalidPassword = "wrongpassword";

            // Act
            string userType;
            bool authenticated = SecureDataAccess.AuthenticateUser(username, invalidPassword, out userType);

            // Assert
            Assert.IsFalse(authenticated, "L'authentification doit échouer avec un mauvais mot de passe");
        }

        [Test]
        [Description("Vérifie qu'AuthenticateUser retourne false pour un utilisateur inexistant")]
        public void AuthenticateUser_NonExistentUser_ReturnsFalse()
        {
            // Arrange
            string username = "nonexistent_user_xyz";
            string password = "password";

            // Act
            string userType;
            bool authenticated = SecureDataAccess.AuthenticateUser(username, password, out userType);

            // Assert
            Assert.IsFalse(authenticated, "L'authentification doit échouer pour un utilisateur inexistant");
        }

        #endregion

        #region Tests ExecuteTransaction

        [Test]
        [Description("Vérifie qu'ExecuteTransaction commit les changements en cas de succès")]
        public void ExecuteTransaction_Success_CommitsChanges()
        {
            // Arrange & Act
            SecureDataAccess.ExecuteTransaction((conn, transaction) =>
            {
                string insertSQL = string.Format(
                    "INSERT INTO {0} (test_name, test_value) VALUES (@name, @value)",
                    TEST_TABLE
                );
                using (SqlCommand cmd = new SqlCommand(insertSQL, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@name", "TransactionTest");
                    cmd.Parameters.AddWithValue("@value", "Value1");
                    cmd.ExecuteNonQuery();
                }
            });

            // Assert - Vérifier que les données ont été committées
            string selectSQL = string.Format("SELECT COUNT(*) FROM {0}", TEST_TABLE);
            object result = SecureDataAccess.ExecuteScalar(selectSQL);
            Assert.AreEqual(1, Convert.ToInt32(result), "Les données doivent être committées");
        }

        [Test]
        [Description("Vérifie qu'ExecuteTransaction rollback en cas d'exception")]
        public void ExecuteTransaction_Exception_RollsBack()
        {
            // Arrange & Act
            try
            {
                SecureDataAccess.ExecuteTransaction((conn, transaction) =>
                {
                    // Première insertion
                    string insertSQL = string.Format(
                        "INSERT INTO {0} (test_name, test_value) VALUES (@name, @value)",
                        TEST_TABLE
                    );
                    using (SqlCommand cmd = new SqlCommand(insertSQL, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@name", "RollbackTest");
                        cmd.Parameters.AddWithValue("@value", "Value1");
                        cmd.ExecuteNonQuery();
                    }

                    // Lever une exception
                    throw new Exception("Test exception");
                });
            }
            catch
            {
                // Ignorer l'exception
            }

            // Assert - Vérifier que les données ont été rollback
            string selectSQL = string.Format("SELECT COUNT(*) FROM {0}", TEST_TABLE);
            object result = SecureDataAccess.ExecuteScalar(selectSQL);
            Assert.AreEqual(0, Convert.ToInt32(result), "Les données doivent être rollback");
        }

        #endregion
    }
}
