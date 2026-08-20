using System;
using NUnit.Framework;
using cypos;

namespace CYPOS.Tests
{
    [TestFixture]
    public class LoginThrottlerTests
    {
        [SetUp]
        public void SetUp()
        {
            LoginThrottler.RecordSuccess("testuser");
        }

        [Test]
        public void IsLockedOut_NoAttempts_ReturnsFalse()
        {
            Assert.IsFalse(LoginThrottler.IsLockedOut("newuser"));
        }

        [Test]
        public void IsLockedOut_UnderMaxAttempts_ReturnsFalse()
        {
            LoginThrottler.RecordFailedAttempt("testuser");
            LoginThrottler.RecordFailedAttempt("testuser");
            LoginThrottler.RecordFailedAttempt("testuser");

            Assert.IsFalse(LoginThrottler.IsLockedOut("testuser"));
        }

        [Test]
        public void IsLockedOut_AtMaxAttempts_ReturnsTrue()
        {
            for (int i = 0; i < 5; i++)
                LoginThrottler.RecordFailedAttempt("testuser");

            Assert.IsTrue(LoginThrottler.IsLockedOut("testuser"));
        }

        [Test]
        public void RecordSuccess_ClearsAttempts()
        {
            for (int i = 0; i < 5; i++)
                LoginThrottler.RecordFailedAttempt("testuser");

            LoginThrottler.RecordSuccess("testuser");

            Assert.IsFalse(LoginThrottler.IsLockedOut("testuser"));
        }

        [Test]
        public void RemainingLockoutSeconds_WhenNotLocked_ReturnsZero()
        {
            Assert.AreEqual(0, LoginThrottler.RemainingLockoutSeconds("testuser"));
        }

        [Test]
        public void RemainingLockoutSeconds_WhenLocked_ReturnsPositive()
        {
            for (int i = 0; i < 5; i++)
                LoginThrottler.RecordFailedAttempt("testuser");

            int seconds = LoginThrottler.RemainingLockoutSeconds("testuser");
            Assert.IsTrue(seconds > 0);
        }

        [Test]
        public void IsLockedOut_NullUsername_ReturnsFalse()
        {
            Assert.IsFalse(LoginThrottler.IsLockedOut(null));
            Assert.IsFalse(LoginThrottler.IsLockedOut(""));
        }
    }
}
