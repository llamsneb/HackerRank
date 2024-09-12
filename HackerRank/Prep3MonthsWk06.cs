using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class Prep3MonthsWk06
    {
        /*****Problem: Sherlock and Array*****/
        public static string balancedSums(List<int> arr)
        {
            int tL = 0;
            int tR = 0;
            int total = arr.Sum();

            for (int i = 0; i < arr.Count; i++)
            {
                if (i > 0)
                {
                    tL += arr[i - 1];
                }

                tR = total - tL - arr[i];

                if (tL == tR)
                {
                    return "YES";
                }
            }

            return "NO";
        }

        /*****Problem: Misère Nim*****/
        public static string misereNim(List<int> s)
        {
            // if all piles are 1 stone
            if (s.Sum() == s.Count)
            {
                return s.Count % 2 == 0 ? "First" : "Second";
            }
            else
            {
                int xor = 0;
                foreach (int i in s)
                {
                    xor ^= i;
                }

                return xor == 0 ? "Second" : "First";
            }
        }

        /*****Problem: Gaming Array 1*****/
        public static string gamingArray(List<int> arr)
        {
            int cnt = 0;
            int max = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    cnt++;
                }
            }

            return cnt % 2 == 0 ? "ANDY" : "BOB";
        }

        /*****Problem: Forming a Magic Square*****/

        public static int formingMagicSquare(List<List<int>> s)
        {
            List<List<List<int>>> magic = new List<List<List<int>>> {
                new List<List<int>> {
                    new List<int> {8, 1, 6},
                    new List<int> {3, 5, 7},
                    new List<int> {4, 9, 2}},
                new List<List<int>> {
                    new List<int> {6, 1, 8},
                    new List<int> {7, 5, 3},
                    new List<int> {2, 9, 4}},
                new List<List<int>> {
                    new List<int> {4, 9, 2},
                    new List<int> {3, 5, 7},
                    new List<int> {8, 1, 6}},
                new List<List<int>> {
                    new List<int> {2, 9, 4},
                    new List<int> {7, 5, 3},
                    new List<int> {6, 1, 8}},
                new List<List<int>> {
                    new List<int> {8, 3, 4},
                    new List<int> {1, 5, 9},
                    new List<int> {6, 7, 2}},
                new List<List<int>> {
                    new List<int> {4, 3, 8},
                    new List<int> {9, 5, 1},
                    new List<int> {2, 7, 6}},
                new List<List<int>> {
                    new List<int> {6, 7, 2},
                    new List<int> {1, 5, 9},
                    new List<int> {8, 3, 4}},
                new List<List<int>> {
                    new List<int> {2, 7, 6},
                    new List<int> {9, 5, 1},
                    new List<int> {4, 3, 8}}
            };

            int min = int.MaxValue;
            foreach (List<List<int>> m in magic)
            {
                int total = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        total += Math.Abs(m[i][j] - s[i][j]);
                    }
                }
                if (total < min)
                {
                    min = total;
                }
            }
            return min;
        }

        public static int formingMagicSquareV2(List<List<int>> s)
        {
            List<List<int>> magic = new List<List<int>> {
                new List<int> {8, 1, 6, 3, 5, 7, 4, 9, 2},
                new List<int> {6, 1, 8, 7, 5, 3, 2, 9, 4},
                new List<int> {4, 9, 2, 3, 5, 7, 8, 1, 6},
                new List<int> {2, 9, 4, 7, 5, 3, 6, 1, 8},
                new List<int> {8, 3, 4, 1, 5, 9, 6, 7, 2},
                new List<int> {4, 3, 8, 9, 5, 1, 2, 7, 6},
                new List<int> {2, 7, 6, 9, 5, 1, 4, 3, 8},
                new List<int> {6, 7, 2, 1, 5, 9, 8, 3, 4}};

            int min = int.MaxValue;

            for (int i = 0; i < magic.Count; i++)
            {
                int total = 0;
                for (int j = 0; j < magic[i].Count; j++)
                {
                    total += Math.Abs(s[j / 3][j % 3] - magic[i][j]);
                }
                if (total < min)
                {
                    min = total;
                }
            }

            return min;
        }

        /*****Problem: Recursive Digit Sum*****/
        public static int superDigit(string n, int k)
        {
            if (n.Length == 1)
            {
                return int.Parse(n.ToString());
            }

            long p = 0;
            for (int i = 0; i < n.Length; i++)
            {
                p += int.Parse(n[i].ToString());
            }
            p *= k;
            string pStr = p.ToString();
            while (pStr.Length > 1)
            {
                p = 0;
                for (int i = 0; i < pStr.Length; i++)
                {
                    p += int.Parse(pStr[i].ToString());
                }
                pStr = p.ToString();
            }

            return (int)p;
        }

        /*****Problem: Counter game*****/
        public static string counterGame(long n)
        {
            int cnt = 0;
            int expo = 0;
            while (n != 1)
            {
                if ((n != 0) && ((n & (n - 1)) == 0))
                {
                    n /= 2;
                }
                else
                {
                    expo = (int)Math.Log(n, 2);
                    n = n - (long)Math.Pow(2, expo);
                }
                cnt++;
            }
            return cnt % 2 == 0 ? "Richard" : "Louise";
        }

        public static string counterGameV2(long n)
        {
            int cnt = 0;
            long x = 0;
            while (n != 1)
            {
                if ((n != 0) && ((n & (n - 1)) == 0))
                {
                    n = n / 2;
                }
                else
                {
                    x = n;
                    x--;
                    x |= (x >> 1);
                    x |= (x >> 2);
                    x |= (x >> 4);
                    x |= (x >> 8);
                    x |= (x >> 16);
                    x = x - (x >> 1);

                    n = n - x;
                }
                cnt++;
            }
            return cnt % 2 == 0 ? "Richard" : "Louise";
        }

        /*****Problem: Sum vs XOR*****/
        public static long sumXor(long n)
        {
            if (n == 0)
            {
                return 1;
            }

            string bin = Convert.ToString(n, 2);
            int pow = bin.Count(x => x == '0');
            return Convert.ToInt64(Math.Pow(2, pow));

        }

        /*****Problem: Palindrome Index*****/
        public static int palindromeIndex(string s)
        {
            int b = s.Count() - 1;
            int retVal = -1;
            for (int f = 0; f < b; f++)
            {
                if (s[f] == s[b])
                {
                    b--;
                }
                else
                {
                    if (s[f] == s[b - 1] && s[f + 1] == s[b - 2])
                    {
                        retVal = b;
                        break;
                    }
                    else if (s[f + 1] == s[b] && s[f + 2] == s[b - 1])
                    {
                        retVal = f;
                        break;
                    }
                }
            }
            return retVal;
        }

        public static int palindromeIndexV2(string s)
        {
            int b = s.Count() - 1;
            int retVal = -1;
            for (int f = 0; f < b; f++)
            {
                if (s[f] != s[b])
                {
                    if (isPalindrome(s, f + 1, b))
                    {
                        return f;
                    }
                    else
                    {
                        return b;
                    }
                }
                b--;
            }
            return retVal;
        }

        public static bool isPalindrome(String s, int f, int b)
        {
            while (f < b)
            {
                if (s[f] != s[b])
                {
                    return false;
                }
                f++;
                b--;
            }
            return true;
        }
    }
}
