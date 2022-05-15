using System;

namespace MVCFirmaCagri.Encription
{
    public class Enc
    {
        public static string Log(string text)
        {
            string password = string.Empty;
            if (!(text is null))
            {
                char[] array = text.ToCharArray();
                foreach (char item in array)
                {
                    password += Convert.ToChar(item + 35);
                }
                return password;
            }
            return password;
        }
        public static string Description(string text)
        {
            string password = string.Empty;
            if (!(text is null))
            {
                char[] array = text.ToCharArray();
                foreach (char item in array)
                {
                    password += Convert.ToChar(item - 35);
                }
                return password;
            }
            return password;
        }
    }
}