using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortify.Library
{
    public class URLShortener
    {
        private static readonly string Alphabet = "abcdefghkmnpqrstuvwxyzABCDEFGHJKMNPQRSTUVWXYZ23456789";
        private static readonly int Base = Alphabet.Length;

        public static string Encode(int num)
        {
            StringBuilder sb = new StringBuilder();

            while (num > 0)
            {
                sb.Append(Alphabet[(num % Base)]);
                num /= Base;
            }

            StringBuilder builder = new StringBuilder();
            for (int i = sb.Length - 1; i >= 0; --i)
            {
                builder.Append(sb[i]);
            }
            return builder.ToString();
        }

        public static int Decode(string str)
        {
            int num = 0;

            for (int i = 0, len = str.Length; i < len; ++i)
            {
                num = num * Base + Alphabet.IndexOf(str[(i)]);
            }

            return num;
        }
    }
}
