using System;

namespace CodeBank.Misc
{
    public class LongestPalindromicSubstring
    {
        public static string LongestPalindromicSubstring_String(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
            {
                return s;
            }

            var data = new int[s.Length];
            data[0] = 1;
            int centerIndex = 0;

            //Del with odd length
            for (var i = 1; i < s.Length; i++)
            {
                data[i] = 1;
                var begin = i - 1;
                var end = i + 1;
                while (begin >= 0 && end < s.Length && s[begin] == s[end])
                {
                    data[i] += 2;
                    centerIndex = (data[centerIndex] < data[i]) ? i : centerIndex;
                    begin--;
                    end++;
                }
            }

            //Then with even lengths
            for (var i = 1; i < s.Length; i++)
            {
                if(s[i] == s[i-1])
                {
                    var currLen = 2;
                    var end = i + 1;
                    var begin = i - 2;
                    while (begin >= 0 && end < s.Length && s[begin] == s[end])
                    {
                        currLen += 2;
                        begin--;
                        end++;
                    }
                    data[i] = Math.Max(currLen, data[i]);
                    centerIndex = (data[centerIndex] < data[i]) ? i : centerIndex;
                }
            }

            return GetSubString(s, data, data[centerIndex]);
        }

        private static string GetSubString(string s, int[] data, int maxLength)
        {
            int i = 0;
            for (; i < data.Length; i++)
            {
                if (data[i] == maxLength)
                {
                    break;
                }
            }
            return s.Substring(i - data[i] / 2, data[i]);
        }
    }
}
