using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
        public bool WordEnd = false;
        public int Count = 0;
    }

    public class Trie
    {       
        //public TrieNode root = new TrieNode();

        public static void AddWord(TrieNode root, string word)
        {
            var node = root;

            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                {
                    node.Children[c] = new TrieNode();
                }

                node = node.Children[c];
                node.Count++;
            }

            node.WordEnd = true;
        }

        public bool Search(TrieNode root, string word)
        {
            var node = root;

            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                    return false;

                node = node.Children[c];
            }

            return node.WordEnd;
        }
    }
    
}
