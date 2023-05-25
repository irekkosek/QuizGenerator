using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGenerator.Model
{

    public static class Encryption
    {
        public static string Base64Encode(string plainText)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(bytes);
        }

        public static string Base64Decode(string base64EncodedText)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(base64EncodedText);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
            catch { return base64EncodedText; }
        }
    }
}
