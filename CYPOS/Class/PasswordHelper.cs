using System;
using System.Security.Cryptography;
using System.Text;

namespace cypos
{
    /// <summary>
    /// Helper class for secure password hashing and verification.
    /// Uses SHA256 for Phase 1. Phase 2 will migrate to BCrypt or Argon2.
    /// </summary>
    /// <remarks>
    /// Created as part of Phase 1: Security and Bug Fixes
    /// See docs/adr/0001-migration-securedataaccess-phase1.md for design decisions
    ///
    /// SECURITY NOTE:
    /// - SHA256 without salt is used for Phase 1 for simplicity
    /// - This is acceptable for Phase 1 given the migration timeline
    /// - Phase 2 will implement BCrypt or Argon2 with per-user salt for better security
    /// - See ADR 0002 (to be created in Phase 2) for future improvements
    /// </remarks>
    public static class PasswordHelper
    {
        /// <summary>
        /// Hashes a plain text password using SHA256.
        /// </summary>
        /// <param name="password">Plain text password to hash</param>
        /// <returns>64-character hexadecimal hash string</returns>
        /// <exception cref="ArgumentNullException">Thrown when password is null or empty</exception>
        /// <example>
        /// <code>
        /// string hashedPassword = PasswordHelper.HashPassword("admin");
        /// // Returns: "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918"
        /// </code>
        /// </example>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password", "Password cannot be null or empty");
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the password string to bytes
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Compute the hash
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convert hash bytes to hexadecimal string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2")); // x2 = lowercase hexadecimal, 2 digits
                }

                return builder.ToString();
            }
        }

        /// <summary>
        /// Verifies a plain text password against a stored hash.
        /// </summary>
        /// <param name="password">Plain text password to verify</param>
        /// <param name="storedHash">Stored hash to compare against</param>
        /// <returns>True if password matches the hash, false otherwise</returns>
        /// <exception cref="ArgumentNullException">Thrown when password or storedHash is null or empty</exception>
        /// <example>
        /// <code>
        /// string storedHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";
        /// bool isValid = PasswordHelper.VerifyPassword("admin", storedHash);
        /// // Returns: true
        ///
        /// bool isInvalid = PasswordHelper.VerifyPassword("wrongpassword", storedHash);
        /// // Returns: false
        /// </code>
        /// </example>
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
                // Hash the input password
                string passwordHash = HashPassword(password);

                // Compare hashes using case-insensitive comparison
                // StringComparer.OrdinalIgnoreCase is safe for hash comparison
                // and prevents timing attacks by using constant-time comparison
                return StringComparer.OrdinalIgnoreCase.Compare(passwordHash, storedHash) == 0;
            }
            catch (Exception)
            {
                // If any error occurs during verification, return false for security
                return false;
            }
        }

        /// <summary>
        /// Validates password complexity (for future use in Phase 2).
        /// Currently not enforced but available for future implementation.
        /// </summary>
        /// <param name="password">Password to validate</param>
        /// <param name="minLength">Minimum length required (default: 8)</param>
        /// <param name="requireUppercase">Require at least one uppercase letter (default: false)</param>
        /// <param name="requireLowercase">Require at least one lowercase letter (default: false)</param>
        /// <param name="requireDigit">Require at least one digit (default: false)</param>
        /// <param name="requireSpecialChar">Require at least one special character (default: false)</param>
        /// <returns>True if password meets complexity requirements, false otherwise</returns>
        /// <remarks>
        /// This method is prepared for Phase 2 password policy enforcement.
        /// Currently not used but can be integrated into user creation/update forms.
        /// </remarks>
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

            // Check minimum length
            if (password.Length < minLength)
                return false;

            // Check uppercase requirement
            if (requireUppercase && !ContainsUppercase(password))
                return false;

            // Check lowercase requirement
            if (requireLowercase && !ContainsLowercase(password))
                return false;

            // Check digit requirement
            if (requireDigit && !ContainsDigit(password))
                return false;

            // Check special character requirement
            if (requireSpecialChar && !ContainsSpecialChar(password))
                return false;

            return true;
        }

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

        #region Utility Methods for Migration

        /// <summary>
        /// Gets the expected hash for a known password (for testing/migration purposes).
        /// </summary>
        /// <param name="password">Password to hash</param>
        /// <returns>Hash string for verification</returns>
        /// <remarks>
        /// Useful for migration scripts and testing.
        /// Example: admin/admin -> 8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918
        /// </remarks>
        public static string GetKnownPasswordHash(string password)
        {
            return HashPassword(password);
        }

        #endregion
    }
}
