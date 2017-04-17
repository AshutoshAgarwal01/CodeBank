using System;

namespace CodeBank.Misc
{
    public class LongestPalindromicSubstring
    {
        /// <summary>
        /// Dynamic programming solution
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string LongestPalindromicSubstring_String_Dp(string s)
        {
            var data = new bool[s.Length, s.Length];
            int maxLen = 1;
            int beginsAtIndex = 0;

            for (int i = 0; i < s.Length; i++)
            {
                data[i, i] = true;
                if (i > 0 && s[i] == s[i - 1])
                {
                    data[i - 1, i] = true;
                    if (maxLen < 2)
                    {
                        maxLen = 2;
                        beginsAtIndex = i - 2 + 1;
                    }
                }
            }

            for (var l = 3; l <= s.Length; l++)
            {
                for (var i = l - 1; i < s.Length; i++)
                {
                    if (s[i] == s[i - l + 1] && data[i - l + 2, i - 1])
                    {
                        data[i - l + 1, i] = true;
                        if (maxLen < l)
                        {
                            maxLen = l;
                            beginsAtIndex = i - l + 1;
                        }
                    }
                }
            }
            return s.Substring(beginsAtIndex, maxLen);
        }

        public static string LongestPalindromicSubstring_String(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
            {
                return s;
            }

            var data = new int[s.Length];
            data[0] = 1;
            int centerIndex = 0;

            //Deal with odd length
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
                if (s[i] == s[i - 1])
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
