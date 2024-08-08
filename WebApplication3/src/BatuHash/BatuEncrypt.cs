using System;
using System.Text;
using HashAndSaltConsoleApp.src.Data;

namespace HashAndSaltConsoleApp.src.BatuHash
{
    internal class BatuEncrypt
    {
        public static string Encrypt(string input)
        {
            var builder = new StringBuilder();

            foreach (var ch in input.ToUpper())
            {
                if (MappingData.charToHexMap.ContainsKey(ch))
                {
                    builder.Append(MappingData.charToHexMap[ch]);
                }
                else
                {
                    builder.Append("XXXX");
                }
            }

            return builder.ToString();
        }
    }
}
