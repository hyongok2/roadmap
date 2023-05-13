using System.Text.RegularExpressions;

namespace RMDesktopUI.Library.Helper
{
    public static class ValidChecker
    {
        public static bool IsValidEmail(string email)
        {
            bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
            return valid;
        }

        public static bool IsValidPassword(string pass)
        {
            //5자리 이상
            if (pass != null && pass.Length < 5) return false;

            //숫자1이상, 영문1이상, 특수문자1이상
            Regex regexPass = new Regex(@"^(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{4,}$", RegexOptions.IgnorePatternWhitespace);
            return regexPass.IsMatch(pass);
        }
    }
}
