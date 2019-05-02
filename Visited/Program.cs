using System;
using System.Collections.Generic;

namespace Trie
{
    class Program
    {
        private static readonly List<string> Urls = new List<string>()
        {
            "https://www.google.com",
            "https://www.google.com/gmail",
            "https://www.microsoft.com",
            "https://www.microsoft.com/products",
            "https://www.microsoft.com/products/office365",
            "https://www.microsoft.com/products/visualstudio"
        };

        static void Main(string[] args)
        {
            var trie = new Trie();

            Urls.ForEach(url => Console.WriteLine($"Created: {trie.CheckCreate(url)} - {url}"));

            Urls.ForEach(url => Console.WriteLine($"Created: {trie.CheckCreate(url)} - {url}"));

            Console.ReadKey();
        }

        private class TrieNode
        {
            private readonly Dictionary<char, TrieNode> _childNodes = new Dictionary<char, TrieNode>();

            public bool HasChildren(char ch)
                => _childNodes.ContainsKey(ch);

            public void AddChildNode(char ch)
                => _childNodes.Add(ch, new TrieNode());

            public TrieNode GetChildNode(char ch)
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