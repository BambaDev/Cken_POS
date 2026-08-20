using System;
using NUnit.Framework;
using CYPOS;

namespace CYPOS.Tests
{
    /// <summary>
    /// Tests unitaires pour la classe PasswordHelper
    /// Vérifie le hachage SHA256 et la validation des mots de passe
    /// </summary>
    [TestFixture]
    public class PasswordHelperTests
    {
        #region Tests HashPassword

        [Test]
        [Description("Vérifie que HashPassword retourne un hash SHA256 de 64 caractères")]
        public void HashPassword_ValidPassword_Returns64CharacterHash()
        {
            // Arrange
            string password = "test123";

            // Act
            string hash = PasswordHelper.HashPassword(password);

            // Assert
            Assert.IsNotNull(hash);
            Assert.AreEqual(64, hash.Length, "Le hash SHA256 doit faire 64 caractères");
        }

        [Test]
        [Description("Vérifie que le même mot de passe produit toujours le même hash")]
        public void HashPassword_SamePassword_ReturnsSameHash()
        {
            // Arrange
            string password = "admin";

            // Act
            string hash1 = PasswordHelper.HashPassword(password);
            string hash2 = PasswordHelper.HashPassword(password);

            // Assert
            Assert.AreEqual(hash1, hash2, "Le même mot de passe doit toujours produire le même hash");
        }

        [Test]
        [Description("Vérifie que 'admin' produit le hash attendu")]
        public void HashPassword_AdminPassword_ReturnsExpectedHash()
        {
            // Arrange
            string password = "admin";
            string expectedHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";

            // Act
            string actualHash = PasswordHelper.HashPassword(password);

            // Assert
            Assert.AreEqual(expectedHash, actualHash, "Le hash de 'admin' doit correspondre au hash SHA256 attendu");
        }

        [Test]
        [Description("Vérifie que des mots de passe différents produisent des hash différents")]
        public void HashPassword_DifferentPasswords_ReturnDifferentHashes()
        {
            // Arrange
            string password1 = "password123";
            string password2 = "password124";

            // Act
            string hash1 = PasswordHelper.HashPassword(password1);
            string hash2 = PasswordHelper.HashPassword(password2);

            // Assert
            Assert.AreNotEqual(hash1, hash2, "Des mots de passe différents doivent produire des hash différents");
        }

        [Test]
        [Description("Vérifie que les caractères spéciaux sont supportés")]
        public void HashPassword_SpecialCharacters_ReturnsValidHash()
        {
            // Arrange
            string password = "P@ssw0rd!#$%";

            // Act
            string hash = PasswordHelper.HashPassword(password);

            // Assert
            Assert.IsNotNull(hash);
            Assert.AreEqual(64, hash.Length);
        }

        [Test]
        [Description("Vérifie que les accents sont supportés")]
        public void HashPassword_AccentedCharacters_ReturnsValidHash()
        {
            // Arrange
            string password = "Café123";

            // Act
            string hash = PasswordHelper.HashPassword(password);

            // Assert
            Assert.IsNotNull(hash);
            Assert.AreEqual(64, hash.Length);
        }

        [Test]
        [Description("Vérifie qu'une exception est levée si le mot de passe est null")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HashPassword_NullPassword_ThrowsArgumentNullException()
        {
            // Act
            PasswordHelper.HashPassword(null);

            // Assert est fait par l'attribut ExpectedException
        }

        [Test]
        [Description("Vérifie qu'une exception est levée si le mot de passe est vide")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HashPassword_EmptyPassword_ThrowsArgumentNullException()
        {
            // Act
            PasswordHelper.HashPassword(string.Empty);

            // Assert est fait par l'attribut ExpectedException
        }

        [Test]
        [Description("Vérifie que le hash est en minuscules hexadécimal")]
        public void HashPassword_ValidPassword_ReturnsLowercaseHex()
        {
            // Arrange
            string password = "Test123";

            // Act
            string hash = PasswordHelper.HashPassword(password);

            // Assert
            foreach (char c in hash)
            {
                Assert.IsTrue(
                    (c >= '0' && c <= '9') || (c >= 'a' && c <= 'f'),
                    "Le hash doit contenir uniquement des caractères hexadécimaux en minuscules (0-9, a-f)"
                );
            }
        }

        #endregion

        #region Tests VerifyPassword

        [Test]
        [Description("Vérifie que VerifyPassword retourne true pour un mot de passe correct")]
        public void VerifyPassword_CorrectPassword_ReturnsTrue()
        {
            // Arrange
            string password = "test123";
            string hash = PasswordHelper.HashPassword(password);

            // Act
            bool result = PasswordHelper.VerifyPassword(password, hash);

            // Assert
            Assert.IsTrue(result, "VerifyPassword doit retourner true pour le mot de passe correct");
        }

        [Test]
        [Description("Vérifie que VerifyPassword retourne false pour un mot de passe incorrect")]
        public void VerifyPassword_IncorrectPassword_ReturnsFalse()
        {
            // Arrange
            string correctPassword = "test123";
            string incorrectPassword = "test124";
            string hash = PasswordHelper.HashPassword(correctPassword);

            // Act
            bool result = PasswordHelper.VerifyPassword(incorrectPassword, hash);

            // Assert
            Assert.IsFalse(result, "VerifyPassword doit retourner false pour un mot de passe incorrect");
        }

        [Test]
        [Description("Vérifie que VerifyPassword est sensible à la casse")]
        public void VerifyPassword_CaseSensitive_ReturnsFalse()
        {
            // Arrange
            string password = "Test123";
            string wrongCasePassword = "test123";
            string hash = PasswordHelper.HashPassword(password);

            // Act
            bool result = PasswordHelper.VerifyPassword(wrongCasePassword, hash);

            // Assert
            Assert.IsFalse(result, "VerifyPassword doit être sensible à la casse");
        }

        [Test]
        [Description("Vérifie que VerifyPassword fonctionne avec le hash admin")]
        public void VerifyPassword_AdminHash_ReturnsTrue()
        {
            // Arrange
            string password = "admin";
            string knownHash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";

            // Act
            bool result = PasswordHelper.VerifyPassword(password, knownHash);

            // Assert
            Assert.IsTrue(result, "VerifyPassword doit accepter le mot de passe 'admin' avec son hash connu");
        }

        [Test]
        [Description("Vérifie qu'une exception est levée si le mot de passe est null")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyPassword_NullPassword_ThrowsArgumentNullException()
        {
            // Arrange
            string hash = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918";

            // Act
            PasswordHelper.VerifyPassword(null, hash);

            // Assert est fait par l'attribut ExpectedException
        }

        [Test]
        [Description("Vérifie qu'une exception est levée si le hash est null")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void VerifyPassword_NullHash_ThrowsArgumentNullException()
        {
            // Act
            PasswordHelper.VerifyPassword("test", null);

            // Assert est fait par l'attribut ExpectedException
        }

        [Test]
        [Description("Vérifie que VerifyPassword retourne false pour un hash invalide")]
        public void VerifyPassword_InvalidHash_ReturnsFalse()
        {
            // Arrange
            string password = "test123";
            string invalidHash = "invalid_hash_not_64_chars";

            // Act
            bool result = PasswordHelper.VerifyPassword(password, invalidHash);

            // Assert
            Assert.IsFalse(result, "VerifyPassword doit retourner false pour un hash invalide");
        }

        #endregion

        #region Tests ValidatePasswordComplexity

        [Test]
        [Description("Vérifie qu'un mot de passe de 6+ caractères est accepté")]
        public void ValidatePasswordComplexity_MinimumLength_ReturnsTrue()
        {
            // Arrange
            string password = "123456";

            // Act
            bool result = PasswordHelper.ValidatePasswordComplexity(password);

            // Assert
            Assert.IsTrue(result, "Un mot de passe de 6 caractères minimum doit être accepté");
        }

        [Test]
        [Description("Vérifie qu'un mot de passe trop court est rejeté")]
        public void ValidatePasswordComplexity_TooShort_ReturnsFalse()
        {
            // Arrange
            string password = "12345";

            // Act
            bool result = PasswordHelper.ValidatePasswordComplexity(password);

            // Assert
            Assert.IsFalse(result, "Un mot de passe de moins de 6 caractères doit être rejeté");
        }

        [Test]
        [Description("Vérifie qu'un mot de passe null est rejeté")]
        public void ValidatePasswordComplexity_NullPassword_ReturnsFalse()
        {
            // Act
            bool result = PasswordHelper.ValidatePasswordComplexity(null);

            // Assert
            Assert.IsFalse(result, "Un mot de passe null doit être rejeté");
        }

        [Test]
        [Description("Vérifie qu'un mot de passe vide est rejeté")]
        public void ValidatePasswordComplexity_EmptyPassword_ReturnsFalse()
        {
            // Act
            bool result = PasswordHelper.ValidatePasswordComplexity(string.Empty);

            // Assert
            Assert.IsFalse(result, "Un mot de passe vide doit être rejeté");
        }

        [Test]
        [Description("Vérifie qu'un mot de passe avec espaces est accepté si la longueur est suffisante")]
        public void ValidatePasswordComplexity_WithSpaces_ReturnsTrue()
        {
            // Arrange
            string password = "test 123";

            // Act
            bool result = PasswordHelper.ValidatePasswordComplexity(password);

            // Assert
            Assert.IsTrue(result, "Un mot de passe avec espaces doit être accepté si la longueur est suffisante");
        }

        #endregion
    }
}
