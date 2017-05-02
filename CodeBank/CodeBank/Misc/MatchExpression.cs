using System.Collections.Generic;
using CodeBank.Trie;

namespace CodeBank.Misc
{
    public class MatchExpression
    {
        private List<string> Expressions { get; set; }
        private TrieNode trie;


        public MatchExpression()
        {
            Expressions = new List<string>();
            Expressions.Add("Hello {0}");
            Expressions.Add("Hello {0} world.");
            Expressions.Add("Hello {0} you have got {1} cars.");

            trie = new TrieNode("#@#root#@#", false );
            foreach(var e in Expressions)
            {
                var strings = e.Split(' ');
                var q = new Queue<string>();

                foreach(var s in strings)
                {
                    q.Enqueue(s);
                }

                TrieNode.AddString(trie, q);
            }
        }

        public List<string> GetAllExpressions()
        {
            var result = new List<string>();
            TrieNode.GetAllStrings(trie, result, "");
            return result;
        }

        public bool ExactMatch(string str)
        {
            var strings = str.Split(' ');
            var root = trie;
            foreach(var s in strings)
            {
                if(root.Children.ContainsKey(s))
                    root = root.Children[s];
                else
                    return false;
            }
            if (!root.IsEndOfWord)
                return false;
            return true;
        }
    }
}
