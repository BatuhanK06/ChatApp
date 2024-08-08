﻿using System;
using System.Collections.Generic;
using HashAndSaltConsoleApp.src.Data;

namespace HashAndSaltConsoleApp.src.IsValid
{
    internal class IsValid
    {
        public static bool IsValidForEncryption(string input)
        {
            var charToHexMap = new Dictionary<char, string>
            {
                {'A', "0a1Z"}, {'B', "0Y2n"}, {'C', "0w3X"}, {'D', "0W4k"},
                {'E', "0b5V"}, {'F', "0U6m"}, {'G', "0q7U"}, {'H', "0T8w"},
                {'I', "0c9S"}, {'J', "1S0u"}, {'K', "1a1R"}, {'L', "1Q2h"},
                {'M', "1d3O"}, {'N', "1O4y"}, {'O', "1x5A"}, {'P', "1B6p"},
                {'Q', "1e7C"}, {'R', "1C8t"}, {'S', "1b9D"}, {'T', "2E0v"},
                {'U', "2f1L"}, {'V', "2G2r"}, {'W', "2y3H"}, {'X', "2Z4s"},
                {'Y', "2g5J"}, {'Z', "2K6e"}, {' ', "2z7M"}, {'.', "2D8a"},
                {',', "2r9D"}, {':', "3T0w"}, {';', "3c1V"}, {'-', "3Q2w"},
                {'_', "3k3L"}, {'*', "3O4m"}, {'?', "3j5U"}, {'=', "3R6x"},
                {'&', "3c7Y"}, {'%', "3U8a"}, {'+', "3v9B"}, {'$', "4T0l"},
                {'^', "4a1B"}, {'#', "4B2a"}, {'!', "4n3X"}, {'İ', "4M4n"},
                {'Ü', "4z5C"}, {'Ç', "4L6k"}, {'Ö', "4f7D"}, {'Ğ', "4R8f"},
                {'Ş', "4m9T"}, {'0', "5a0S"}, {'1', "5n1S"}, {'2', "5D2c"},
                {'3', "5F3k"}, {'4', "5d4S"}, {'5', "5c5Y"}, {'6', "5D6e"},
                {'7', "5P8t"}, {'8', "5v9B"}, {'9', "6E0a"}, {'€', "6D2p"},
                {'k', "6w3X"}, {'ß', "6A4c"}, {'"', "6S5e"}
            };

            foreach (var ch in input.ToUpper())
            {
                if (!charToHexMap.ContainsKey(ch) && !char.IsWhiteSpace(ch))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidForDecryption(string input)
        {
            if (input.Length % 4 != 0)
            {
                return false;
            }

            var hexParts = SplitIntoChunks(input, 4);
            var hexToCharMap = new Dictionary<string, char>
            {
                {"0a1Z", 'A'}, {"0Y2n", 'B'}, {"0w3X", 'C'}, {"0W4k", 'D'},
                {"0b5V", 'E'}, {"0U6m", 'F'}, {"0q7U", 'G'}, {"0T8w", 'H'},
                {"0c9S", 'I'}, {"1S0u", 'J'}, {"1a1R", 'K'}, {"1Q2h", 'L'},
                {"1d3O", 'M'}, {"1O4y", 'N'}, {"1x5A", 'O'}, {"1B6p", 'P'},
                {"1e7C", 'Q'}, {"1C8t", 'R'}, {"1b9D", 'S'}, {"2E0v", 'T'},
                {"2f1L", 'U'}, {"2G2r", 'V'}, {"2y3H", 'W'}, {"2Z4s", 'X'},
                {"2g5J", 'Y'}, {"2K6e", 'Z'}, {"2z7M", ' '}, {"2D8a", '.'},
                {"2r9D", ','}, {"3T0w", ':'}, {"3c1V", ';'}, {"3Q2w", '-'},
                {"3k3L", '_'}, {"3O4m", '*'}, {"3j5U", '?'}, {"3R6x", '='},
                {"3c7Y", '&'}, {"3U8a", '%'}, {"3v9B", '+'}, {"4T0l", '$'},
                {"4a1B", '^'}, {"4B2a", '#'}, {"4n3X", '!'}, {"4M4n", 'İ'},
                {"4z5C", 'Ü'}, {"4L6k", 'Ç'}, {"4f7D", 'Ö'}, {"4R8f", 'Ğ'},
                {"4m9T", 'Ş'}, {"5a0S", '0'}, {"5n1S", '1'}, {"5D2c", '2'},
                {"5F3k", '3'}, {"5d4S", '4'}, {"5c5Y", '5'}, {"5D6e", '6'},
                {"5P8t", '7'}, {"5v9B", '8'}, {"6E0a", '9'}, {"6D2p", '€'},
                {"6w3X", 'ß'}, {"6S5e", '"'}
            };

            foreach (var hex in hexParts)
            {
                if (!hexToCharMap.ContainsKey(hex))
                {
                    return false;
                }
            }
            return true;
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
