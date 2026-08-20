using System;
using NUnit.Framework;
using cypos;

namespace CYPOS.Tests
{
    [TestFixture]
    public class InputValidatorTests
    {
        #region Email Validation

        [Test]
        public void IsValidEmail_ValidEmail_ReturnsTrue()
        {
            Assert.IsTrue(InputValidator.IsValidEmail("user@example.com"));
            Assert.IsTrue(InputValidator.IsValidEmail("test.name@domain.co"));
        }

        [Test]
        public void IsValidEmail_InvalidEmail_ReturnsFalse()
        {
            Assert.IsFalse(InputValidator.IsValidEmail(""));
            Assert.IsFalse(InputValidator.IsValidEmail(null));
            Assert.IsFalse(InputValidator.IsValidEmail("notanemail"));
            Assert.IsFalse(InputValidator.IsValidEmail("@domain.com"));
            Assert.IsFalse(InputValidator.IsValidEmail("user@"));
        }

        #endregion

        #region Phone Validation

        [Test]
        public void IsValidPhone_ValidPhone_ReturnsTrue()
        {
            Assert.IsTrue(InputValidator.IsValidPhone("0612345678"));
            Assert.IsTrue(InputValidator.IsValidPhone("+221 77 123 4567"));
            Assert.IsTrue(InputValidator.IsValidPhone("(01) 234-5678"));
        }

        [Test]
        public void IsValidPhone_InvalidPhone_ReturnsFalse()
        {
            Assert.IsFalse(InputValidator.IsValidPhone(""));
            Assert.IsFalse(InputValidator.IsValidPhone(null));
            Assert.IsFalse(InputValidator.IsValidPhone("abc"));
            Assert.IsFalse(InputValidator.IsValidPhone("12"));
        }

        #endregion

        #region Username Validation

        [Test]
        public void IsValidUsername_ValidUsername_ReturnsTrue()
        {
            Assert.IsTrue(InputValidator.IsValidUsername("admin"));
            Assert.IsTrue(InputValidator.IsValidUsername("user_123"));
            Assert.IsTrue(InputValidator.IsValidUsername("CashierA"));
        }

        [Test]
        public void IsValidUsername_InvalidUsername_ReturnsFalse()
        {
            Assert.IsFalse(InputValidator.IsValidUsername(""));
            Assert.IsFalse(InputValidator.IsValidUsername(null));
            Assert.IsFalse(InputValidator.IsValidUsername("ab"));
            Assert.IsFalse(InputValidator.IsValidUsername("user name"));
            Assert.IsFalse(InputValidator.IsValidUsername("user@name"));
        }

        #endregion

        #region Password Validation

        [Test]
        public void IsValidPassword_ValidPassword_ReturnsTrue()
        {
            string error;
            Assert.IsTrue(InputValidator.IsValidPassword("password", out error));
            Assert.IsNull(error);
        }

        [Test]
        public void IsValidPassword_TooShort_ReturnsFalse()
        {
            string error;
            Assert.IsFalse(InputValidator.IsValidPassword("12345", out error));
            Assert.IsNotNull(error);
        }

        [Test]
        public void IsValidPassword_Empty_ReturnsFalse()
        {
            string error;
            Assert.IsFalse(InputValidator.IsValidPassword("", out error));
            Assert.IsNotNull(error);
        }

        [Test]
        public void IsValidPassword_TooLong_ReturnsFalse()
        {
            string error;
            string longPassword = new string('a', 101);
            Assert.IsFalse(InputValidator.IsValidPassword(longPassword, out error));
            Assert.IsNotNull(error);
        }

        #endregion

        #region Sanitize

        [Test]
        public void Sanitize_TrimsWhitespace()
        {
            Assert.AreEqual("hello", InputValidator.Sanitize("  hello  "));
        }

        [Test]
        public void Sanitize_TruncatesLongInput()
        {
            string longInput = new string('x', 300);
            string result = InputValidator.Sanitize(longInput, 50);
            Assert.AreEqual(50, result.Length);
        }

        [Test]
        public void Sanitize_NullReturnsEmpty()
        {
            Assert.AreEqual(string.Empty, InputValidator.Sanitize(null));
        }

        #endregion

        #region Amount Validation

        [Test]
        public void IsValidAmount_ValidAmount_ReturnsTrue()
        {
            decimal result;
            Assert.IsTrue(InputValidator.IsValidAmount("100.50", out result));
            Assert.AreEqual(100.50m, result);
        }

        [Test]
        public void IsValidAmount_Invalid_ReturnsFalse()
        {
            decimal result;
            Assert.IsFalse(InputValidator.IsValidAmount("abc", out result));
            Assert.IsFalse(InputValidator.IsValidAmount("", out result));
            Assert.IsFalse(InputValidator.IsValidAmount(null, out result));
        }

        #endregion
    }
}
