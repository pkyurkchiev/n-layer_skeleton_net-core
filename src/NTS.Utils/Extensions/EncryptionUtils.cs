namespace NTS.Utils.Extensions
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class EncryptionUtils
    {
        #region Encryption

        public static string ToSHA512(this string str)
        {
            string result = string.Empty;

            using (SHA512 sha512 = SHA512.Create())
            {
                result = Convert.ToBase64String(sha512.ComputeHash(str.ToBytes()));
            }

            return result;
        }

        public static byte[] ToBytes(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        #endregion
    }
}
