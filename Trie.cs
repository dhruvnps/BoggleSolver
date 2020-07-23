using System;
using System.Collections.Generic;
using System.Linq;

namespace BoggleSolver
{
    public class Trie
    {
        private readonly Dictionary<char, Trie> _node;

        private Trie()
        {
            _node = new Dictionary<char, Trie>();
        }

        public static Trie BuildTrie(IEnumerable<string> words)
        {
            Trie trie = new Trie();
            foreach (string word in words)
            {
                Trie currentNode = trie;
                foreach (char letter in word)
                {
                    if (!currentNode._node.ContainsKey(letter))
                    {
                        currentNode._node[letter] = new Trie();
                    }
                    currentNode = currentNode._node[letter];
                }
                currentNode._node['*'] = null;
            }
            return trie;
        }

        public bool ContainsWord(string word)
        {
            Trie finalNode = GetFinalNode(word);
            return finalNode != null && finalNode._node.ContainsKey('*');
        }

        public bool ContainsPrefix(string prefix)
        {
            Trie finalNode = GetFinalNode(prefix);
            return finalNode != null;
        }

        private Trie GetFinalNode(string word)
        {
            Trie currentNode = this;
            foreach (char letter in word)
            {
                if (!currentNode._node.TryGetValue(letter, out currentNode))
                {
                    return null;
                }
            }
            return currentNode;
        }
    }
}