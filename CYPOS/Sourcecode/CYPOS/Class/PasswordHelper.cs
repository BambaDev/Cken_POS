using System;
using System.Security.Cryptography;
using System.Text;

namespace cypos
{
    /// <summary>
    /// Helper class for secure password hashing and verification.
    /// Uses PBKDF2 (RFC 2898) with per-user salt for strong security.
    /// Maintains backward compatibility with legacy SHA256 hashes from Phase 1.
    /// </summary>
    public static class PasswordHelper
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 10000;
        private const string Pbkdf2Prefix = "PBKDF2$";

        /// <summary>
        /// Hashes a password using PBKDF2 with a random salt.
        /// Output format: "PBKDF2$iterations$base64salt$base64hash"
        /// </summary>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password", "Password cannot be null or empty");
            }

            byte[] salt = new byte[SaltSize];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = ComputePbkdf2(password, salt, Iterations, HashSize);

            return string.Format("{0}{1}${2}${3}",
                Pbkdf2Prefix,
                Iterations,
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash));
        }

        /// <summary>
        /// Verifies a password against a stored hash.
        /// Supports both new PBKDF2 format and legacy SHA256 hashes.
        /// </summary>
        public static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password", "Password cannot be null or empty");
            }

            if (string.IsNullOrEmpty(storedHash))
            {
                throw new ArgumentNullException("storedHash", "Stored hash cannot be null or empty");
            }

            try
            {
                if (storedHash.StartsWith(Pbkdf2Prefix))
                {
                    return VerifyPbkdf2(password, storedHash);
                }
                else
                {
                    return VerifyLegacySha256(password, storedHash);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a stored hash uses the legacy SHA256 format and needs upgrade.
        /// </summary>
        public static bool NeedsUpgrade(string storedHash)
        {
            if (string.IsNullOrEmpty(storedHash))
                return false;

            return !storedHash.StartsWith(Pbkdf2Prefix);
        }

        /// <summary>
        /// Validates password complexity.
        /// </summary>
        public static bool ValidatePasswordComplexity(
            string password,
            int minLength = 8,
            bool requireUppercase = false,
            bool requireLowercase = false,
            bool requireDigit = false,
            bool requireSpecialChar = false)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (password.Length < minLength)
                return false;

            if (requireUppercase && !ContainsUppercase(password))
                return false;

            if (requireLowercase && !ContainsLowercase(password))
                return false;

            if (requireDigit && !ContainsDigit(password))
                return false;

            if (requireSpecialChar && !ContainsSpecialChar(password))
                return false;

            return true;
        }

        #region Legacy SHA256 support

        /// <summary>
        /// Hashes using legacy SHA256 (for migration utility only).
        /// </summary>
        public static string HashPasswordSha256(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password", "Password cannot be null or empty");
            }

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

        private static bool VerifyLegacySha256(string password, string storedHash)
        {
            string passwordHash = HashPasswordSha256(password);
            return StringComparer.OrdinalIgnoreCase.Compare(passwordHash, storedHash) == 0;
        }

        #endregion

        #region PBKDF2 Implementation

        private static bool VerifyPbkdf2(string password, string storedHash)
        {
            string[] parts = storedHash.Split('$');
            if (parts.Length != 4)
                return false;

            int iterations = int.Parse(parts[1]);
            byte[] salt = Convert.FromBase64String(parts[2]);
            byte[] expectedHash = Convert.FromBase64String(parts[3]);

            byte[] actualHash = ComputePbkdf2(password, salt, iterations, expectedHash.Length);

            return ConstantTimeEquals(expectedHash, actualHash);
        }

        private static byte[] ComputePbkdf2(string password, byte[] salt, int iterations, int outputBytes)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return pbkdf2.GetBytes(outputBytes);
            }
        }

        private static bool ConstantTimeEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                diff |= a[i] ^ b[i];
            }
            return diff == 0;
        }

        #endregion

        #region Private Helper Methods

        private static bool ContainsUppercase(string str)
        {
            foreach (char c in str)
            {
                if (char.IsUpper(c))
                    return true;
            }
            return false;
        }

        private static bool ContainsLowercase(string str)
        {
            foreach (char c in str)
            {
                if (char.IsLower(c))
                    return true;
            }
            return false;
        }

        private static bool ContainsDigit(string str)
        {
            foreach (char c in str)
            {
                if (char.IsDigit(c))
                    return true;
            }
            return false;
        }

        private static bool ContainsSpecialChar(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetterOrDigit(c))
                    return true;
            }
            return false;
        }

        #endregion

        #region Utility Methods

        /// <summary>
        /// Gets the expected SHA256 hash for a known password (testing/migration).
        /// </summary>
        public static string GetKnownPasswordHash(string password)
        {
            return HashPasswordSha256(password);
        }

        #endregion
    }
}
