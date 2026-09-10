using System;
using System.Text.RegularExpressions;

namespace cypos
{
    public static class InputValidator
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            RegexOptions.Compiled);

        private static readonly Regex PhoneRegex = new Regex(
            @"^[\d\s\+\-\(\)]{7,20}$",
            RegexOptions.Compiled);

        private static readonly Regex UsernameRegex = new Regex(
            @"^[a-zA-Z0-9_]{3,50}$",
            RegexOptions.Compiled);

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return EmailRegex.IsMatch(email.Trim());
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;
            return PhoneRegex.IsMatch(phone.Trim());
        }

        public static bool IsValidUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;
            return UsernameRegex.IsMatch(username.Trim());
        }

        public static bool IsValidLoginCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return false;
            string trimmed = code.Trim();
            if (trimmed.Length < 2 || trimmed.Length > 4)
                return false;
            for (int i = 0; i < trimmed.Length; i++)
            {
                if (!char.IsDigit(trimmed[i]))
                    return false;
            }
            return true;
        }

        public static bool IsValidPassword(string password, out string errorMessage)
        {
            errorMessage = null;

            if (string.IsNullOrEmpty(password))
            {
                errorMessage = "Le mot de passe ne peut pas etre vide";
                return false;
            }

            if (password.Length < 4)
            {
                errorMessage = "Le mot de passe doit contenir au moins 4 caracteres";
                return false;
            }

            if (password.Length > 100)
            {
                errorMessage = "Le mot de passe ne doit pas depasser 100 caracteres";
                return false;
            }

            return true;
        }

        public static bool IsValidName(string name, int maxLength = 100)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;
            if (name.Trim().Length > maxLength)
                return false;
            return true;
        }

        public static string Sanitize(string input, int maxLength = 200)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            string trimmed = input.Trim();
            if (trimmed.Length > maxLength)
                trimmed = trimmed.Substring(0, maxLength);

            return trimmed;
        }

        public static bool IsValidAmount(string amount, out decimal result)
        {
            result = 0;
            if (string.IsNullOrWhiteSpace(amount))
                return false;
            return decimal.TryParse(amount.Trim(), out result) && result >= 0;
        }
    }
}
