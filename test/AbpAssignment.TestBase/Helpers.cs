using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpAssignment
{
    public static class Helpers
    {
        public static string GenerateTestingString(int length)
        {
            string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
            "abcdefghijklmnopqrstuvwxyz" +
            "0123456789";

            Random random = new Random();

            var result = Enumerable.Repeat(ALPHABET, length)
                .Select(s => s[random.Next(s.Length)]).ToArray();

            return new string(result);
        }
    }
}
