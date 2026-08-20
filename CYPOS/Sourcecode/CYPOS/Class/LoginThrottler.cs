using System;
using System.Collections.Generic;

namespace cypos
{
    public static class LoginThrottler
    {
        private const int MaxAttempts = 5;
        private const int LockoutMinutes = 15;

        private static readonly Dictionary<string, LoginAttemptInfo> Attempts =
            new Dictionary<string, LoginAttemptInfo>(StringComparer.OrdinalIgnoreCase);

        public static bool IsLockedOut(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            LoginAttemptInfo info;
            if (!Attempts.TryGetValue(username, out info))
                return false;

            if (info.FailedCount >= MaxAttempts)
            {
                if (DateTime.Now - info.LastAttempt < TimeSpan.FromMinutes(LockoutMinutes))
                    return true;

                Attempts.Remove(username);
                return false;
            }

            return false;
        }

        public static int RemainingLockoutSeconds(string username)
        {
            LoginAttemptInfo info;
            if (!Attempts.TryGetValue(username, out info))
                return 0;

            if (info.FailedCount < MaxAttempts)
                return 0;

            TimeSpan elapsed = DateTime.Now - info.LastAttempt;
            TimeSpan lockout = TimeSpan.FromMinutes(LockoutMinutes);
            if (elapsed >= lockout)
                return 0;

            return (int)(lockout - elapsed).TotalSeconds;
        }

        public static void RecordFailedAttempt(string username)
        {
            if (string.IsNullOrEmpty(username))
                return;

            LoginAttemptInfo info;
            if (!Attempts.TryGetValue(username, out info))
            {
                info = new LoginAttemptInfo();
                Attempts[username] = info;
            }

            info.FailedCount++;
            info.LastAttempt = DateTime.Now;
        }

        public static void RecordSuccess(string username)
        {
            if (string.IsNullOrEmpty(username))
                return;

            Attempts.Remove(username);
        }

        private class LoginAttemptInfo
        {
            public int FailedCount;
            public DateTime LastAttempt;
        }
    }
}
