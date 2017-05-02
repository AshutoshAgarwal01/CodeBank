using System.Collections.Generic;

namespace CodeBank.Trie
{
    public class TrieNode
    {
        public string Data { get; private set; }
        public bool IsParam { get; private set; }
        public bool IsEndOfWord { get; private set; }
        public Dictionary<string, TrieNode> Children { get; private set; }

        public TrieNode(string d, bool isParam)
        {
            Data = d;
            IsParam = isParam;
            Children = new Dictionary<string, TrieNode>();
        }

        public TrieNode AddChild(string d)
        {
            var node = new TrieNode(d, d[0] == '{');
            Children.Add(d, node);
            return node;
        }

        public static void AddString(TrieNode root, Queue<string> q)
        {
            if(q == null || q.Count == 0)
            {
                root.IsEndOfWord = true;
                return;
            }

            var s = q.Dequeue();

            var child = root.Children.ContainsKey(s) ? root.Children[s] : root.AddChild(s);
            AddString(child, q);
        }

        public static void GetAllStrings(TrieNode root, List<string> strings, string curStr)
        {
            foreach(var s in root.Children.Keys)
            {
                var str = string.IsNullOrEmpty(curStr) ? root.Children[s].Data : curStr + ' ' + root.Children[s].Data;
                if (root.Children[s].IsEndOfWord)
                {
                    strings.Add(str);
                }

                GetAllStrings(root.Children[s], strings, str);
            }
        }
    }
}
