using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Player.Domain;

namespace Player.Helpers
{
    public static class StringExtention
    {
        public static string Cut(this string text, int symbls = 10)
        {
            if (text.Length > symbls - 3)
            {
                return text.Substring(0, symbls - 3) + "...";
            }

            return text;
        }

        public static string Fence(this string text)
        {
            var shift = 0;
            if (text.First().ToString() == text.First().ToString().ToUpper())
            {
                shift = 1;
            }

            string result = string.Empty;

            for (int j = 0; j < text.Length;  j++)
            {
                if (j == shift)
                {
                    result += text[j].ToString().ToUpper();
                    shift += 2;
                }
                else
                {
                    result += text[j].ToString().ToLower();
                }
                
            }

            return result;
        }
    }
}
