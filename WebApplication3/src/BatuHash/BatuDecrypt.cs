using System;
using System.Text;
using HashAndSaltConsoleApp.src.Data;

namespace HashAndSaltConsoleApp.src.BatuHash
{
    internal class BatuDecrypt
    {
        public static string Decrypt(string input)
        {
            var builder = new StringBuilder();
            var hexParts = SplitIntoChunks(input, 4);

            foreach (var hex in hexParts)
            {
                if (MappingData.hexToCharMap.ContainsKey(hex))
                {
                    builder.Append(MappingData.hexToCharMap[hex]);
                }
                else
                {
                    builder.Append('?');
                }
            }

            return builder.ToString();
        }

        private static IEnumerable<string> SplitIntoChunks(string input, int chunkSize)
        {
            for (int i = 0; i < input.Length; i += chunkSize)
            {
                yield return input.Substring(i, Math.Min(chunkSize, input.Length - i));
            }
        }
    }
}
