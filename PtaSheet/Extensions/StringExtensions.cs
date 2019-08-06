using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PtaSheet.Extensions
{
    public static class StringExtensions
    {

        /// <summary>
        /// Hashes a given string and returns the SHA1 output.
        /// </summary>
        /// <param name="source">The source string to hash.</param>
        /// <returns></returns>
        public static string Hash(this string source)
        {

            var buffer = System.Text.Encoding.UTF8.GetBytes(source);
            var cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "").ToLower();

        }

    }
}
