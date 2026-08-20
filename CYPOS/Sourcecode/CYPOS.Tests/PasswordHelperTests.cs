using System;
using NUnit.Framework;
using cypos;

namespace CYPOS.Tests
{
    [TestFixture]
    public class PasswordHelperTests
    {
        #region PBKDF2 HashPassword Tests

        [Test]
        public void HashPassword_ValidPassword_ReturnsPbkdf2Format()
        {
            string hash = PasswordHelper.HashPassword("test123");

            Assert.IsNotNull(hash);
            Assert.IsTrue(hash.StartsWith("PBKDF2$"));
            string[] parts = hash.Split('$');
            Assert.AreEqual(4, parts.Length);
        }

        [Test]
        public void HashPassword_SamePassword_ReturnsDifferentHashes()
        {
            string hash1 = PasswordHelper.HashPassword("admin");
            string hash2 = PasswordHelper.HashPassword("admin");

            Assert.AreNotEqual(hash1, hash2, "PBKDF2 with random salt should produce different hashes");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HashPassword_NullPassword_ThrowsException()
        {
            PasswordHelper.HashPassword(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HashPassword_EmptyPassword_ThrowsException()
        {
            PasswordHelper.HashPassword(string.Empty);
        }

        #endregion

        #region VerifyPassword PBKDF2 Tests

        [Test]
        public void VerifyPassword_CorrectPassword_Pbkdf2_ReturnsTrue()
        {
            string password = "MySecurePass123";
            string hash = PasswordHelper.HashPassword(password);

            bool result = PasswordHelper.VerifyPassword(password, hash);

            Assert.IsTrue(result);
        }

        [Test]
        public void VerifyPassword_WrongPassword_Pbkdf2_ReturnsFalse()
        {
            string hash = PasswordHelper.HashPassword("correct");

            bool result = PasswordHelper.VerifyPassword("wrong", hash);

            Assert.IsFalse(result);
        }

        [Test]
        public void VerifyPassword_CaseSensitive_Pbkdf2()
        {
            string hash = PasswordHelper.HashPassword("Password");

            Assert.IsFalse(PasswordHelper.VerifyPassword("password", hash));
        }

        #endregion

        #region VerifyPassword Legacy SHA256 Tests

        [Test]
        public void VerifyPassword_LegacySha256_ReturnsTrue()
        {
            string password = "admin";
            string legacyHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";

            bool result = PasswordHelper.VerifyPassword(password, legacyHash);

            Assert.IsTrue(result);
        }

        [Test]
        public void VerifyPassword_LegacySha256_WrongPassword_ReturnsFalse()
        {
            string legacyHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";

            bool result = PasswordHelper.VerifyPassword("wrong", legacyHash);

            Assert.IsFalse(result);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyPassword_NullPassword_ThrowsException()
        {
            PasswordHelper.VerifyPassword(null, "somehash");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyPassword_NullHash_ThrowsException()
        {
            PasswordHelper.VerifyPassword("test", null);
        }

        #endregion

        #region NeedsUpgrade Tests

        [Test]
        public void NeedsUpgrade_LegacySha256_ReturnsTrue()
        {
            string legacyHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";

            Assert.IsTrue(PasswordHelper.NeedsUpgrade(legacyHash));
        }

        [Test]
        public void NeedsUpgrade_Pbkdf2Hash_ReturnsFalse()
        {
            string hash = PasswordHelper.HashPassword("test");

            Assert.IsFalse(PasswordHelper.NeedsUpgrade(hash));
        }

        [Test]
        public void NeedsUpgrade_NullOrEmpty_ReturnsFalse()
        {
            Assert.IsFalse(PasswordHelper.NeedsUpgrade(null));
            Assert.IsFalse(PasswordHelper.NeedsUpgrade(string.Empty));
        }

        #endregion

        #region HashPasswordSha256 Tests

        [Test]
        public void HashPasswordSha256_AdminPassword_ReturnsExpectedHash()
        {
            string hash = PasswordHelper.HashPasswordSha256("admin");

            Assert.AreEqual("8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", hash);
        }

        [Test]
        public void HashPasswordSha256_SamePassword_ReturnsSameHash()
        {
            string hash1 = PasswordHelper.HashPasswordSha256("test");
            string hash2 = PasswordHelper.HashPasswordSha256("test");

            Assert.AreEqual(hash1, hash2);
        }

        #endregion

        #region ValidatePasswordComplexity Tests

        [Test]
        public void ValidatePasswordComplexity_ValidPassword_ReturnsTrue()
        {
            Assert.IsTrue(PasswordHelper.ValidatePasswordComplexity("password123"));
        }

        [Test]
        public void ValidatePasswordComplexity_TooShort_ReturnsFalse()
        {
            Assert.IsFalse(PasswordHelper.ValidatePasswordComplexity("short", 8));
        }

        [Test]
        public void ValidatePasswordComplexity_NullPassword_ReturnsFalse()
        {
            Assert.IsFalse(PasswordHelper.ValidatePasswordComplexity(null));
        }

        [Test]
        public void ValidatePasswordComplexity_EmptyPassword_ReturnsFalse()
        {
            Assert.IsFalse(PasswordHelper.ValidatePasswordComplexity(string.Empty));
        }

        #endregion
    }
}
