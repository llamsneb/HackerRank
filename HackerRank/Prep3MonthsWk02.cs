using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class Prep3MonthsWk02
    {
        /*****Problem: Lonely Integer*****/
        public static int lonelyinteger(List<int> a)
        {
            int x = 0;
            for (int i = 0; i < a.Count; i++)
            {
                x = x ^ a[i];
            }
            return x;
        }

        public static int lonelyintegerV2(List<int> a)
        {
            return a.GroupBy(s => s)
                    .Where(s => s.Count() == 1)
                    .Select(s => s.Key).FirstOrDefault();
        }

        /*****Problem: Grading Students*****/
        public static List<int> gradingStudents(List<int> grades)
        {
            List<int> rounded = new List<int>();
            foreach (int g in grades)
            {
                if (g >= 38)
                {
                    int r = g % 5;
                    if (r > 2)
                    {
                        rounded.Add(g + (5 - r));
                    }
                    else
                    {
                        rounded.Add(g);
                    }
                }
                else
                {
                    rounded.Add(g);
                }
            }

            return rounded;
        }

        /*****Problem: Flipping bits*****/
        public static long flippingBits(long n)
        {
            string bits = Convert.ToString(n, 2);
            string flipped = string.Empty;
            foreach (char c in bits)
            {
                flipped += (c == '0') ? "1" : "0";
            }

            flipped = flipped.PadLeft(32, '1');

            return Convert.ToInt64(flipped, 2);
        }

        public static long flippingBitsV2(long n)
        {
            return ~(uint)n;
        }

        public static long flippingBitsV3(long n)
        {
            return uint.MaxValue - n;
        }

        /*****Problem: Diagonal Difference*****/
        public static int diagonalDifference(List<List<int>> arr)
        {
            int pd = 0;
            int sd = 0;
            int n = arr.Count;
            int j = n - 1;
            for (int i = 0; i < n; i++)
            {
                pd += arr[i][i];
                sd += arr[i][j--];
            }

            return Math.Abs(pd - sd);
        }

        /*****Problem: Counting Sort 1*****/
        public static List<int> countingSort(List<int> arr)
        {
            List<int> freqs = new List<int>(new int[100]);
            for (int i = 0; i < arr.Count; i++)
            {
                freqs[arr[i]] += 1;
            }
            return freqs;
        }

        public static List<int> countingSortV2(List<int> arr)
        {
            List<int> freqs = new List<int>(new int[100]);
            for (int i = 0; i < freqs.Count; i++)
            {
                freqs[i] = arr.Where(a => a == i).Count();
            }
            return freqs;
        }

        /*****Problem: Counting Valleys*****/
        public static int countingValleys(int steps, string path)
        {
            int level = 0;
            int vCnt = 0;
            foreach (char c in path)
            {
                if (c == 'U')
                {
                    level += 1;
                }
                else if (c == 'D')
                {
                    level -= 1;
                    if (level == -1)
                    {
                        vCnt++;
                    }
                }
            }
            return vCnt;
        }

        /*****Problem: Pangrams*****/
        public static string pangrams(string s)
        {
            string lowerS = s.ToLower();
            string alph = "abcdefghijklmnopqrstuvwxyz";

            foreach (char c in alph)
            {
                if (!lowerS.Contains(c))
                {
                    return "not pangram";
                }
            }
            return "pangram";
        }

        /*****Problem: Mars Exploration*****/
        public static int marsExploration(string s)
        {
            int cnt = 0;
            for (int i = 0; i < s.Length; i += 3)
            {
                if (s[i] != 'S')
                {
                    cnt++;
                }
                if (s[i + 1] != 'O')
                {
                    cnt++;
                }
                if (s[i + 2] != 'S')
                {
                    cnt++;
                }
            }
            return cnt;
        }

        public static int marsExplorationV2(string s)
        {
            int cnt = 0;
            int r = 0;
            for (int i = 0; i < s.Length; i++)
            {
                r = (i + 1) % 3;
                if (r == 1 || r == 0)
                {
                    if (s[i] != 'S')
                    {
                        cnt++;
                    }
                }
                else if (r == 2)
                {
                    if (s[i] != 'O')
                    {
                        cnt++;
                    }
                }
            }
            return cnt;
        }

        /*****Problem: Flipping the Matrix*****/
        public static int flippingMatrix(List<List<int>> matrix)
        {
            int l = matrix.Count;
            int n = l / 2;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    List<int> mlist = new List<int>(){
                        matrix[i][j],
                        matrix[i][l-1-j],
                        matrix[l-1-i][j],
                        matrix[l-1-i][l-1-j]
                    };

                    sum += mlist.Max();
                }
            }

            return sum;
        }
    }
}
