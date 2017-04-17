using System.Collections.Generic;

namespace CodeBank.Misc
{
    public class LongestWord
    {
        public static string FindLongestWord(string s, IList<string> d)
        {
            var result = string.Empty; 
            foreach(var word in d)
            {
                int i = 0;

                for(var j = 0; j < s.Length && i < word.Length; j++)
                {
                    if(s[j] == word[i])
                    {
                        i++;
                    }
                }

                if(i == word.Length)
                {
                    if(word.Length > result.Length)
                    {
                        result = word;
                    }
                    else if(word.Length == result.Length && word.CompareTo(result) < 0)
                    {
                        result = word;
                    }
                }
            }
            return result;
        }
    }
}
