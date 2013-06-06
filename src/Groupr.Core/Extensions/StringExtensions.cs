using System.Security.Cryptography;
using System.Text;

namespace Groupr.Core.Extensions
{
    public static class StringExtensions
    {
         public static string MD5(this string instance)
         {
             return instance.Hash(new MD5CryptoServiceProvider());
         }

        public static string Hash(this string instance, HashAlgorithm algorith)
        {
            var bytes = Encoding.UTF8.GetBytes(instance);
            var hash = algorith.ComputeHash(bytes);

            var builder = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}