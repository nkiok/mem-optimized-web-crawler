using System;
using System.Collections.Generic;
using System.Linq;

namespace Trie
{
    public static class Generator
    {
        private static readonly Random Random = new Random();

        public static IEnumerable<string> GenerateRandomUrls(int count, string prefix, string suffix)
            => Enumerable.Range(1, count).Select(x => $"{prefix}{RandomString(Random.Next(10, 30))}{suffix}");

        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}