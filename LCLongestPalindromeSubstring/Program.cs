using System;

namespace LCLongestPalindromeSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "decbdbced";

            if (s.Length == 0)
            {
                Console.WriteLine(0);
            }
            if (s.Length == 1)
            {
                Console.WriteLine(1);
            }

            int longestSubstring = 0;
            int currentCount = 1;

            //odd pallindromes
            for (int i = s.Length / 2, j = s.Length / 2; i < s.Length && j > 0; i++, j--)
            {
                if (i == j)
                {
                    continue;
                }

                if (s[i].Equals(s[j]))
                {
                    currentCount += 2;

                    if (currentCount > longestSubstring)
                    {
                        longestSubstring = currentCount;
                    }
                }
                else
                {
                    currentCount = 1;
                    continue;
                }
            }

            currentCount = 2;

            //even palindromes
            for (int i = (s.Length / 2), j = (s.Length / 2) - 1; i < s.Length && j > 0; i++, j--)
            {
                if (i - 1 == j)
                {
                    continue;
                }
                if (s[i].Equals(s[j]))
                {
                    currentCount += 2;

                    if (currentCount > longestSubstring)
                    {
                        longestSubstring = currentCount;
                    }
                }
                else
                {
                    currentCount = 2;
                    continue;
                }
            }
            Console.WriteLine(longestSubstring);
        }
    }
}
