using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class Prep3MonthsWk05
    {
        /*****Problem: Max Min*****/
        public static int maxMin(int k, List<int> arr)
        {
            arr.Sort();
            int min = -1;
            for (int i = 0; i < arr.Count() - k + 1; i++)
            {
                int dif = arr[i + k - 1] - arr[i];
                if (min == -1 || dif < min)
                {
                    min = dif;
                }
            }

            return min;
        }

        /*****Problem: Strong Password*****/
        public static int minimumNumber(int n, string password)
        {
            // Return the minimum number of characters to make the password strong
            int chars = 0;
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;
            string spChars = "!@#$%^&*()-+";

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpper = true;
                }

                if (char.IsLower(c))
                {
                    hasLower = true;
                }

                if (char.IsDigit(c))
                {
                    hasDigit = true;
                }

                if (spChars.Contains(c))
                {
                    hasSpecial = true;
                }
            }

            if (!hasUpper) { chars++; }
            if (!hasLower) { chars++; }
            if (!hasSpecial) { chars++; }
            if (!hasDigit) { chars++; }

            if (n + chars < 6)
            {
                chars = 6 - n;
            }
            return chars;
        }

        /*****Problem: Dynamic Array*****/
        public static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            int lastAnswer = 0;
            List<int> answers = new List<int>();
            var arr = Enumerable.Range(0, n).Select(_ => new List<int>()).ToList();
            int idx = 0;
            foreach (List<int> q in queries)
            {
                idx = (q[1] ^ lastAnswer) % n;
                if (q[0] == 1)
                {
                    arr[idx].Add(q[2]);
                }
                else if (q[0] == 2)
                {
                    lastAnswer = arr[idx][q[2] % arr[idx].Count()];
                    answers.Add(lastAnswer);
                }
            }
            return answers;
        }

        /*****Problem: Smart Number 2*****/
        bool is_smart_number(int num)
        {
            int val = (int)Math.Sqrt(num);
            if (val * val == num)
                return true;
            return false;
        }

        /*****Problem: Missing Numbers*****/
        public static List<int> missingNumbers(List<int> arr, List<int> brr)
        {
            foreach (var el in arr)
                brr.Remove(el);

            brr = brr.Distinct().ToList();
            brr.Sort();
            return brr;

        }

        public static List<int> missingNumbersV2(List<int> arr, List<int> brr)
        {
            arr.Sort();
            brr.Sort();
            int dif = 0;
            List<int> result = new List<int>();
            Dictionary<int, int> dic1 = new Dictionary<int, int>();
            Dictionary<int, int> dic2 = new Dictionary<int, int>();

            foreach (int b in brr.Distinct())
            {
                dic2.Add(b, brr.Where(r => r == b).Count());
                dic1.Add(b, arr.Where(r => r == b).Count());
            }

            for (int i = 0; i < dic2.Count(); i++)
            {
                dif = dic2.ElementAt(i).Value - dic1.ElementAt(i).Value;
                if (dif > 0)
                {
                    result.Add(dic1.ElementAt(i).Key);
                }
            }

            return result;
        }

        /*****Problem: The Full Counting Sort*****/
        public static void countSort(List<List<string>> arr)
        {
            int n = arr.Count;
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                if (i < n / 2)
                {
                    arr[i][1] = "-";
                }
                if (max < Convert.ToInt32(arr[i][0]))
                {
                    max = Convert.ToInt32(arr[i][0]);
                }
            }

            IEnumerable<List<string>> l;
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < max + 1; j++)
            {
                l = arr.Where(a => a[0] == j.ToString());
                foreach (var item in l)
                {
                    sb.Append(item[1] + " ");
                }
            }
            Console.Write(sb.ToString());
        }

        /*****Problem: Grid Challenge*****/
        public static string gridChallenge(List<string> grid)
        {
            var sGrid = new List<List<char>>();
            foreach (string s in grid)
            {
                sGrid.Add(new List<char>(s.Order()));
            }

            for (int i = 0; i < sGrid.Count - 1; i++)
            {
                for (int j = 0; j < sGrid[i].Count; j++)
                {
                    if (sGrid[i][j] > sGrid[i + 1][j])
                    {
                        return "NO";
                    }
                }
            }
            return "YES";
        }

        /*****Problem: Sansa and XOR*****/
        public static int sansaXor(List<int> arr)
        {
            if (arr.Count % 2 == 0)
            {
                return 0;
            }
            int retVal = 0;
            for (int i = 0; i < arr.Count; i += 2)
            {
                retVal ^= arr[i];
            }
            return retVal;
        }

        public static int sansaXorV2(List<int> arr)
        {
            if (arr.Count % 2 == 0)
            {
                return 0;
            }
            int retVal = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (i % 2 == 0)
                {
                    retVal ^= arr[i];
                }

            }
            return retVal;
        }

        /*****Problem: Fibonacci Modified*****/
        public static BigInteger fibonacciModified(int t1, int t2, int n)
        {
            BigInteger p1 = (BigInteger)t1;
            BigInteger p2 = (BigInteger)t2;
            BigInteger c = 0;

            for (int i = 0; i < n - 2; i++)
            {
                c = p1 + (p2 * p2);
                p1 = p2;
                p2 = c;
            }

            return c;
        }
    }
}
