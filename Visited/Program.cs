using System;
using System.Collections.Generic;
using System.Linq;

namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfUrls = 10;

            var trie = new Trie();

            var urls = Generator.GenerateRandomUrls(numberOfUrls, "http://www.", ".com")
                .Union(Generator.GenerateRandomUrls(numberOfUrls, "https://www", ".com")
                .Union(Generator.GenerateRandomUrls(numberOfUrls, "https://www2.", ".com")));

            Crawl(trie, urls.SelectMany(u => Generator.GenerateRandomUrls(numberOfUrls * 2, $"{u}/", string.Empty)));

            Console.ReadKey();
        }

        private static void Crawl(Trie trie, IEnumerable<string> urls)
        {
            foreach (var url in urls)
            {
                var allocated = trie.CheckCreate(url);

                var savings = 1 - ((double)allocated / url.Length);

                Console.WriteLine($"Len:{url.Length:####} \tAlloc: {allocated:####} \tSavings: {savings:P} \t{url}");
            }
        }

        private class TrieNode
        {
            private readonly Dictionary<char, TrieNode> _childNodes = new Dictionary<char, TrieNode>();

            public bool HasChildren(char ch)
                => _childNodes.ContainsKey(ch);

            public void AddChildNode(char ch)
                => _childNodes.Add(ch, new Program.TrieNode());

            public Program.TrieNode GetChildNode(char ch)
                => _childNodes.TryGetValue(ch, out var child) ? child : null;
        }

        private class Trie
        {
            private readonly TrieNode _root = new TrieNode();

            public int CheckCreate(string value)
            {
                var current = _root;

                var created = 0;

                foreach (var c in value)
                {
                    if (!current.HasChildren(c))
                    {
                        created++;

                        current.AddChildNode(c);
                    }

                    current = current.GetChildNode(c);
                }

                if (current.HasChildren(char.MinValue)) return created;

                current.AddChildNode(char.MinValue);

                return created;
            }
        }
    }
}