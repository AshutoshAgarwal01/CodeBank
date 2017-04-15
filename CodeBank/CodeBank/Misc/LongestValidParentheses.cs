using System;
using System.Collections.Generic;

namespace CodeBank.Misc
{
    public class LongestValidParentheses
    {
        public static int LongestValidParenthesesCount_O1(string s)
        {
            var st = new Stack<int>();
            var data = new int[s.Length];
            int count = 0;
            foreach (var c in s)
            {
                if (c == '(')
                {
                    st.Push(count);
                }
                else
                {
                    if (st.Count > 0)
                    {
                        data[count] = 1;
                        data[st.Pop()] = 1;
                    }
                }
                count++;
            }

            int longest = 0;
            int temp = 0;
            foreach (var d in data)
            {
                if (d == 0)
                {
                    longest = Math.Max(longest, temp);
                    temp = 0;
                }
                else
                {
                    temp++;
                }
            }

            return Math.Max(longest, temp);
        }

        public static int LongestValidParenthesesCount(string s)
        {
            int longestSoFar = 0;

            for (int i = 0; i < s.Length; i++)
            {
                for (int l = 2; i + l <= s.Length; l++)
                {
                    if (IsValid(s, i, l))
                    {
                        longestSoFar = Math.Max(l, longestSoFar);
                    }
                }
            }
            return longestSoFar;
        }

        private static bool IsValid(string s, int begin, int length)
        {
            var st = new Stack<char>();
            for (int i = begin; i < begin + length; i++)
            {
                if (st.Count == 0 || s[i] == '(')
                {
                    st.Push(s[i]);
                }
                else if (st.Peek() == '(')
                {
                    st.Pop();
                }
                else
                {
                    st.Push(s[i]);
                }
            }
            return st.Count == 0;
        }
    }
}
