using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    internal class Prep3MonthsWk09
    {
        /*****Problem: Waiter*****/       
        public static List<int> waiter(List<int> number, int q)
        {
            List<int> primes = [2];
            for (int i = 1; i < q; i++)
            {
                primes.Add(nextPrime(primes[i - 1]));
            }

            Stack<int> numStk = new Stack<int>();
            foreach (int n in number)
            {
                numStk.Push(n);
            }

            List<int> aLst = new List<int>();
            Stack<int> bStk = new Stack<int>();
            List<int> answers = new List<int>() { };
            int cnt = numStk.Count;
            for (int i = 0; i < q; i++)
            {
                for (int j = 0; j < cnt; j++)
                {
                    if (numStk.Peek() % primes[i] == 0)
                    {
                        bStk.Push(numStk.Pop());
                    }
                    else
                    {
                        aLst.Add(numStk.Pop());
                    }
                }
                while (bStk.Count > 0)
                {
                    answers.Add(bStk.Pop());
                }
                for (int k = 0; k < aLst.Count; k++)
                {
                    numStk.Push(aLst[k]);
                }
                aLst.Clear();
                cnt = numStk.Count;
            }

            while (numStk.Count > 0)
            {
                answers.Add(numStk.Pop());
            }

            return answers;
        }

        public static int nextPrime(int n)
        {
            if (n < 2)
            {
                return 2;
            }

            if (n == 2)
            {
                return 3;
            }

            bool found = false;
            while (!found && n < 2 * n)
            {
                if (isPrime(n += 1))
                {
                    found = true;
                }
            }

            return n;
        }

        public static bool isPrime(int n)
        {
            if (n % 2 == 0 || n % 3 == 0)
            {
                return false;
            }

            // To check through all numbers of the form 6k ± 1 
            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /*****Problem: Stock Maximize*****/
        public static long stockmax(List<int> prices)
        {
            long maxProfit = 0;
            int maxIdx = 0;
            while (prices.Count > 0)
            {
                int max = prices.Max();
                maxIdx = prices.IndexOf(max);
                int shareCnt = 0;
                for (int i = 0; i < maxIdx; i++)
                {
                    maxProfit -= prices[i];
                    shareCnt++;
                }
                maxProfit += shareCnt * (long)prices[maxIdx];

                prices = prices.Slice(maxIdx + 1, prices.Count - 1 - maxIdx);
            }

            return maxProfit;
        }

        public static long stockmaxV2(List<int> prices)
        {
            long maxProfit = 0;
            int maxFuturePrice = 0;

            for (int i = prices.Count - 1; i >= 0; i--)
            {
                if (prices[i] > maxFuturePrice)
                {
                    maxFuturePrice = prices[i];
                }
                maxProfit += maxFuturePrice - prices[i];
            }

            return maxProfit;
        }

        /*****Problem: Simple Text Editor*****/
        public static string txtOpsSwitch(string line, string initial, Stack<string> undoStk)
        {
            StringBuilder sb = new StringBuilder(initial);
            string[] inLine = line.Split();
            switch (Convert.ToInt32(inLine[0]))
            {
                case 1:
                    undoStk.Push(sb.ToString());
                    sb.Append(inLine[1]);
                    break;
                case 2:
                    undoStk.Push(sb.ToString());
                    int remLength = Convert.ToInt32(inLine[1]);
                    sb.Remove(sb.Length - remLength, remLength);
                    break;
                case 3:
                    Console.WriteLine(sb[Convert.ToInt32(inLine[1]) - 1]);
                    break;
                case 4:
                    sb = new StringBuilder(undoStk.Pop());
                    break;
            }
            return sb.ToString();
        }

        /*****Problem: Equal Stacks*****/
        public static int equalStacks(List<int> h1, List<int> h2, List<int> h3)
        {
            Stack<int> Stk1 = new Stack<int>();
            Stack<int> Stk2 = new Stack<int>();
            Stack<int> Stk3 = new Stack<int>();
            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;
            for (int i = h1.Count - 1; i >= 0; i--)
            {
                Stk1.Push(h1[i]);
                sum1 += h1[i];
            }

            for (int i = h2.Count - 1; i >= 0; i--)
            {
                Stk2.Push(h2[i]);
                sum2 += h2[i];
            }

            for (int i = h3.Count - 1; i >= 0; i--)
            {
                Stk3.Push(h3[i]);
                sum3 += h3[i];
            }


            while (Stk1.Count > 0 && Stk2.Count > 0 && Stk3.Count > 0)
            {
                int minSum = Math.Min(sum1, Math.Min(sum2, sum3));
                while (sum1 > minSum)
                {
                    sum1 -= Stk1.Pop();
                }

                while (sum2 > minSum)
                {
                    sum2 -= Stk2.Pop();
                }

                while (sum3 > minSum)
                {
                    sum3 -= Stk3.Pop();
                }

                if (sum1 == sum2 && sum2 == sum3)
                {
                    return sum1;
                }
            }

            return 0;
        }

        /*****Problem: The Coin Change Problem*****/
        public static long getWays(int n, List<long> c)
        {
            long[] ways = new long[n + 1];
            ways[0] = 1;

            for (int i = 0; i < c.Count; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (c[i] <= j)
                    {
                        ways[j] += ways[(int)(j - c[i])];
                    }
                }
            }

            return ways[n];
        }

        /*****Problem: Two Characters*****/
        public static int alternate(string s)
        {
            char[] chars = s.Distinct().ToArray();
            char[] charStr = s.ToCharArray();

            int max = 0;
            bool isAlternating = true;
            char[] tst;
            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = i + 1; j < chars.Length; j++)
                {
                    tst = charStr.Where(c => c == chars[i] || c == chars[j]).ToArray();
                    isAlternating = true;
                    int k = 0;
                    while (isAlternating && k < tst.Length - 1)
                    {
                        if (tst[k] == tst[k + 1])
                        {
                            isAlternating = false;
                        }
                        k++;
                    }

                    if (isAlternating && max < tst.Length)
                    {
                        max = tst.Length;
                    };
                }
            }
            return max;
        }

        /*****Problem: The Maximum Subarray*****/
        public static List<int> maxSubarray(List<int> arr)
        {
            int max = arr.Max();
            List<int> retVal = new List<int> { max, max };
            int sumSub = 0;
            foreach (int a in arr)
            {
                sumSub = Math.Max(a, sumSub + a);
                max = Math.Max(sumSub, max);
            }

            retVal[0] = max;

            int sum = 0;
            List<int> subSeq = arr.Where(n => n > 0).ToList();
            if (subSeq.Count > 0)
            {
                max = subSeq.Sum();
            }
            else
            {
                max = arr.Max();
            }

            retVal[1] = max;
            return retVal;
        }

        /*****Problem: Chief Hopper*****/
        public static int chiefHopper(List<int> arr)
        {
            int energy = 0;
            for (int i = arr.Count - 1; i >= 0; i--)
            {
                energy = (energy + arr[i] + 1) / 2;

            }
            return energy;
        }

        /*****Problem: Truck Tour*****/

        public static int truckTour(List<List<int>> petrolpumps)
        {
            int fuel = 0;
            int pump = 0;

            for (int i = 0; i < petrolpumps.Count; i++)
            {
                fuel += petrolpumps[i][0] - petrolpumps[i][1];
                if (fuel <= 0)
                {
                    fuel = 0;
                    pump = i + 1;
                }
            }

            return pump;       
        }

        public static int truckTourV2(List<List<int>> petrolpumps)
        {
            int fuel = 0;
            int cnt = 0;

            int i = 0;
            while (cnt <= petrolpumps.Count)
            {
                fuel = fuel + petrolpumps[i][0] - petrolpumps[i][1];
                if (fuel < 0)
                {
                    fuel = 0;
                    cnt = 0;
                }
                else
                {
                    cnt++;
                }

                if (i < petrolpumps.Count - 1)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }

            return i - 1;
        }
    }
}
